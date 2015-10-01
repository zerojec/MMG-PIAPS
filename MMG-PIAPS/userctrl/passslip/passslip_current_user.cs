using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using MMG_PIAPS.modules;

namespace MMG_PIAPS.userctrl.passslip
{
    public partial class passslip_current_user : UserControl
    {
        public passslip_current_user()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            passslip_apply_new c = new passslip_apply_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void passslip_current_user_Load(object sender, EventArgs e)
        {
            PassSlip ps = new PassSlip();
            ps.empid = Global.CURRENT_USER.empid;

            //MessageBox.Show(Global.CURRENT_USER.empid);
            ps.LoadMyPassSlips(lv);

        }
    }
}
