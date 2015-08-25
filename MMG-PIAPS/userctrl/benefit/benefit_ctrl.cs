using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.benefit
{
    public partial class benefit_ctrl : UserControl
    {
        public benefit_ctrl()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            benefit_new c = new benefit_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void benefit_ctrl_Load(object sender, EventArgs e)
        {
            Benefit b = new Benefit();
            b.LoadOnListView(this.lv);

        }
    }
}
