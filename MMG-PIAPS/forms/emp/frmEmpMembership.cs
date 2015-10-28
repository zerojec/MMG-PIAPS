using MMG_PIAPS.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.forms.emp
{
    public partial class frmEmpMembership : Form
    {

        public Employee emp = new Employee();

        public frmEmpMembership()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!txtMembershipID.Equals("")) {
               
                emp.COOP_MEMBERSHIP_ID = txtMembershipID.Text;

                if (emp.UPDATE_MEMBERSHIP()){
                    MessageBox.Show("Membership Updated");
                    this.Dispose();
                }
                else {
                    MessageBox.Show("There was a problem updating employee membership id.");
                    this.Dispose();
                }
            }
        }
    }
}
