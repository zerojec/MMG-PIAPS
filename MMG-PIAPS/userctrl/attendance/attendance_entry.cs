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

namespace MMG_PIAPS.userctrl.attendance
{
    public partial class attendance_entry : UserControl
    {

        public Employee emp= new Employee();
        public attendance_entry()
        {
            InitializeComponent();
        }

        private void attendance_entry_Load(object sender, EventArgs e)
        {
           
            txtid.Text = emp.empid;
            lblname.Text = emp.lname + ", " + emp.fname + " " + emp.mname + "-" + emp.position;
            // dtBday.Value = emp.birthdate;
            //dtemploymentdate.Value= 


            //IF EMPLOYEE PICTURE IS NOT EMPTY OR NULL
            if (emp.pic != null)
            {
                MemoryStream ms = new MemoryStream(emp.pic);
                pbEmpPic.Image = Image.FromStream(ms);
                pbEmpPic.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {

                pbEmpPic.Image = Properties.Resources.noimagefound;
                pbEmpPic.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Attendance a = new Attendance();
            a.empid = emp.empid;

            DateTime date_ = dtdate_.Value;
            DateTime time_ = dttime_.Value;

            DateTime thisdatetime = new DateTime(date_.Year, date_.Month, date_.Day, time_.Hour, time_.Minute, time_.Second);

            a.date_time = thisdatetime;
            a.work_code = 1;

            if (a.save())
            {
                MessageBox.Show("Successful", "Attendance Update");
            }
            else {
                MessageBox.Show("There was a problem updating the attendance...", "Attendance Update");
            }
        }
    }
}
