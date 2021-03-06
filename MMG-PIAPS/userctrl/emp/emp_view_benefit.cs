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

namespace MMG_PIAPS.userctrl.emp
{
    public partial class emp_view_benefit : UserControl
    {

        public Employee emp = new Employee();

        public emp_view_benefit()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

        private void emp_view_benefit_Load(object sender, EventArgs e)
        {

            String pos = (emp.GET_CURRENT_POSITION() != "") ? emp.position.ToString() : "NO_POSITION_INDICATED";
            lblemp.Text = emp.lname.ToUpper() + ", " + emp.fname.ToUpper() + " " + emp.mname.ToUpper() + " - " + pos;

          

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
            else {
               
            }
        }
        
    }
}
