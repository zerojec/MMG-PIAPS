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
    public partial class frmEmpPosition : Form
    {

       public Employee emp = new Employee();
        String newposition = "";

        public frmEmpPosition()
        {
            InitializeComponent();
        }

        private void frmEmpPosition_Load(object sender, EventArgs e)
        {
            Position p = new Position();
            p.LoadPositions(cboEmpPosition);

            cboEmpPosition.Text = emp.position;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            newposition = cboEmpPosition.Text;
            
            if (emp.position != newposition) {
                emp.position = newposition;
                if (emp.SET_CURRENT_POSITION())
                {
                    this.Dispose();
                }
                else {
                    MessageBox.Show("There was a problem changing the employee position : \n" + db.err.Message);
                }
            }
        }

        private void cboEmpPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
