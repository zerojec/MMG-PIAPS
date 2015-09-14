using MMG_PIAPS.classes;
using MMG_PIAPS.modules;
using MMG_PIAPS.userctrl;
using MMG_PIAPS.userctrl.attendance;
using MMG_PIAPS.userctrl.benefit;
using MMG_PIAPS.userctrl.emp_benefit;
using MMG_PIAPS.userctrl.emp_restriction;
using MMG_PIAPS.userctrl.emp_sched;
using MMG_PIAPS.userctrl.leave;
using MMG_PIAPS.userctrl.loan;
using MMG_PIAPS.userctrl.passslip;
using MMG_PIAPS.userctrl.schedule;
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

      

        private void btnEmpolyee_Click(object sender, EventArgs e)
        {
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

        private void btnSchedule_Click(object sender, EventArgs e)
        {
           

        }

        private void btnEmployeeSchedule_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            attendance_ctrl c = new attendance_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void btnMembershipData_Click(object sender, EventArgs e)
        {

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

        private void btnPassSlip_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            passslip_ctrl c = new passslip_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void btnleave_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            leave_ctrl c = new leave_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();
            loan_ctrl c = new loan_ctrl();
            c.Width = pnlops.Width;
            c.Height = pnlops.Height;
            pnlops.Controls.Add(c);
        }

        private void btnRestrictions_Click(object sender, EventArgs e)
        {
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
    }
}
