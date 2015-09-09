﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.leave
{
    public partial class leave_ctrl : UserControl
    {
        public leave_ctrl()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            leave_new c = new leave_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void leave_ctrl_Load(object sender, EventArgs e)
        {
            Leave l = new Leave();

            l.LoadOnListView(lv);



        }
    }
}
