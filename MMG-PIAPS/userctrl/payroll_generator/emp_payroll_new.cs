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

namespace MMG_PIAPS.userctrl.payroll_generator
{
    public partial class emp_payroll_new : UserControl
    {

        
        public string empid = "";
        public Employee emp = new Employee();
        public DataTable attendancedt;
        public Cutoff cutoff = new Cutoff();
        public List<Cutoff_Details> cutoff_details;
        non_static_dbcon dbcon = new non_static_dbcon();


        public emp_payroll_new()
        {
            InitializeComponent();
        }

        private void emp_payroll_new_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Employee getter = new Employee();
            getter.empid = empid;

            if (dbcon.CONNECT()) {
                emp=getter.SELECT_BY_ID(dbcon);
                emp.GET_IMAGE_BY_ID(dbcon);
                emp.GET_CURRENT_POSITION(dbcon);
            }

           

        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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

            lblnamepos.Text = emp.lname.ToUpper() + ", " + emp.fname.ToUpper() + " " + emp.mname.ToUpper() + " - " + emp.position.ToUpper();
            dbcon.DISCONNECT();

            bgwattendance.RunWorkerAsync();            
            timer1.Enabled = false;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!bgw.IsBusy) {
                bgw.RunWorkerAsync();
            }
        }

        private void bgwattendance_DoWork(object sender, DoWorkEventArgs e)
        {
         
            Attendance att = new Attendance();
            att.empid = emp.empid;

            if (dbcon.CONNECT())
            {
                attendancedt = att.SELECT_BY_EMPID_BW_DATES(cutoff.from_date, cutoff.to_date, dbcon);               
            }

           
        }

        private void bgwattendance_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dbcon.DISCONNECT();

            int ctr = 1;
            if (attendancedt != null)
            {
                foreach (DataRow dr in attendancedt.Rows)
                {
                    string time_attendance = dr["attendance"].ToString();
                    string str = ctr.ToString() + ".\t" + Convert.ToDateTime(dr["date_"].ToString()).ToShortDateString() + "\t" + time_attendance;
                    lbattendance.Items.Add(str);
                    ctr++;
                }

            }
            else {
                lbattendance.Items.Add("No Attendnce found...");
            }
         
        }

        private void lblaction_Click(object sender, EventArgs e)
        {

        }



        
    }
}
