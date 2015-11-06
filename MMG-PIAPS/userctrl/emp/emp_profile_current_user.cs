﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using System.IO;
using MMG_PIAPS.forms.emp;
using MMG_PIAPS.modules;

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

            txttinno.Text = emp.tinno;
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

            //LOAD BENEFITS
            if (emp.benefits.Count > 0)
            {

                int ctr = 1;
                foreach (Benefit b in emp.benefits)
                {
                    decimal amount = b.GET_AMOUNT(emp.basic_pay);
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(b.code);
                    li.SubItems.Add(b.name_);
                    //li.SubItems.Add();// GET THE BENEFIT IDENTIFICATION SUPPLIED BY INSTITUTIONS
                    li.SubItems.Add(amount.ToString("#,##0.00"));
                    lvbenefits.Items.Add(li);

                    ctr++;
                }
            }

            //LIST THE SCHEDULE
            ListViewItem lisched = new ListViewItem();
            
            if(emp.schedule!=null){
                lisched.Text = emp.schedule.mon;
                lisched.SubItems.Add(emp.schedule.tue);
                lisched.SubItems.Add(emp.schedule.wed);
                lisched.SubItems.Add(emp.schedule.thu);
                lisched.SubItems.Add(emp.schedule.fri);
                lisched.SubItems.Add(emp.schedule.sat);
                lisched.SubItems.Add(emp.schedule.sun);
                lvsched.Items.Add(lisched);
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.emp = Global.CURRENT_USER;
            frm.ShowDialog();

        }

        private void btllogout_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Please confirm logout.","Logout?",MessageBoxButtons.YesNo)== DialogResult.Yes){
                Global.CURRENT_USER.Logout();
            }
        }

       



    
      


    }
}
