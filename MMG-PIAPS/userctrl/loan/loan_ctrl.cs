using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.userctrl.loan
{
    public partial class loan_ctrl : UserControl
    {
        public loan_ctrl()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            loan_salary_new c = new loan_salary_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void btnMicroLoan_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            loan_micro_new c = new loan_micro_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }
    }
}
