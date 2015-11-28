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
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Globalization;

namespace MMG_PIAPS.userctrl.payroll_generator
{
    public partial class emp_payroll_new : UserControl
    {

      

        public string empid = "";
        public Employee emp = new Employee();

        public DataTable attendancedt;
        public DataTable cutoffdetailsdt= new DataTable();
        public Emp_Sched empsched = new Emp_Sched();

        public Cutoff cutoff = new Cutoff();
        public List<Cutoff_Details> cutoff_details;

        non_static_dbcon dbcon = new non_static_dbcon();


        int TOTAL_LATES_FOR_THIS_CUTOFF = 0;



        //=============================
        //FOR SCHEDULE RECONSTRUCTION
        //=============================
        int AM_IN_HOUR = 0;
        int AM_IN_MIN = 0;
        int AM_OUT_HOUR = 0;
        int AM_OUT_MIN = 0;
        int PM_IN_HOUR = 0;
        int PM_IN_MIN = 0;
        int PM_OUT_HOUR = 0;
        int PM_OUT_MIN = 0;


        //=============================
        //FOR ATTENDANCE RECONSTRUCTION
        //=============================
        DateTime AM_IN_SCHED, AM_OUT_SCHED, PM_IN_SCHED, PM_OUT_SCHED;
        DateTime AM_IN_ATT, AM_OUT_ATT, PM_IN_ATT, PM_OUT_ATT; 
        DateTime IN_ATT, OUT_ATT;




        private delegate void SetControlPropertyThreadSafeDelegate(Control control,string propertyName,object propertyValue);

        public static void SetControlPropertyThreadSafe(
            Control control,
            string propertyName,
            object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty,null,control,new object[] { propertyValue });
            }
        }














       
        private delegate void  SetLabelText_Delegate(Label lbl, String txt);           
        private delegate void AddItemsDelegate(ListBox l, String s);
    //' The delegates subroutine.
        public void SetLabelText_ThreadSafe(Label lbl, String txt){

            if(lbl.InvokeRequired){
                SetLabelText_Delegate mydelegate= new SetLabelText_Delegate(SetLabelText_ThreadSafe);
                this.Invoke(mydelegate, new object[]{lbl, txt});
            }else{
                lbl.Text= txt;
            }
         }

   
       
    public void AddItemsThreadSafe(ListBox l, String s){
        if (l.InvokeRequired)
        {
            AddItemsDelegate mydelegate = new AddItemsDelegate(AddItemsThreadSafe);
            l.Invoke(mydelegate, new object[] { l, s });
          
        }
        else {
            l.Items.Add(s);
        }
    }
        
    






        public emp_payroll_new()
        {
            InitializeComponent();
        }

        private void emp_payroll_new_Load(object sender, EventArgs e)
        {
            lblaction.Text = "retrieving employee image and data...";
            timer1.Enabled = true;
        }


        //TIMER_1 SHOULD ACTIVATE AFTER LOAD EVENT
        private void timer1_Tick(object sender, EventArgs e)
        {
            //IF BACKGROUNDWORKER IS NOT BUSY
            //DO SOMEWORK ASYNCHRONOUSLY
            // BGW IS THE WORKER TO RETRIEVE EMPLOYEE INFO
            // AND IMAGE
            if (!bgw.IsBusy)
            {
                bgw.RunWorkerAsync();
            }
        }




        //BGW asynchronously GET EMPLOYEE DETAILS 
        //ASYNC GET IMAGE FROM DATABASE
        //ASYNC GET LASTEST POSITION
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Employee getter = new Employee();
            getter.empid = empid;

            if (dbcon.CONNECT()) {
                emp=getter.SELECT_BY_ID(dbcon);
                emp.GET_IMAGE_BY_ID(dbcon);
                emp.GET_CURRENT_POSITION(dbcon);

                Emp_Sched es = new Emp_Sched();
                es.empid = emp.empid;
                empsched = es.SELECT_BY_EMPID(dbcon);
            }

      

        }





        //ONCE THE ASYNC IMAGE GET IS DONE
        //1. LOAD THE IMAGE TO THE PICTURE BOX
        //2. DISCONNECT DYNAMIC DBCONNECTOR
        //3. START TO ASYNC GET ATTENDANCE

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            lblaction.Text = "completed...";
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



            //PUT THE SCHEDULE ON THE LISTVIEW
            if (empsched != null)
            {
                lbschedule.Items.Add("Monday").SubItems.Add(empsched.mon);
                lbschedule.Items.Add("Tuesday").SubItems.Add(empsched.tue);
                lbschedule.Items.Add("Wednesday").SubItems.Add(empsched.wed);
                lbschedule.Items.Add("Thursday").SubItems.Add(empsched.thu);
                lbschedule.Items.Add("Friday").SubItems.Add(empsched.fri);
                lbschedule.Items.Add("Saturday").SubItems.Add(empsched.sat);
                lbschedule.Items.Add("Sunday").SubItems.Add(empsched.sun);

            }
            else
            {
                lbschedule.Items.Add("No schedule yet...");
            }





            lblnamepos.Text = emp.empid + " - " + emp.lname.ToUpper() + ", " + emp.fname.ToUpper() + " " + emp.mname.ToUpper() + " - " + emp.position.ToUpper();
            dbcon.DISCONNECT();

            lblaction.Text = "retrieving attendance...";
            bgwattendance.RunWorkerAsync();            
            timer1.Enabled = false;
            pb.Value = 10;
        }





   

        //BACKGROUND WORKER TO GET THE ATTENDANCE
        //INSTANTIATE AN ATTENDANCE OBJECT
        //SET THE OBJECT.EMPID 
        //GET ATTENDANCE BY_EMPID BETWEEN_DATES AND PUT IT IN A DATATABLE NAMED attendancedt
        private void bgwattendance_DoWork(object sender, DoWorkEventArgs e)
        {
         
            Attendance att = new Attendance();
            att.empid = emp.empid;

            if (dbcon.CONNECT())
            {
                attendancedt = att.SELECT_BY_EMPID_BW_DATES(cutoff.from_date, cutoff.to_date, dbcon);                               
            }

           
        }




        //ONCE ASYNC GET OF ATTENDANCE IS DONE
        //1. LIST THE ATTENDANCE IN THE LISTBOX PROVIDED
        //2. START RETRIEVING THE EMPLOYEE'S SCHEDULE       
        private void bgwattendance_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dbcon.DISCONNECT())
            {
                int ctr = 1;


                if (attendancedt != null)
                {
                    foreach (DataRow dr in attendancedt.Rows)
                    {
                        DateTime d = Convert.ToDateTime(dr["date_"].ToString());
                       
                        string time_attendance = dr["attendance"].ToString();   
                        ListViewItem li = new ListViewItem();
                        li.Text = ctr.ToString();
                        li.SubItems.Add(d.ToLongDateString());
                        li.SubItems.Add(time_attendance);                                
           

                        //========================================================//begin
                        //RECONSTRUCT AND SHOW THE EMPLOYEE SCHEDULE
                        //THEN COMPARE SCHEDULE WITH HIS/HERE BIOMETRICS ATTENDANCE                   
                         Emp_Sched es= new Emp_Sched();
                         es.empid= empid;// EMPID OF THE EMPLOYEE
                         empsched= es.SELECT_BY_EMPID();

                         String SCHEDULE_FOR_THE_DAY = "";   
                        //GET SCHEDULE DEPENDING ON THE DAY OF THE WEEK
                         switch (d.DayOfWeek) { 
                             case DayOfWeek.Monday  :{ SCHEDULE_FOR_THE_DAY=empsched.mon;break;}
                             case DayOfWeek.Tuesday :{ SCHEDULE_FOR_THE_DAY=empsched.tue;break;}
                             case DayOfWeek.Wednesday:{ SCHEDULE_FOR_THE_DAY=empsched.wed;break;}
                             case DayOfWeek.Thursday:{ SCHEDULE_FOR_THE_DAY=empsched.thu;break;}
                             case DayOfWeek.Friday:{ SCHEDULE_FOR_THE_DAY=empsched.fri;break;}
                             case DayOfWeek.Saturday:{ SCHEDULE_FOR_THE_DAY=empsched.sat;break;}
                             case DayOfWeek.Sunday:{ SCHEDULE_FOR_THE_DAY=empsched.sun;break;}
                                
                         }
                         

                         //IF ATTENDANCE IS MONDAY THEN COMPARE WITH MONDAY SCHEDULE
                         //SO WE NEED TO RECONSTRUCT SCHEDULE FOR ALL DAYS OF THE WEEK
                        

                         //RECONSTRUCT SCHEDULE AND CREATE A DATETIME
                         //WITH DATE SAME AS THE ATTENDANCE
                         //BUT TIME IS FETCH FROM THE EMPLOYEE SCHEULE IN THE DATABASE
                         String[] SPLITTED_SCHEDULE_ID = SCHEDULE_FOR_THE_DAY.Split('-');
                         //CHECK FOR TIME-IN-TIME-OUT-TIME-IN-TIME-OUT 
                         //KIND OF SCHEDULE
                         if (SPLITTED_SCHEDULE_ID.Length == 8)
                         {
                             AM_IN_HOUR = Convert.ToInt32(SPLITTED_SCHEDULE_ID[0]);
                             AM_IN_MIN = Convert.ToInt32(SPLITTED_SCHEDULE_ID[1]);
                             AM_OUT_HOUR = Convert.ToInt32(SPLITTED_SCHEDULE_ID[2]);
                             AM_OUT_MIN = Convert.ToInt32(SPLITTED_SCHEDULE_ID[3]);
                             PM_IN_HOUR = Convert.ToInt32(SPLITTED_SCHEDULE_ID[4]);
                             PM_IN_MIN = Convert.ToInt32(SPLITTED_SCHEDULE_ID[5]);
                             PM_OUT_HOUR = Convert.ToInt32(SPLITTED_SCHEDULE_ID[6]);
                             PM_OUT_MIN = Convert.ToInt32(SPLITTED_SCHEDULE_ID[7]);

                             AM_IN_SCHED = new DateTime(d.Year, d.Month, d.Day, AM_IN_HOUR, AM_IN_MIN, 0);
                             AM_OUT_SCHED = new DateTime(d.Year, d.Month, d.Day, AM_OUT_HOUR, AM_OUT_MIN, 0);

                             PM_IN_SCHED = new DateTime(d.Year, d.Month, d.Day, PM_IN_HOUR, PM_IN_MIN, 0);
                             PM_OUT_SCHED = new DateTime(d.Year, d.Month, d.Day, PM_OUT_HOUR, PM_OUT_MIN, 0);



                             //NOW THAT THE SCHEDULE IS RECONSTRUCTED 
                             //WE NEED TO RECONSTRUCT ATTENDANCE COMPARE IT WITH THE SCHEDULE                       

                             string[] SPLITTED_BIOMETRICS_ATTENDANCE = time_attendance.Split(',');
                             //RECONSCTRUCT THE ATTENDANCE
                             //4 HERE MEANS 
                             //TIME-IN, TIME-OUT, TIME-IN, TIME-OUT
                             //THERE ARE 4 WORDS IN BETWEEN COMMA ","
                             if ((SPLITTED_BIOMETRICS_ATTENDANCE.Length == 4))
                             {
                                 AM_IN_ATT = Convert.ToDateTime(d.ToShortDateString() + " " + SPLITTED_BIOMETRICS_ATTENDANCE[0]);
                                 AM_OUT_ATT = Convert.ToDateTime(d.ToShortDateString() + " " + SPLITTED_BIOMETRICS_ATTENDANCE[1]);
                                 PM_IN_ATT = Convert.ToDateTime(d.ToShortDateString() + " " + SPLITTED_BIOMETRICS_ATTENDANCE[2]);
                                 PM_OUT_ATT = Convert.ToDateTime(d.ToShortDateString() + " " + SPLITTED_BIOMETRICS_ATTENDANCE[3]);

                                 TimeSpan am_in_diff = AM_IN_ATT - AM_IN_SCHED;
                                 int am_late = ((int)am_in_diff.TotalMinutes > Properties.Settings.Default.MIN_LATE_GRACE_PERIOD)? (int)am_in_diff.TotalMinutes: 0;

                                 TimeSpan am_out_diff = AM_OUT_SCHED-AM_OUT_ATT;
                                 int am_ut = ((int)am_out_diff.TotalMinutes > 0) ? Math.Abs((int)am_out_diff.TotalMinutes) : 0;

                                 li.SubItems.Add((am_late+ am_ut).ToString());  

                             }
                             else if ((SPLITTED_BIOMETRICS_ATTENDANCE.Length >=2) && (SPLITTED_BIOMETRICS_ATTENDANCE.Length < 4) )
                             {
                                 IN_ATT = Convert.ToDateTime(d.ToShortDateString() + " " + SPLITTED_BIOMETRICS_ATTENDANCE[0]);
                                 OUT_ATT = Convert.ToDateTime(d.ToShortDateString() + " " + SPLITTED_BIOMETRICS_ATTENDANCE[1]);
                              
                                 //IF THE ATTENDANCE IS IN-OUT ONLY
                                 //DETERMINE IF IT IS AM/PM
                                 if (IN_ATT.ToString("tt", CultureInfo.InvariantCulture) == "AM")
                                 {
                                     //li.SubItems.Add("ATTENDANCE IS AM_ONLY");
                                     //CHECK FOR HOURS_IN_SERVICE

                                     TimeSpan in_diff = IN_ATT - AM_IN_SCHED;

                                     int in_late = ((int)in_diff.TotalMinutes > Properties.Settings.Default.MIN_LATE_GRACE_PERIOD) ? (int)in_diff.TotalMinutes : 0;


                                     TimeSpan HOURS_IN_SERVICE = OUT_ATT.Subtract(AM_IN_SCHED);
                                     
                                     //CREATE A TIME_SPAN (1 HOUR LUNCH BREAK)
                                     TimeSpan LUNCH_BREAK = TimeSpan.FromHours(1);

                                     //SUBTRACT LUNCH BREAK FROMT HE HOURS_IN_SERVICE
                                     li.SubItems.Add("TOTAL_HOURS : " + HOURS_IN_SERVICE.Subtract(LUNCH_BREAK).ToString());
                                    

                                 }
                                 else {
                                     li.SubItems.Add("ATTENDANCE IS PM_ONLY");
                                     //CHECK FOR HOURS_IN_SERVICE
                                 };
                                            
                             }














                         }
                         else if (SPLITTED_SCHEDULE_ID.Length == 4){

                             //THIS WILL EXECUTE IF EMPLOYEE SCHEDULE IS LIKE 8-0-12-0
                             //LIKE TIME-IN, TIME-OUT KIND OF SCHEDULE
                             li.SubItems.Add("SCHEDULE IS NOT SET TO TIME-IN, TIME-OUT, TIME-IN, TIME-OUT");


                         }
                         else {
                             //IF NO SCHEDULE FOR THIS DAY
                             //YET THERE IS AN ATTENDANCE
                             li.SubItems.Add("NO SCHEDULE FOR THIS DAY, CHECKING FOR OVERTIME...");
                         }
                        
                      

                        //====================================================//end


                        lbattendance.Items.Add(li);
                        ctr++;
                    }
                }
                else
                {
                    lbattendance.Items.Add("No Attendance found...");
                }//END IF ATTENDANCE != NULL

                lblaction.Text = "completed...";
                pb.Value = pb.Value + 20;
                lblaction.Text = "retrieving employee schedule...";


                TimeSpan span = TimeSpan.FromMinutes(TOTAL_LATES_FOR_THIS_CUTOFF);
                int total_hours_late=(int)span.TotalHours;
                
                lbltotallate.Text =(total_hours_late > 1)? total_hours_late.ToString() + " Hours " + span.Minutes.ToString() + " Minutes" :  total_hours_late.ToString() + " Hour " + span.Minutes.ToString() + " Minutes";
               

                //bgwschedule.RunWorkerAsync();

            }//END IF DBCON.DISCONNECT                               
        }















   
    }   
}
