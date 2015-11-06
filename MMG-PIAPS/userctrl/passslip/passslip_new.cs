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

namespace MMG_PIAPS.userctrl.passslip
{
    public partial class passslip_new : UserControl
    {

        Employee emp = new Employee();
        public passslip_new()
        {
            InitializeComponent();
        }

        private void passslip_new_Load(object sender, EventArgs e)
        {
            emp.LoadEmployee(cboEmp);
            //Schedule s = new Schedule();
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

        private void cbopasstype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //CREATE A NEW PASS SLIP INSTANCE
            PassSlip ps = new PassSlip();

            ps.empid = emp.empid;

            ps.destination = txtdestination.Text;
            ps.passtype = cbopasstype.Text;
            ps.allowance = Convert.ToDecimal(txtallowance.Text);
            //GET DATA FOR TIME IN
            //year,month,day,hour,minute,second
            int yr, mnth, dy, hr, min, sec;
            yr = dtdate.Value.Year;
            mnth=dtdate.Value.Month;
            dy = dtdate.Value.Day;
            hr = dttimein.Value.Hour;
            min = dttimein.Value.Minute;
            sec = dttimein.Value.Second;

            ps.datetime_in = new DateTime(yr,mnth,dy,hr,min,sec);

            //GET DATA FOR TIME OUT
            hr = dttimeout.Value.Hour;
            min = dttimeout.Value.Minute;
            sec = dttimeout.Value.Second;

            ps.datetime_out = new DateTime(yr, mnth, dy, hr, min, sec);

            if (ps.save())
            {
                MessageBox.Show("Successful");
            }
            else {
                MessageBox.Show("There was a problem saving pass slip : \n" + db.err.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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
