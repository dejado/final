using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace final
{
    public partial class warehouse : UserControl
    {
        string currentTable = "pcb"; // 현재 테이블을 추적하기 위한 변수

        public warehouse()
        {
            InitializeComponent();
            ShowGrid(currentTable); // 기본으로 "pcb" 테이블 표시

            // 버튼 클릭 이벤트 핸들러 설정
            pcbBt.Click += (sender, e)
                =>
            {
                ShowGrid("pcb");
                ComboWare();
            };
            moldBt.Click += (sender, e)
                =>
            {
                ShowGrid("mold");
                ComboWare();
            };
            chipBt.Click += (sender, e)
                =>
            {
                ShowGrid("chip");
                ComboWare();
            };
            goodBt.Click += (sender, e)
                =>
            {
                ShowGrid("good");
                ComboGood();
            };
            badBt.Click += (sender, e)
                =>
            {
                ShowGrid("bad");
                ComboBad();
            };
        }

        private void ComboWare()
        {
            typeCom.Items.Clear();
            typeCom.Items.Add("A");
            typeCom.Items.Add("B");
            typeCom.Items.Add("C");
        }
        private void ComboGood()
        {
            typeCom.Items.Clear();
            typeCom.Items.Add("양품");
        }
        private void ComboBad()
        {
            typeCom.Items.Clear();
            typeCom.Items.Add("웨이퍼 작업 불량");
            typeCom.Items.Add("웨이퍼 훼손");
            typeCom.Items.Add("칩 없음");
        }

        // 데이터 그리드 뷰에 테이블 내용을 표시하는 메서드
        private void ShowGrid(string tableName)
        {
            currentTable = tableName; // 현재 테이블을 업데이트

            ware_grid.Rows.Clear(); // 데이터 그리드 뷰 초기화

            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // 쿼리 생성
                string query = $"SELECT * FROM {tableName}";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // 조회된 데이터 그리드 뷰에 추가
                        ware_grid.Rows.Add(reader["lot"], reader["type"], reader["num"], reader["date"]);
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

        // 검색 버튼 클릭 이벤트 핸들러
        private void askBt_Click(object sender, EventArgs e)
        {
            // 사용자 입력 가져오기
            if(int.TryParse(lotTxt.Text,out int lot))
            {
                Console.WriteLine("성공");
            }
            else
            {
                Console.WriteLine("실패");
            }
            string type = typeCom.SelectedItem?.ToString();
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // 데이터 그리드 뷰에 검색 결과 표시
            AskGrid(lot, type, date);
        }

        // 특정 조건으로 데이터 그리드 뷰를 필터링하는 메서드
        public void AskGrid(int lot, string type, string date)
        {
            ware_grid.Rows.Clear(); // 데이터 그리드 뷰 초기화

            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // 쿼리 생성
                string query = $"SELECT * FROM {currentTable} WHERE 1=1";

                if (lot != 0)
                    query += $" AND lot={lot}";
                if (!string.IsNullOrEmpty(type))
                    query += $" AND type='{type}'";
                if (date!= "1989-01-01")
                    query += $" AND date='{date}'";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                // 쿼리 실행
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // 조회된 데이터 그리드 뷰에 추가
                        ware_grid.Rows.Add(reader["lot"], reader["type"], reader["num"], reader["date"]);
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
    }

}
