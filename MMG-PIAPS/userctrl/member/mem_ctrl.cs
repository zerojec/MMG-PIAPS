using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.member
{
    public partial class mem_ctrl : UserControl
    {
        Member m = new Member();

        public mem_ctrl()
        {
            InitializeComponent();
        }

        private void mem_ctrl_Load(object sender, EventArgs e)
        {
            m.LoadMembersInListView(lv);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            mem_new c = new mem_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }
    }
}
