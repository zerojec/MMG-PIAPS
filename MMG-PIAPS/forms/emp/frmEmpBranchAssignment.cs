using MMG_PIAPS.classes;
using MMG_PIAPS.modules;
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
    public partial class frmEmpBranchAssignment : Form
    {
        public Employee emp = new Employee();
        String newbranch = "";
        public frmEmpBranchAssignment()
        {
            InitializeComponent();
        }

        private void frmEmpBranchAssignment_Load(object sender, EventArgs e)
        {
            Branch b = new Branch();
            b.LoadBranches(cboBranches);

            cboBranches.Text = emp.GET_BRANCH_ASSIGNMENT();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] branchid = cboBranches.Text.Split('-');         
            newbranch = branchid[0];

            if (emp.branch != newbranch) {
                emp.branch = newbranch;

                if (emp.SET_BRANCH_ASSIGNMENT())
                {
                    this.Dispose();
                }
                else {
                    MessageBox.Show("There was a problem updating employee's branch assignment :\n" + db.err.Message);
                }
            }
            
            
        }
    }
}
