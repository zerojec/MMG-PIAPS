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
    public partial class passslip_apply_new : UserControl
    {
        public passslip_apply_new()
        {
            InitializeComponent();
        }

        private void cbopasstype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           
            //IF PASS TYPE NOT SET
             if (cbopasstype.Text != "") {

                 //CREATE A NEW PASS SLIP INSTANCE
                PassSlip ps = new PassSlip();

                ps.empid = Global.CURRENT_USER.empid;

                ps.destination = txtdestination.Text;
                ps.passtype = cbopasstype.Text;
                ps.allowance = Convert.ToDecimal(txtallowance.Text);
                ps.purpose = txtpurpose.Text;

                if (ps.apply_new())
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("There was a problem saving pass slip : \n" + db.err.Message);
                }

            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }
    }
}
