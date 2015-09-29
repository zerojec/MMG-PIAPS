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

namespace MMG_PIAPS.userctrl.emp
{
    public partial class emp_profile_current_user : UserControl
    {

        public Employee emp = new Employee();
        public emp_profile_current_user()
        {
            InitializeComponent();
        }

        private void emp_profile_current_user_Load(object sender, EventArgs e)
        {


            txtid.Text = emp.empid;
            txtfname.Text = emp.fname;
            txtlname.Text = emp.lname;
            txtmname.Text = emp.mname;

            txtaddress.Text = emp.address;
            txtbasicpay.Text = "";// emp.basic_pay.ToString();
            txtcontactno.Text = emp.contactno;

            cbogender.Text = emp.gender;
            cbobranch.Text = emp.branch;
            cboemploymentstatus.Text = emp.emp_status;
            cbopositions.Text = emp.position;

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

        private void btnViewSal_MouseDown(object sender, MouseEventArgs e)
        {
            txtbasicpay.Text = emp.basic_pay.ToString();
        }



        private void btnViewSal_MouseUp(object sender, MouseEventArgs e)
        {
            txtbasicpay.Text = "";
        }

       



    
      


    }
}
