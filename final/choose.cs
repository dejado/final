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

namespace final
{
    public partial class choose : Form
    {
        string chip;
        string pcb;
        string mold;
        public choose()
        {
            InitializeComponent();

            chip= storage.chip;
            pcb= storage.pcb;
            mold= storage.mold;

            if( !string.IsNullOrEmpty(chip))
            {
                chiptxt.Text=chip;
            }
            if (!string.IsNullOrEmpty(pcb))
            {
                pcbtxt.Text = pcb;
            }
            if (!string.IsNullOrEmpty(mold))
            {
                moldtxt.Text = mold;
            }
        }

        private void choose_Load(object sender, EventArgs e)
        {

        }

        private void chipBt_Click(object sender, EventArgs e)
        {
            chip chip=new chip();
            chip.Show();
            this.Close();
        }

        private void pcbBt_Click(object sender, EventArgs e)
        {
            pcb pcb=new pcb();
            pcb.Show();
            this.Close();
        }

        private void moldBt_Click(object sender, EventArgs e)
        {
            mold mold=new mold();
            mold.Show();
            this.Close();
        }
        ActUtlType plc = new ActUtlType();
        private void okBt_MouseDown(object sender, MouseEventArgs e)
        {
            plc.SetDevice("M8191", 1);
            okBt.MouseUp += delegate (object sender1, MouseEventArgs e1)
            {
                plc.SetDevice("M8191", 0);
            };
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            
            plc.ActLogicalStationNumber = 2;    // PLC 논리 스테이션 번호 설정

            int open = plc.Open();
            if (open == 0)
            {
                if (!string.IsNullOrEmpty(chip) && !string.IsNullOrEmpty(pcb) && !string.IsNullOrEmpty(mold))
                {
                    plc.SetDevice("M90", 1);
                    plc.SetDevice("M83", 1);
                    plc.SetDevice("M81", 0);
                    plc.SetDevice("M82", 0);

                }

            }
            else if (open == 1)
            {
                MessageBox.Show("연결실패");
            }
            plc.GetDevice("M8190", out int start);
            if (start == 1)
            {
                plc.SetDevice("M90", 0);
                plc.SetDevice("M8191", 0);
            }

            
            this.Close();
        }
    }
}
