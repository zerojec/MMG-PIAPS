using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.passslip
{
    public partial class passslip_ctrl : UserControl
    {
        public passslip_ctrl()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            passslip_new c = new passslip_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void passslip_ctrl_Load(object sender, EventArgs e)
        {
            PassSlip p = new PassSlip();
            p.LoadOnListView(lv);

        }
    }
}
