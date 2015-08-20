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
    public partial class frmEmpBasicPay : Form
    {
        public Employee emp = new Employee();
        Decimal newbasicpay = 0;

        public frmEmpBasicPay()
        {
            InitializeComponent();
        }

        private void frmEmpBasicPay_Load(object sender, EventArgs e)
        {
            txtBasicPay.Text = emp.basic_pay.ToString("##0.00");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            newbasicpay = Convert.ToDecimal(txtBasicPay.Text);
            if (emp.basic_pay != newbasicpay) {
                BasicPay bp = new BasicPay();
                bp.empid = Convert.ToInt32(emp.empid);
                bp.basic_pay = newbasicpay;

                if (bp.save())
                {
                    this.Dispose();
                }
                else {
                    MessageBox.Show("There was a problem updating employee's basic pay : \n" + db.err.Message);
                }
            }
        }
    }
}
