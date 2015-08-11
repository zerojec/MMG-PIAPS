using MMG_PIAPS.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.modules;

namespace MMG_PIAPS.forms.emp
{
    public partial class frmEmpStatus : Form
    {

        public Employee emp = new Employee();
        String newstatus = "";
        public frmEmpStatus()
        {
            InitializeComponent();
        }

        private void frmEmpStatus_Load(object sender, EventArgs e)
        {
            cboemploymentstatus.Text = emp.emp_status;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            newstatus = cboemploymentstatus.Text;
            if (emp.emp_status != newstatus) {
                emp.emp_status = newstatus;
                if (emp.SET_EMPLOYMENT_STATUS())
                {
                    this.Dispose();
                }
                else {
                    MessageBox.Show("There was a problem updating employee's employment status : \n" + db.err.Message);
                }
            }
        }
    }
}
