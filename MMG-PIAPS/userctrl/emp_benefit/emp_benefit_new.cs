using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using System.IO;
using MMG_PIAPS.modules;

namespace MMG_PIAPS.userctrl.emp_benefit
{
    public partial class emp_benefit_new : UserControl
    {
        Employee emp = new Employee();
        public emp_benefit_new()
        {
            InitializeComponent();
        }

        private void emp_benefit_new_Load(object sender, EventArgs e)
        {            
            emp.LoadEmployee(cboEmp);
            Benefit b = new Benefit();
            b.LoadInComboBox(cboBenefits);
        }

        private void cboEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmp.Text != "")
            {
                String[] c = cboEmp.Text.ToString().Split('-');
                String id = c[1];
                Employee emp1, emp2 = new Employee();
                emp2.empid = Convert.ToInt32(id);

                emp1 = emp2.SELECT_BY_ID();
                emp = emp1;
                //emp1.SELECT_BY_ID();
                emp1.GET_IMAGE_BY_ID();

                String pos = (emp1.GET_CURRENT_POSITION() != "") ? emp1.position.ToString() : "NO_POSITION_INDICATED";
                lblemp.Text = emp1.lname.ToUpper() + ", " + emp1.fname.ToUpper() + " " + emp1.mname.ToUpper() + " - " + pos;

                if (emp1.pic != null)
                {
                    MemoryStream ms = new MemoryStream(emp1.pic);
                    pb.Image = Image.FromStream(ms);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pb.Image = Properties.Resources.noimagefound;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (cboEmp.Text != "")
            {
                String[] c = cboEmp.Text.ToString().Split('-');
                String id = c[1];

                Emp_Benefit eb = new Emp_Benefit();
                eb.empid = Convert.ToInt32(id);
                eb.benefit_code = cboBenefits.Text;

                if (chkNa.Checked)
                {
                    eb.emp_benefit_code = "N/A";
                }
                else {
                    eb.emp_benefit_code = txtemp_benefit_code.Text;
                }
                

                if (eb.save())
                {
                    MessageBox.Show("Successful", "Save");
                }
                else {
                    MessageBox.Show("There was a problem saving employee benefits: \n" + db.err.Message, "Failed");
                }
                this.Parent.Height = 0;
                this.Parent.Controls.Clear();
                this.Dispose();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

        private void chkNa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNa.Checked)
            {
                txtemp_benefit_code.Text = "";
                txtemp_benefit_code.Enabled = false;               
            }
            else {
                txtemp_benefit_code.Enabled = true;
            }
        }
    }
}
