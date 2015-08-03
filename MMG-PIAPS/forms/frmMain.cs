using MMG_PIAPS.classes;
using MMG_PIAPS.modules;
using MMG_PIAPS.userctrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.forms
{
    public partial class frmMain : Form
    {

        public int num = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            
          

        }

        private void btnReferrals_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpolyee_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            emp_ctrl c = new emp_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }
    }
}
