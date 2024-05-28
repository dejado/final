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
    public partial class manage : UserControl
    {
        public manage()
        {
            InitializeComponent();
            ShowGrid();
        }

        public void ShowGrid()
        {
            login_grid.Rows.Clear();

            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // 여기서부터 원하는 쿼리를 실행할 수 있습니다.
                string query = "SELECT * FROM login";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // 조회된 데이터 처리
                        login_grid.Rows.Add( reader["name"],reader["id"], reader["pw"], reader["depart"], reader["position"], reader["cdate"]); // 첫 번째 열 값 출력 예시
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
            if (int.TryParse(idTxt.Text, out int id))
            {
                Console.WriteLine("성공");
            }
            else
            {
                Console.WriteLine("실패");
            }
            if (int.TryParse(pwTxt.Text, out int pw))
            {
                Console.WriteLine("성공");
            }
            else
            {
                Console.WriteLine("실패");
            }
            string name = nameTxt.Text;
            string depart = (departCom.SelectedItem != null) ? departCom.SelectedItem.ToString() : "";
            string position = (positionCom.SelectedItem != null) ? positionCom.SelectedItem.ToString() : "";
            string cdate = (cdatePicker.Value != new DateTime(1989, 01, 01)) ? cdatePicker.Value.ToString() : "";

            AskGrid(id,pw, name, depart, position, cdate);
        }

        public void AskGrid(int id, int pw,string name, string depart, string position, string cdate)
        {
            login_grid.Rows.Clear();

            string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // 여기서부터 원하는 쿼리를 실행할 수 있습니다.
                string query = "SELECT * FROM login WHERE 1=1";

                if (id != 0)
                    query += " AND id=@id";
                if (pw != 0)
                    query += " AND pw=@pw";
                if (!string.IsNullOrEmpty(name))
                    query += " AND name=@name";
                if (!string.IsNullOrEmpty(depart))
                    query += " AND depart=@depart";
                if (!string.IsNullOrEmpty(position))
                    query += " AND position=@position";
                if (!string.IsNullOrEmpty(cdate))
                    query += " AND cdate=@cdate";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pw", pw);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@depart", depart);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@cdate", cdate);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 조회된 데이터 처리
                            login_grid.Rows.Add(reader["name"], reader["id"], reader["pw"],  reader["depart"], reader["position"], reader["cdate"]); // 첫 번째 열 값 출력 예시
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("쿼리 실행 실패: " + ex.Message);
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

        private void registerBt_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        public void InsertData()
        {
            try
            {
                string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    if (!int.TryParse(idTxt.Text, out int id))
                    {
                        MessageBox.Show("사원 번호를 올바르게 입력하세요.");
                        return;
                    }
                    if (!int.TryParse(pwTxt.Text, out int pw))
                    {
                        MessageBox.Show("비밀번호를 올바르게 입력하세요.");
                        return;
                    }
                    string name = nameTxt.Text;
                    string depart = (departCom.SelectedItem != null) ? departCom.SelectedItem.ToString() : "";
                    string position = (positionCom.SelectedItem != null) ? positionCom.SelectedItem.ToString() : "";

                    string insertQuery = "INSERT INTO login(id,pw, name, depart, position, cdate) VALUES(@id,@pw, @name, @depart, @position, NOW())";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@pw", pw);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@depart", depart);
                        command.Parameters.AddWithValue("@position", position);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                            connection.Close();
                            ShowGrid(); // 데이터 그리드 뷰 업데이트
                        }
                        else
                        {
                            MessageBox.Show("삽입에 실패했습니다. 재확인이 필요합니다.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

    }
}
