using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.userctrl.leave
{
    public partial class leave_current_user : UserControl
    {
        public leave_current_user()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            leave_apply_new c = new leave_apply_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }
    }
}
