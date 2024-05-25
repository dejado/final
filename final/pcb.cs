using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final
{
    public partial class pcb : Form
    {
        public pcb()
        {
            InitializeComponent();
            ShowGrid();
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        // 데이터 그리드 뷰에 테이블 내용을 표시하는 메서드
        public void ShowGrid()
        {

            gridView.Rows.Clear(); // 데이터 그리드 뷰 초기화

            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // 쿼리 생성
                string query = $"SELECT * FROM pcb";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // 조회된 데이터 그리드 뷰에 추가
                        gridView.Rows.Add(reader["lot"], reader["type"], reader["num"], reader["date"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL 연결 실패: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void askBt_Click(object sender, EventArgs e)
        {
            // 사용자 입력 가져오기
            int lot;
            if (int.TryParse(lotTxt.Text, out lot))
            {
                Console.WriteLine("성공");
            }
            else
            {
                Console.WriteLine("실패");
            }
            string type = typeCom.SelectedItem?.ToString();
            AskGrid(lot, type);
        }

        // 특정 조건으로 데이터 그리드 뷰를 필터링하는 메서드
        public void AskGrid(int lot, string type)
        {
            gridView.Rows.Clear(); // 데이터 그리드 뷰 초기화

            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // 쿼리 생성
                string query = $"SELECT * FROM pcb WHERE 1=1";

                if (lot != 0)
                    query += $" AND lot={lot}";
                if (!string.IsNullOrEmpty(type))
                    query += $" AND type='{type}'";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // 조회된 데이터 그리드 뷰에 추가
                        gridView.Rows.Add(reader["lot"], reader["type"], reader["num"], reader["date"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("쿼리 실행 실패: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void gridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lotTxt.Text = gridView.CurrentRow.Cells[0].Value.ToString();
            typeCom.Text = gridView.CurrentRow.Cells[1].Value.ToString();
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lotTxt.Text) || String.IsNullOrEmpty(typeCom.Text))
            {
                MessageBox.Show("칩을 선택하세요");
            }
            else
            {
                storage.pcb = lotTxt.Text;
                choose choose = new choose();
                choose.Show();
                this.Close();
            }

        }
    }
}
