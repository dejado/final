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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void loginBt_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=127.0.0.1;Database=final;Uid=final;Pwd=final1234!;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    int login_status = 0;
                    string nickName = string.Empty;
                    string loginID = idTxt.Text;
                    string loginPWD = pwTxt.Text;

                    string selectQuery = "SELECT * FROM login WHERE id = @loginID AND pw = @loginPWD";

                    MySqlCommand SelectCom = new MySqlCommand(selectQuery, connection);
                    SelectCom.Parameters.AddWithValue("@loginID", loginID);
                    SelectCom.Parameters.AddWithValue("@loginPWD", loginPWD);

                    using (MySqlDataReader userAccount = SelectCom.ExecuteReader())
                    {
                        if (userAccount.Read())
                        {
                            login_status = 1;
                            nickName = (string)userAccount["name"];
                        }
                    }

                    if (login_status == 1)
                    {
                        Properties.Settings.Default.Name = nickName;
                        Properties.Settings.Default.Save();
                        Navigation navigation = new Navigation();
                        navigation.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("아이디와 비밀번호가 일치하지 않습니다.", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
