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
            ShowGrid();
            ProductChart();
            BadChart();
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
                string query = $"SELECT * FROM result";

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



        }
        private void ProductChart()
        {
            Dictionary<string, int> goodCounts = new Dictionary<string, int>();
            Dictionary<string, int> badCounts = new Dictionary<string, int>();
            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // 데이터를 가져오기 위한 쿼리
                string query = "SELECT date, type FROM result";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime checkDate = (DateTime)reader["date"];
                        string dateKey = checkDate.ToString("yyyy-MM-dd"); // 날짜를 문자열로 변환하여 키로 사용

                        // 사전에 키가 있는지 확인하고, 없으면 새 항목 추가
                        if (!goodCounts.ContainsKey(dateKey))
                        {
                            goodCounts[dateKey] = 0;
                        }
                        if (!badCounts.ContainsKey(dateKey))
                        {
                            badCounts[dateKey] = 0;
                        }

                        // 제품 유형에 따라 카운트 증가
                        if ((string)reader["type"] == "양품")
                        {
                            goodCounts[dateKey]++;
                        }
                        else
                        {
                            badCounts[dateKey]++;
                        }
                    }
                }
                if(goodCounts.Count>=badCounts.Count)
                {
                    // 차트에 데이터 추가
                    foreach (var kvp in goodCounts)
                    {
                        string date = kvp.Key;
                        int goodCount = kvp.Value;
                        int badCount = badCounts.ContainsKey(date) ? badCounts[date] : 0;

                        // 각 날짜별로 좋은 제품과 나쁜 제품의 개수를 차트에 추가
                        product_chart.Series[0].Points.AddXY(date, goodCount);
                        product_chart.Series[1].Points.AddXY(date, badCount);
                    }
                }
                else
                {
                    // 차트에 데이터 추가
                    foreach (var kvp in badCounts)
                    {
                        string date = kvp.Key;
                        int badCount = kvp.Value;
                        int goodCount = goodCounts.ContainsKey(date) ? goodCounts[date] : 0;

                        // 각 날짜별로 좋은 제품과 나쁜 제품의 개수를 차트에 추가
                        product_chart.Series[0].Points.AddXY(date, goodCount);
                        product_chart.Series[1].Points.AddXY(date, badCount);
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
                            case "양품":
                                bad1++;
                                break;
                            case "웨이퍼 훼손":
                                bad1++;
                                break;
                            case "웨이퍼 작업 불량":
                                bad2++;
                                break;
                            case "칩 없음":
                                bad3++;
                                break;

                        }
                    }
                }
                string[] type = new string[] { "bad1", "bad2","bad3"};
                int[] bad = new int[] { bad1, bad2,bad3};
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
