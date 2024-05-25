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
    public partial class Navigation : Form
    {
        const int MAX_WIDTH = 200;
        const int MIN_WIDTH = 50;
        const int STEP_WIDTH = 30;
        int Sliding = 200;

        warehouse ware;
        main main;
        product product;
        manage manage;

        public Navigation()
        {
            InitializeComponent();

            main =new main();
            panel1.Controls.Add(main);
            main.Dock= DockStyle.Fill;
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(slideCk.Checked==true)
            {
                wareBt.Text = "1";
                productCk.Text = "2";
                manageBt.Text = "3";
                slideCk.Text = "=";
                mainBt.Visible = false;
                productBt.Visible = false;
            }
            else
            {
                wareBt.Text = "창고";
                productCk.Text = "생산";
                manageBt.Text = "관리";
                slideCk.Text = "=";
            }
            panelTimer.Start();
        }

        private void Navigation_Load(object sender, EventArgs e)
        {

        }


        private void warehouseBt_Click(object sender, EventArgs e)
        {

        }

        private void panelTimer_Tick(object sender, EventArgs e)
        {
            if (slideCk.Checked == true)
            {
                //슬라이딩 메뉴를 숨기는 동작
                Sliding -= STEP_WIDTH;
                if (Sliding <= MIN_WIDTH)
                    panelTimer.Stop();
            }
            else
            {
                //슬라이딩 메뉴를 보이는 동작
                Sliding += STEP_WIDTH;
                if (Sliding >= MAX_WIDTH)
                    panelTimer.Stop();
            }
            slidePanel.Width = Sliding;
        }

        private void productCk_CheckedChanged(object sender, EventArgs e)
        {
            if(productCk.Checked == true)
            {
                mainBt.Visible = true;
                productBt.Visible = true;

            }
            else
            {
                mainBt.Visible = false;
                productBt.Visible = false;
            }
        }

        private void wareBt_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            ware = new warehouse();
            panel1.Controls.Add(ware);
            ware.Dock = DockStyle.Fill;

        }

        private void mainBt_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            main = new main();
            panel1.Controls.Add(main);
            main.Dock = DockStyle.Fill;
        }

        private void productBt_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            product = new product();
            panel1.Controls.Add(product);
            product.Dock = DockStyle.Fill;
        }

        private void manaBt_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            manage=new manage();
            panel1.Controls.Add(manage);
            manage.Dock = DockStyle.Fill;
            
        }

    }
}
