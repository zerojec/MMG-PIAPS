using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.modules;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.leave
{
    public partial class leave_apply_new : UserControl
    {
        EventClassHolder evt = new EventClassHolder();

        public leave_apply_new()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboleavetype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Leave l = new Leave();
            l.empid = Global.CURRENT_USER.empid;
            l.reason = txtreason.Text;
            l.noofdays = Convert.ToDecimal(txtnoofdays.Text);
            l.leavedate = dtleavedate.Value;
            l.leavetype = cboleavetype.Text;
            l.datefiled = dtdatefiled.Value;
            l.status_ = "AWAITING_APPROVAL";
            l.approvedby = "";

            if (l.save())
            {
                MessageBox.Show("Successful");
            }
            else
            {
                MessageBox.Show("There was a problem saving leave :\n" + db.err.Message);
            }
        }

        private void leave_apply_new_Load(object sender, EventArgs e)
        {
            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

      
      
    }
}
