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

namespace MMG_PIAPS.userctrl.leave
{
    public partial class leave_new : UserControl
    {






        Employee emp = new Employee();






        public leave_new()
        {
            InitializeComponent();
        }






        private void cboEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmp.Text != "")
            {
                String[] c = cboEmp.Text.ToString().Split('-');
                String id = c[1];
                Employee emp1, emp2 = new Employee();
                emp2.empid = id;

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





        private void leave_new_Load(object sender, EventArgs e)
        {
            emp.LoadEmployee(cboEmp);
        }







        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }







        private void btnsave_Click(object sender, EventArgs e)
        {
            Leave l = new Leave();
            l.empid = emp.empid;
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
            else {
                MessageBox.Show("There was a problem saving leave :\n" + db.err.Message);
            }
        }










    }
}
