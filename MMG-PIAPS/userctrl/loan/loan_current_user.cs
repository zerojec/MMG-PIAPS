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
    public partial class loan_current_user : UserControl
    {
        public loan_current_user()
        {
            InitializeComponent();
        }

        private void btnMicroLoan_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            loan_current_user_micro c = new loan_current_user_micro();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void btnSalaryLoan_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            loan_current_user_salary c = new loan_current_user_salary();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }
    }
}
