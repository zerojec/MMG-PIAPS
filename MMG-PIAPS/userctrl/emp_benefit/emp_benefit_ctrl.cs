using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.emp_benefit
{
    public partial class emp_benefit_ctrl : UserControl
    {
        public emp_benefit_ctrl()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            emp_benefit_new c = new emp_benefit_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void emp_benefit_ctrl_Load(object sender, EventArgs e)
        {
            Emp_Benefit eb = new Emp_Benefit();
            eb.LoadOnListView(this.lv);
        }
    }
}
