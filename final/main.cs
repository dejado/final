using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using FFmpeg;
using System.Diagnostics;
using Calendar.NET;
using MySql.Data.MySqlClient;

namespace final
{
    public partial class main : UserControl
    {
       

        public main()
        {
            InitializeComponent();
            AddCalendar();

        }
        private void AddCalendar()
        {
            Calendar_cal.CalendarDate = DateTime.Now;
            Calendar_cal.CalendarView = CalendarViews.Month;
            Calendar_cal.LoadPresetHolidays = false;
            Calendar_cal.AllowEditingEvents = true;
            // 이벤트 생성
            var groundhogEvent = new HolidayEvent
            {
                Date = DateTime.Now,
                RecurringFrequency = RecurringFrequencies.EveryWeekend,
                EventTextColor = Color.Red
            };
            Calendar_cal.AddEvent(groundhogEvent);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*string path = "rtsp://10.10.32.212:8554/mjpeg/1";
            VideoCapture vc = new VideoCapture();
            vc.Open(path);

            Mat image = new Mat();
            vc.Read(image);*/

        }



        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void main_Load(object sender, EventArgs e)
        {
            BadChart();


        }
        private void ProductChart()
        {
            List<DateTime> date = new List<DateTime>();
            List<int> result=new List<int>();
            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            int good = 0;
            int bad = 0;
            try
            {
                connection.Open();

                // 쿼리 생성
                string query = $"SELECT * FROM result";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime Check_date = (DateTime)reader["date"];
                        int check = 0;
                        if (date == null && date.Count < 0)
                        {
                            date.Add(Check_date);
                        }
                        else
                        {
                            for(int i=0; i<date.Count; i++)
                            {
                                if (date[i] != Check_date)
                                {
                                    check = 1;
                                }
                            }
                            if (check == 0)
                            {
                                date.Add(Check_date);
                            }
                        }
                        switch (reader["type"])
                        {
                            case "GOOD":
                                good++;
                                break;
                            case "BAD1":
                                bad++;
                                break;
                            case "BAD2":
                                bad++;
                                break;
                            case "BAD3":
                                bad++;
                                break;
                        }
                    }
                        
                }
                for (int i = 0; i < date.Count; i++)
                {
                    bad_chart.Series[0].Points.AddXY(date[i], result[i]);
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
        private void BadChart()
        {
            int bad1 = 0;
            int bad2 = 0;
            int bad3 = 0;

            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();

                // 쿼리 생성
                string query = $"SELECT * FROM bad";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        switch (reader["type"])
                        {
                            case "BAD1":
                                bad1++;
                                break;
                            case "BAD2":
                                bad2++;
                                break;
                            case "BAD3":
                                bad3++;
                                break;

                        }
                    }
                }
                string[] type = new string[] { "bad1", "bad2", "bad3" };
                int[] bad = new int[] { bad1, bad2, bad3 };
                for (int i = 0; i < type.Length; i++)
                {
                    bad_chart.Series[0].Points.AddXY(type[i], bad[i]);
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


    }
}
