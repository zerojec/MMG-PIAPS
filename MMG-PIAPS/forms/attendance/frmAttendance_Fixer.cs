using MMG_PIAPS.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.forms.attendance
{
    public partial class frmAttendance_Fixer : Form
    {

        public Employee emp = new Employee();
        Attendance thisattendance = new Attendance();
        public DateTime thisdate = new DateTime();

        public frmAttendance_Fixer()
        {
            InitializeComponent();
        }

        private void frmAttendance_Fixer_Load(object sender, EventArgs e)
        {
         
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


            //Load THIS DATE'S ATTENDANCE

            dtdate_.Value = thisdate;

            LoadThisDatesAttendance();
            
        }



        private void LoadThisDatesAttendance(){
         thisattendance.empid = emp.empid;

         DataTable dt = thisattendance.SELECT_BYID_BYDATE(thisdate);

         lbTimeAttendance.Items.Clear();
         if (dt != null) {
             if (dt.Rows.Count > 0) { 
                 
                 foreach(DataRow r in dt.Rows){
                     lbTimeAttendance.Items.Add(Convert.ToDateTime(r["date_time"].ToString()).ToLongTimeString());
                 }
                
             }
         
         }

        }

        private void lbTimeAttendance_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lbTimeAttendance.SelectedItems.Count > 0) { 
                Attendance at = new Attendance();
                at.empid = emp.empid;
               String h = lbTimeAttendance.SelectedItem.ToString();
               DateTime t = Convert.ToDateTime(h);
               DateTime date_ = new DateTime(dtdate_.Value.Year, dtdate_.Value.Month, dtdate_.Value.Day, t.Hour, t.Minute, t.Second);

               at.date_time = date_;

               if (MessageBox.Show("Confirm delete this attendance :" + date_.ToString("MMMM dd, yyyy HH:mm:ss") + "?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes) {


                   if (at.delete())
                   {
                       LoadThisDatesAttendance();
                   }
                   else
                   {
                       MessageBox.Show("There was a problem deleting this attendance", "Deleting Attendance");
                   }

                }// end if messagebox


            }//end if count >0

         //  MessageBox.Show(date_.ToString("MMMM dd, yyyy HH:mm:ss"));
        }

        private void btnAddToAttendance_Click(object sender, EventArgs e)
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
                LoadThisDatesAttendance();
            }
            else
            {
                MessageBox.Show("There was a problem updating the attendance...", "Attendance Update");
            }
        }
    }
}
