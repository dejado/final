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
    public partial class choose : Form
    {
        public choose()
        {
            InitializeComponent();

            string chip= storage.chip;
            string pcb= storage.pcb;
            string mold= storage.mold;

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

        private void okBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
