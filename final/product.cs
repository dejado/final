using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;
using MySql.Data.MySqlClient;
namespace final
{
    public partial class product : UserControl
    {
        ActUtlType plc = new ActUtlType();
        int open;
        int close;
        int pcbSpeed = 10;   //pcb 이동속도

        int chip;
        int vision;
        int mold;
        int ware;

        int mware;
        int pware;

        int moldWare_down;
        int pcbWare_up;

        int pcb_out;
        int pcb_in;

        int attach_finish;
        int mold_finish;

        int good;
        int bad;

        int con;
        int chip_out;
        int vision_out;
        int mold_out;

        int attach_start;
        int mold_start;

        int red;
        int yellow;
        int green;

        string chip_lot;
        string pcb_lot;
        string mold_lot;

        string chip_num;
        string pcb_num;
        string mold_num;

        int servo;

        int chip_stop;
        int pcb_stop;
        int mold_stop;

        PictureBox process;
        PictureBox pcb;

        public product()
        {
            InitializeComponent();
            InitializeTimer();

            plc.ActLogicalStationNumber = 2;    // PLC 논리 스테이션 번호 설정

            process =new PictureBox();
            process.Image = Properties.Resources.process;
            process.SizeMode = PictureBoxSizeMode.StretchImage;
            process.Anchor = AnchorStyles.None;
            process.Size = new Size(800, 300);
            tablePanel.Controls.Add(process,1,1);            


        }
        private List<PictureBox> pcbs = new List<PictureBox>(); // PictureBox 리스트를 선언하여 여러 개의 PCB를 관리

        private void Picture_pcb()
        {
            // 새 PictureBox 생성 및 설정
            PictureBox newPcb = new PictureBox();
            newPcb.Image = Properties.Resources.pcb2;
            newPcb.SizeMode = PictureBoxSizeMode.StretchImage;
            newPcb.Size = new Size(30, 15);
            newPcb.Location = new Point(520, 120);
            process.Controls.Add(newPcb);

            // 리스트에 새로운 PictureBox 추가
            pcbs.Add(newPcb);
        }

        private void InitializeTimer()
        {
            // Timer 인스턴스 생성
            timer1 = new Timer();

            // 타이머 간격 설정 (예: 10초 = 10000 밀리초)
            timer1.Interval = 300;

            // Tick 이벤트 핸들러 추가
            timer1.Tick += timer1_Tick;

            // 타이머 시작
            timer1.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Picture_pcb();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            PictureBox pcbToRemove = pcbs[0];
            pcbToRemove.Hide();
            process.Controls.Remove(pcbToRemove);
            pcbToRemove.Dispose();
            pcbs.RemoveAt(0);
        }
        bool wareUpdateDone = false;
        bool attachUpdateDone = false;
        bool pcbUpdateDone = false;
        bool moldUpdateDone = false;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (con == 1)
            {
                foreach (PictureBox pcb in pcbs)
                {
                    pcb.Left -= pcbSpeed; // 모든 PCB를 왼쪽으로 이동
                }
            }


            if (servo == 1)
            {
                // Check if the list is not empty
                if (pcbs.Count > 0)
                {
                    // 가장 먼저 생성된 PCB를 제거하고 리스트에서도 제거
                    PictureBox pcbToRemove = pcbs[0];
                    pcbToRemove.Hide();
                    process.Controls.Remove(pcbToRemove);
                    pcbToRemove.Dispose();
                    pcbs.RemoveAt(0);
                }
            }


            if (chip_out == 1 || mold_out==1|| vision_out == 1)
            {
                pcbSpeed = 0;
            }
            else
            {
                pcbSpeed = 10;
            }

            sensor();
            output();
            text();
            GetData();
            MinusNum();
            //StopProcess();

            if (string.IsNullOrEmpty(pcb_lot)|| string.IsNullOrEmpty(mold_lot)|| string.IsNullOrEmpty(chip_lot))
            {
                plc.SetDevice("M82", 1);
            }
        }

        private void MessProcess()
        {
            if (string.IsNullOrEmpty(chip_lot))
            {
                MessageBox.Show("chip을 추가해 주세요");
            }
            if (string.IsNullOrEmpty(pcb_lot))
            {
                MessageBox.Show("pcb를 추가해 주세요");
            }
            if (string.IsNullOrEmpty(mold_lot))
            {
                MessageBox.Show("mold를 추가해 주세요");
            }

        }
        private void StopProcess()
        {
            if (string.IsNullOrEmpty(chip_lot))
            {
                plc.SetDevice("M92", 1);
            }
            else
            {
                plc.SetDevice("M92", 0);
            }

            if (string.IsNullOrEmpty(pcb_lot))
            {
                plc.SetDevice("M91", 1);
            }
            else
            {
                plc.SetDevice("M91", 0);
            }

            if (string.IsNullOrEmpty(mold_lot))
            {
                plc.SetDevice("M93", 1);
            }
            else
            {
                plc.SetDevice("M93", 0);
            }



            if (chip_stop == 1 && pcb_stop == 1 && mold_stop == 1 && servo == 1)
            {
                plc.SetDevice("M115", 1);
            }
            else
            {
                plc.SetDevice("M115", 0);
            }
        }
        private void MinusNum()
        {
            if (attach_start == 1 && !string.IsNullOrEmpty(chip_lot) && !attachUpdateDone)
            {
                chipUpdate(chip_lot, chip_num);
                attachUpdateDone = true;
            }
            else if (attach_start == 0)
            {
                attachUpdateDone = false; // 다시 업데이트 가능하도록 설정
            }

            if (pcb_in == 1 && !string.IsNullOrEmpty(pcb_lot) && !pcbUpdateDone)
            {
                pcbUpdate(pcb_lot, pcb_num);
                pcbUpdateDone = true;

            }
            else if (pcb_in == 0)
            {
                pcbUpdateDone = false; // 다시 업데이트 가능하도록 설정
            }

            if (mold_start == 1 && !string.IsNullOrEmpty(mold_lot) && !moldUpdateDone)
            {
                moldUpdate(mold_lot, mold_num);
                moldUpdateDone = true;
            }
            else if (mold_start == 0)
            {
                moldUpdateDone = false; // 다시 업데이트 가능하도록 설정
            }

        }
        private void GetData()
        {
            plc.GetDevice("X26", out chip);
            plc.GetDevice("X27", out vision);
            plc.GetDevice("X28", out mold);
            plc.GetDevice("X2A", out ware);

            plc.GetDevice("D0", out servo);

            plc.GetDevice("M92", out chip_stop);
            plc.GetDevice("M91", out pcb_stop);
            plc.GetDevice("M93", out mold_stop);
        }
        private void text()
        {
            chip_lot = storage.chip;
            pcb_lot = storage.pcb;
            mold_lot = storage.mold;

            if (!string.IsNullOrEmpty(chip_lot))
            {
                chip_num = chipNum(int.Parse(chip_lot));
                mysql_chip.Text = "lot : "+chip_lot +", num : "+ chip_num+"개";
            }
            else if (string.IsNullOrEmpty(chip_lot))
            {
                mysql_chip.Text = "없음";
            }
            if(!string.IsNullOrEmpty(pcb_lot))
            {
                pcb_num = pcbNum(int.Parse(pcb_lot));
                mysql_pcb.Text = "lot : " + pcb_lot + ", num :  " + pcb_num + "개";
            }
            else if (string.IsNullOrEmpty(pcb_lot))
            {
                mysql_pcb.Text = "없음";
            }
            if(!string.IsNullOrEmpty(mold_lot))
            {
                mold_num = moldNum(int.Parse(mold_lot));
                mysql_mold.Text = "lot : " + mold_lot + ", num : " + mold_num + "개";
            }
            else if (string.IsNullOrEmpty(mold_lot))
            {
                mysql_mold.Text = "없음";
            }


        }
        private string chipNum(int chip)
        {
            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string num="";
            try
            {
                connection.Open();

                // 쿼리 생성
                string query = $"SELECT * FROM chip WHERE lot={chip}";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        num = reader["num"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return num;
        }

        private string pcbNum(int pcb)
        {
            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string num = "";
            try
            {
                connection.Open();

                // 쿼리 생성
                string query = $"SELECT * FROM pcb WHERE lot={pcb}";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        num = reader["num"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return num;
        }
        private string moldNum(int mold)
        {
            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string num = "";
            try
            {
                connection.Open();

                // 쿼리 생성
                string query = $"SELECT * FROM mold WHERE lot={mold}";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        num = reader["num"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return num;
        }
        private void chipUpdate(string chip, string chip_num)
        {
            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            int.TryParse(chip, out int lot);
            int.TryParse(chip_num, out int num);

            // Decrement num
            num -= 1;

            try
            {
                connection.Open();
                string query;
                if (num <= 0)
                {
                    query = "delete FROM chip WHERE lot=@lot";
                    storage.chip = "";
                }
                else
                {
                    query = "UPDATE chip SET num=@num WHERE lot=@lot";
                }

                // 쿼리 생성


                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // 파라미터 추가
                    cmd.Parameters.AddWithValue("@num", num);
                    cmd.Parameters.AddWithValue("@lot", lot);

                    // 쿼리 실행
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        MessageBox.Show("업데이트 실패");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void pcbUpdate(string pcb, string pcb_num)
        {
            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            int.TryParse(pcb, out int lot);
            int.TryParse(pcb_num, out int num);


            // Decrement num
            num -= 1;

            try
            {
                connection.Open();
                string query;
                if (num <= 0)
                {
                    query = "delete FROM pcb WHERE lot=@lot";
                    storage.pcb="";
                }
                else
                {
                    query = "UPDATE pcb SET num=@num WHERE lot=@lot";
                }

                // 쿼리 생성


                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // 파라미터 추가
                    cmd.Parameters.AddWithValue("@num", num);
                    cmd.Parameters.AddWithValue("@lot", lot);

                    // 쿼리 실행
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        MessageBox.Show("업데이트 실패");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void moldUpdate(string mold,string mold_num)
        {
            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            int.TryParse(mold, out int lot);

            int.TryParse(mold_num, out int num);

            // Decrement num
            num -= 1;

            try
            {
                connection.Open();
                string query;
                if (num <= 0)
                {
                    query = "delete FROM mold WHERE lot=@lot";
                    storage.mold = "";
                }
                else
                {
                    query = "UPDATE mold SET num=@num WHERE lot=@lot";
                }

                // 쿼리 생성


                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // 파라미터 추가
                    cmd.Parameters.AddWithValue("@num", num);
                    cmd.Parameters.AddWithValue("@lot", lot);

                    // 쿼리 실행
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        MessageBox.Show("업데이트 실패");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void sensor()
        {
            if(chip==1) chip_sensor.BackColor = Color.Red;
            else { chip_sensor.BackColor= Color.White; }
            if(vision==1) vision_sensor.BackColor = Color.Red;
            else { vision_sensor.BackColor=Color.White; }
            if(mold==1) mold_sensor.BackColor = Color.Red;
            else { mold_sensor.BackColor = Color.White; }
            if(ware==1) ware_sensor.BackColor = Color.Red;
            else { ware_sensor.BackColor=Color.White ; }

            plc.GetDevice("X02", out pware);
            plc.GetDevice("X12", out mware);

            if(pware == 1) { pware_sensor.BackColor = Color.Red; }
            else { pware_sensor.BackColor = Color.White; }
            if(mware==1) { mware_sensor.BackColor = Color.Red; }
            else { mware_sensor.BackColor = Color.White; }

            plc.GetDevice("X11", out pcbWare_up);
            plc.GetDevice("X10", out moldWare_down);

            if(pcbWare_up == 1) { pcbWare.BackColor = Color.Red; }
            else { pcbWare.BackColor = Color.White; }
            if (moldWare_down == 1) {  moldWare.BackColor = Color.Red;}
            else { moldWare.BackColor = Color.White; }

            plc.GetDevice("X20", out attach_finish);
            plc.GetDevice("X21", out mold_finish);

            if(attach_finish==1) { attach_dobot.BackColor = Color.Red; }
            else { attach_dobot.BackColor = Color.White; }
            if (mold_finish==1) { mold_dobot.BackColor = Color.Red; }
            else { mold_dobot.BackColor = Color.White; }

            plc.GetDevice("X24", out good);
            plc.GetDevice("X25", out bad);

            if(good==1) { vision_good.BackColor = Color.Red; }
            else { vision_good.BackColor = Color.White; }
            if (bad == 1) { vision_bad.BackColor = Color.Red; }
            else { vision_bad.BackColor = Color.White; }


        }

        private void output()
        {
            plc.GetDevice("Y30", out con);
            plc.GetDevice("Y32", out chip_out);
            plc.GetDevice("Y34", out mold_out);
            plc.GetDevice("Y33", out vision_out);


            if (con == 1) { con_run.BackColor = Color.Red; }
            else { con_run.BackColor = Color.White; }
            if (chip_out == 1) { chip_run.BackColor = Color.Red; }
            else { chip_run.BackColor = Color.White; }
            if (mold_out == 1) { mold_run.BackColor = Color.Red; }
            else { mold_run.BackColor = Color.White; }
            if (vision_out==1) { vision_run.BackColor = Color.Red; }
            else { vision_run.BackColor = Color.White; }

            plc.GetDevice("Y41", out pcb_in);
            plc.GetDevice("Y42", out pcb_out);
            if (pcb_in == 1)
            { 
                psignal_up.BackColor = Color.Red;
                Picture_pcb();

            }
            else { psignal_up.BackColor = Color.White; }
            if (pcb_out == 1) { psignal_down.BackColor = Color.Red; }
            else { psignal_down.BackColor = Color.White; }

            plc.GetDevice("Y38", out attach_start);
            plc.GetDevice("Y39", out mold_start);

            if(attach_start == 1) { attachDobot_run.BackColor = Color.Red; }
            else { attachDobot_run.BackColor = Color.White; }
            if (mold_start == 1) { moldDobot_run.BackColor = Color.Red; }
            else { moldDobot_run.BackColor = Color.White; }

            plc.GetDevice("Y46", out red);
            plc.GetDevice("Y47", out yellow);
            plc.GetDevice("Y48", out green);

            if(red==1) { red_run.BackColor = Color.Red; }
            else { red_run.BackColor = Color.White; }
            if (yellow==1) { yel_run.BackColor = Color.Yellow; }
            else { yel_run.BackColor = Color.White; }
            if (green==1) { grn_run.BackColor = Color.Green; }
            else { grn_run.BackColor = Color.White; }

        }
        private void startBt_Click(object sender, EventArgs e)
        {

            open = plc.Open();
            if (open == 0)
            {
                statLb.Text = "연결성공";

            }
            else if (open == 1)
            {
                statLb.Text = "연결실패";
            }

        }


        private void finishBt_Click(object sender, EventArgs e)
        {
            close = plc.Close();
            if (close == 0)
            {
                statLb.Text = "종료";
            }
        }

        private void conStartBt_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M76", 1);
            plc.GetDevice("Y30",out con);

            if (con == 1)
            {
                conTxt.Text = "동작";

            }
            

        }

        private void conStopBt_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M76", 0);

        }


        private void attachUp_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M70", 1);
            attach_lb.Text = "칩셋 업";
        }

        private void attachDown_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M70", 0);
            attach_lb.Text = "칩셋 다운";
        }

        private void visionUp_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M71", 1);
            vision_lb.Text = "비전 업";
        }

        private void visionDown_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M71", 0);
            vision_lb.Text = "비전 다운";
        }

        private void moldUp_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M72", 1);
            mold_lb.Text = "몰드 업";
        }

        private void moldDown_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M72", 0);
            mold_lb.Text = "몰드 다운";
        }


        private void pcb_down_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M73", 0);
            plc.SetDevice("M74", 1);
        }

        private void ware_down_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M79", 0);
        }

        private void ware_up_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M79", 1);
        }

        private void turn_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M78", 1);
        }

        private void not_turn_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M78", 0);
        }

        private void mware_up_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M75", 1);

        }

        private void mware_down_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M75", 0);
        }

        private void RED_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M81", 1);
            plc.SetDevice("M82", 0);
            plc.SetDevice("M83", 0);
        }

        private void YEL_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M81", 0);
            plc.SetDevice("M82", 1);
            plc.SetDevice("M83", 0);
        }

        private void GRN_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M81", 0);
            plc.SetDevice("M82", 0);
            plc.SetDevice("M83", 1);

        }
        private void STOP_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M81", 0);
            plc.SetDevice("M82", 0);
            plc.SetDevice("M83", 0);
        }
 
        private void DOG_MouseDown(object sender, MouseEventArgs e)
        {
            plc.SetDevice("M8", 1);
            DOG.MouseUp+=delegate(object sender1, MouseEventArgs e1){
                plc.SetDevice("M8", 0);
            };
        }


        int preValue;
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // 현재 스크롤바의 값을 가져옵니다.
            int newValue = hScrollBar1.Value;

            // 이전 값과 비교하여 스크롤 방향을 확인합니다.
            if (newValue > preValue)
            {
                // 오른쪽으로 스크롤
                panel3.Left -= (newValue - preValue);
            }
            else if (newValue < preValue)
            {
                // 왼쪽으로 스크롤
                panel3.Left += (preValue - newValue);
            }

            // 새로운 값을 preValue에 저장합니다.
            preValue = newValue;
        }

        private void onBt_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M80", 1);
        }

        private void offBt_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M80", 0);
        }

        private void Lstart_Click(object sender, EventArgs e)
        {
            choose choice = new choose();
            choice.Show();
            
        }

        private void Adobot_MouseDown(object sender, MouseEventArgs e)
        {
            plc.SetDevice("M84", 1);
            Adobot.MouseUp += delegate (object sender1, MouseEventArgs e1)
            {
                plc.SetDevice("M84", 0);
            };
        }

        private void Mdobot_MouseDown(object sender, MouseEventArgs e)
        {
            plc.SetDevice("M85", 1);
            Mdobot.MouseUp += delegate (object sender1, MouseEventArgs e1)
            {
                plc.SetDevice("M85", 0);
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chip_num) && !string.IsNullOrEmpty(pcb_num) && !string.IsNullOrEmpty(mold_num))
            {
                moldUpdate(mold_lot, mold_num);
            }
        }

        private void finish_MouseDown(object sender, MouseEventArgs e)
        {
            plc.SetDevice("M115", 1);
            finish.MouseUp += delegate (object sender1, MouseEventArgs e1)
            {
                plc.SetDevice("M115", 0);
            };
        }

        private void servo_ware_MouseDown(object sender, MouseEventArgs e)
        {
            plc.SetDevice("M908", 1);
            servo_ware.MouseUp += delegate (object sender1, MouseEventArgs e1)
            {
                plc.SetDevice("M908", 0);
            };
        }

        private void servo_con_MouseDown(object sender, MouseEventArgs e)
        {
            plc.SetDevice("M902", 1);
            servo_con.MouseUp+= delegate (object sender1, MouseEventArgs e1)
            {
                plc.SetDevice("M902", 0);
            };
        }

        private void finish_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M81", 1);
            plc.SetDevice("M83", 0);
        }

        private void pcb_up_MouseDown(object sender, MouseEventArgs e)
        {
            plc.SetDevice("M73", 1);
            pcb_up.MouseUp += delegate (object sender1, MouseEventArgs e1)
            {
                plc.SetDevice("M73", 0);
            };
            
        }

        private void pcb_down_MouseDown(object sender, MouseEventArgs e)
        {
            plc.SetDevice("M74", 1);
            pcb_down.MouseUp+=delegate (object sender1, MouseEventArgs e1)
            {
                plc.SetDevice("M74", 0);
            };
        }
    }
}
