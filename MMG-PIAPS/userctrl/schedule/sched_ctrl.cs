using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.schedule
{
    public partial class sched_ctrl : UserControl
    {
        public sched_ctrl(){
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e){
            pnlops.Controls.Clear();

            sched_new c = new sched_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);

        }

        private void sched_ctrl_Load(object sender, EventArgs e)
        {
            Schedule s = new Schedule();
            s.LoadScheduleOnListView(lv);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pnlops_Paint(object sender, PaintEventArgs e)
        {

        }

     
    }
}
