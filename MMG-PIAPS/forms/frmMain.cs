using MMG_PIAPS.classes;
using MMG_PIAPS.modules;
using MMG_PIAPS.userctrl;
using MMG_PIAPS.userctrl.attendance;
using MMG_PIAPS.userctrl.benefit;
using MMG_PIAPS.userctrl.emp;
using MMG_PIAPS.userctrl.emp_benefit;
using MMG_PIAPS.userctrl.emp_restriction;
using MMG_PIAPS.userctrl.emp_sched;
using MMG_PIAPS.userctrl.leave;
using MMG_PIAPS.userctrl.loan;
using MMG_PIAPS.userctrl.member;
using MMG_PIAPS.userctrl.passslip;
using MMG_PIAPS.userctrl.schedule;
using MMG_PIAPS.userctrl.service_request;
using MMG_PIAPS.userctrl.supply_request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.forms
{
    public partial class frmMain : Form
    {
        public int num = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

      

    

        private void LOAD_EMPLOYEE_CONTROL() {
            pnlops.Controls.Clear();
            emp_ctrl c = new emp_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            String Fullname=Global.CURRENT_USER.lname + ", " + Global.CURRENT_USER.fname;
            lblfname.Text = Global.CURRENT_USER.fname;
            lbllname.Text = Global.CURRENT_USER.lname;
            lblmname.Text = Global.CURRENT_USER.mname;
            lbladdress.Text = Global.CURRENT_USER.address;
            lblbirthday.Text = Global.CURRENT_USER.birthdate.ToShortDateString();            
            lblcontactno.Text = Global.CURRENT_USER.contactno;
            lblgender.Text = Global.CURRENT_USER.gender;
            lblposition.Text = Global.CURRENT_USER.position;
            lblbranch.Text = Global.CURRENT_USER.branch;

            lblCurrentUser.Text = Fullname;
            lblCurrentUserPosition.Text = Global.CURRENT_USER.position;
            
            //lblcapitalinvestment.Text=  Global.CURRENT_USER.capitalinvestment //FORWARDED CAPITAL AS OF SOFTWARE IMPLEMENTATION
            //lbldate.Text=  Global.CURRENT_USER.membershipdate //WHEN DID HE?SHE BECAME AN MMG MEMBER
            //lblstatus.Text = Global.CURRENT_USER.membershipstatus;//IN_GOOD_STANDING ? NOT_IN_GOOD_STANDING
            //lbltype.Text = Global.CURRENT_USER.membershiptype;    //REGULAR?ASSOCIATE
            if(Global.CURRENT_USER.pic!=null){
                MemoryStream ms = new MemoryStream(Global.CURRENT_USER.pic);
                CurrUserPic.Image = Image.FromStream(ms);
             ms.Close();
                CurrUserPic.SizeMode = PictureBoxSizeMode.Zoom;
            }else{    
                
                //CurrUserPic.SizeMode = PictureBoxSizeMode.Zoom;
            }


            //CREATE THE NECESSARY BUTTONS ACCORDING TO RESTRICTION
            CREATE_BUTTONS();
         
        }


        //CREATE THE NECESSARY BUTTONS ACCORDING TO RESTRICTION
        //FUNCTION DEFINITION
        private void CREATE_BUTTONS() {


            //IF CURRENT USER CAN VIEW_PROFILE
            if (Global.CURRENT_USER.restriction.CAN_VIEW_PROFILE)
            {               
                CreateThisButton(view_profile_Click, Image.FromHbitmap(Properties.Resources.eomployee_profile.GetHbitmap()), "Profile");                             
            }


            //IF CURRENT USER CAN VIEW ATTENDANCE
            if (Global.CURRENT_USER.restriction.CAN_VIEW_ATTENDANCE)
            {               
                CreateThisButton(view_attendance_Click, Image.FromHbitmap(Properties.Resources.attendance.GetHbitmap()), "Attendance");                             
            }




            //IF CURRENT USER CAN VIEW EMPLOYEE
            if (Global.CURRENT_USER.restriction.CAN_VIEW_EMPLOYEE)
            {               
                CreateThisButton(view_employee_Click, Image.FromHbitmap(Properties.Resources.employees.GetHbitmap()), "Employee");                             
            }




            //IF CURRENT USER CAN VIEW RESTRICTION
            if (Global.CURRENT_USER.restriction.CAN_VIEW_RESTRICTION)
            {
                CreateThisButton(view_restriction_Click, Image.FromHbitmap(Properties.Resources.user_restriction.GetHbitmap()), "Restrictions");                             
            }


            //IF CURRENT USER CAN VIEW LOAN
            if (Global.CURRENT_USER.restriction.CAN_VIEW_LOAN)
            {
                CreateThisButton(view_loan_Click, Image.FromHbitmap(Properties.Resources.loan.GetHbitmap()), "Loan");                             
            }


            //IF CURRENT USER CAN VIEW SCHEDULE
            if (Global.CURRENT_USER.restriction.CAN_VIEW_EMP_SCHEDULE)
            {
               CreateThisButton(view_emp_schedule_Click, Image.FromHbitmap(Properties.Resources.schedule.GetHbitmap()), "Schedule");                             
            }


            //IF CURRENT USER CAN VIEW LEAVE
            if (Global.CURRENT_USER.restriction.CAN_VIEW_LEAVE)
            {
               CreateThisButton(view_leave_Click, Image.FromHbitmap(Properties.Resources.leave.GetHbitmap()), "Leave");                             
            }

            //IF CURRENT USER CAN VIEW PASS SLIP
            if (Global.CURRENT_USER.restriction.CAN_VIEW_PASS_SLIP)
            {
               CreateThisButton(view_pass_slip_Click, Image.FromHbitmap(Properties.Resources.guard.GetHbitmap()), "Pass Slip");                             
            }


            //IF CURRENT USER CAN VIEW MEMBER
            if (Global.CURRENT_USER.restriction.CAN_VIEW_MEMBERS)
            {
               CreateThisButton(view_members_Click, Image.FromHbitmap(Properties.Resources.members.GetHbitmap()), "Members");                             
            }


            //IF CURRENT USER CAN VIEW SERVICE_REQUEST
            if (Global.CURRENT_USER.restriction.CAN_VIEW_SERVICE_REQUEST)
            {
               CreateThisButton(view_service_request_Click, Image.FromHbitmap(Properties.Resources.service_request.GetHbitmap()), "Service Request");                             
            }


            //IF CURRENT USER CAN VIEW SUPPLY_REQUEST
            if (Global.CURRENT_USER.restriction.CAN_VIEW_SUPPLY_REQUEST)
            {
                CreateThisButton(view_supply_request_Click, Image.FromHbitmap(Properties.Resources.supply_request.GetHbitmap()), "Supply Request");                             
            }
        }




        void CreateThisButton(EventHandler evt, Image img, String tooltip) {
            Button b = new Button();
            b.Dock = DockStyle.Top;
            b.Image = img;
            b.ImageAlign = ContentAlignment.MiddleCenter;
            b.Width = pnlbuttons.Width;
            b.Height = Properties.Settings.Default.MAIN_BUTTON_HEIGHT;
            b.BackColor = Color.White;
            b.Click += evt;//view_service_request_Click;
            pnlbuttons.Controls.Add(b);


            ToolTip t = new ToolTip();
            t.UseAnimation = true;
            t.IsBalloon = true;
            t.UseFading = true;
            t.InitialDelay = 1;
            t.SetToolTip(b, tooltip);
        }



        void view_supply_request_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            supply_request_current_user eu = new supply_request_current_user();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            pnlops.Controls.Add(eu);

            //throw new NotImplementedException();
        }

        void view_service_request_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            service_request_current_user eu = new service_request_current_user();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            pnlops.Controls.Add(eu);

            //throw new NotImplementedException();
        }


        void view_members_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            mem_ctrl eu = new mem_ctrl();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;            
            pnlops.Controls.Add(eu);

            //throw new NotImplementedException();
        }



        void view_profile_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            emp_profile_current_user eu = new emp_profile_current_user();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            eu.emp = Global.CURRENT_USER;
            pnlops.Controls.Add(eu);

            //throw new NotImplementedException();
        }

        void view_pass_slip_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            passslip_current_user eu = new passslip_current_user();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            pnlops.Controls.Add(eu);

            //throw new NotImplementedException();
        }

        void view_leave_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            leave_current_user eu = new leave_current_user();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            pnlops.Controls.Add(eu);

            //throw new NotImplementedException();
        }


        void view_emp_schedule_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            emp_sched_current_user eu = new emp_sched_current_user();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            pnlops.Controls.Add(eu);

            //throw new NotImplementedException();
        }


        void view_loan_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            loan_current_user eu = new loan_current_user();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            pnlops.Controls.Add(eu);

            //throw new NotImplementedException();
        }

        void view_restriction_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            emp_restriction_current_user eu = new emp_restriction_current_user();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            pnlops.Controls.Add(eu);
            //throw new NotImplementedException();
        }

        void view_employee_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            emp_ctrl eu = new emp_ctrl();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            pnlops.Controls.Add(eu);
            //throw new NotImplementedException();
        }



        void view_attendance_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            attendance_current_user eu = new attendance_current_user();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;            
            pnlops.Controls.Add(eu); 
            //throw new NotImplementedException();
        }

        void update_employee_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            emp_update eu = new emp_update();
            eu.Width = pnlops.Width;
            eu.Height = pnlops.Height;
            eu.emp = Global.CURRENT_USER;
            pnlops.Controls.Add(eu);          
            //throw new NotImplementedException();
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldbcon.Text = db.con.State.ToString();
            lblCurrentDateAndTime.Text = "Today is : " +  DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }


        public Image CurrUserImage
        {
            get { return CurrUserPic.Image; }
            set
            {
                //do some checks if neccessary
                CurrUserPic.Image = value;
            }
        }


        //==========================================================//
        //DELEGATE FOR FORM_TO_FORM PASSAGE OF DATA                 //
        //==========================================================//

        public delegate void ChangeFname(String n);
        public delegate void ChangeLname(String n);
        public delegate void ChangeMname(String n);
        public delegate void ChangeAddress(String n);
        public delegate void ChangeBirthday(DateTime n);


     

    
        private void LOAD_ATTENDANCE_CONTROL() {
            pnlops.Controls.Clear();
            attendance_ctrl c = new attendance_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

    

        private void templateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            sched_ctrl c = new sched_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            emp_sched_ctrl c = new emp_sched_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void benefitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void setEmployeesBenefitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            emp_benefit_ctrl c = new emp_benefit_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void viewBenefitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            benefit_ctrl c = new benefit_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void LOAD_PASS_SLIP_CONTROL(){
            pnlops.Controls.Clear();
            passslip_ctrl c = new passslip_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }


        private void LOAD_LEAVE_CONTROL() {
            pnlops.Controls.Clear();
            leave_ctrl c = new leave_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

  
        private void LOAD_LOAN_CONTROL() {
            pnlops.Controls.Clear();
            loan_ctrl c = new loan_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }


        private void LOAD_RESTRICTION_CONTROL() {
            pnlops.Controls.Clear();
            emp_restriction_ctrl c = new emp_restriction_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void dataImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnectXLS frm = new frmConnectXLS();
            frm.ShowDialog();
        }

   
        private void LOAD_MEMBER_CONTROL() {
            pnlops.Controls.Clear();
            mem_ctrl c = new mem_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }
    }
}
