using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.userctrl.emp;

namespace MMG_PIAPS.userctrl
{
    public partial class emp_ctrl : UserControl
    {
        public emp_ctrl()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            emp_new c = new emp_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;

            pnlops.Controls.Add(c);
        }
    }
}
