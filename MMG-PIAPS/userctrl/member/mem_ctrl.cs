using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using MMG_PIAPS.userctrl.member_capital;

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

        private void btnFilter_Click(object sender, EventArgs e)
        {            
            Member mem = new Member();
            m.Load_Searched_MembersInListView(lv, txtname.Text);
        }

        private void updateInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0) {

                Member mem, sel = new Member();
                //MessageBox.Show(lv.SelectedItems[0].SubItems[1].Text);
                sel.memid = lv.SelectedItems[0].SubItems[1].Text;

                mem= sel.SELECT_BY_ID();
                mem.GET_IMAGE_BY_ID();

                if (mem != null) {
                    pnlops.Controls.Clear();
                    mem_update c = new mem_update();
                    c.mem = mem;
                    c.Width = pnlops.Width;
                    pnlops.Height = c.Height;
                    pnlops.Controls.Add(c);
                }
               
            }
        }

        private void viewPaidUpCapitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {

                Member mem, sel = new Member();
                //MessageBox.Show(lv.SelectedItems[0].SubItems[1].Text);
                sel.memid = lv.SelectedItems[0].SubItems[1].Text;

                mem = sel.SELECT_BY_ID();
                mem.GET_IMAGE_BY_ID();

                if (mem != null)
                {
                    pnlops.Controls.Clear();

                    mem_capital_update c = new mem_capital_update();
                    c.mem = mem;
                    c.Width = pnlops.Width;
                    pnlops.Height = c.Height;
                    pnlops.Controls.Add(c);
                }

            }
        }

  

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lv_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
