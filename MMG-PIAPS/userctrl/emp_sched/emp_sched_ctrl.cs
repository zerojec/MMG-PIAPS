using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.emp_sched
{
    public partial class emp_sched_ctrl : UserControl
    {
        public emp_sched_ctrl()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            emp_sched_new c = new emp_sched_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void emp_sched_ctrl_Load(object sender, EventArgs e)
        {
            Emp_Sched es = new Emp_Sched();
            es.LoadEmpSchedInListView(lv);

        }
    }
}
