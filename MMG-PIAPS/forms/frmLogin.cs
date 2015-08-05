﻿using MMG_PIAPS.classes;
using MMG_PIAPS.forms;
using MMG_PIAPS.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        
        }      
        private void txtid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("Return"))
            {

                Employee emp, emp1 = new Employee();
                emp1.empid = txtid.Text;
                emp = emp1.SELECT_BY_ID();

                if (emp != null) {

                    Global.CURRENT_USER = emp;
                    Global.CURRENT_USER.pic = emp.GET_IMAGE_BY_ID();

                    frmMain f = new frmMain();
                    f.Show();
                    this.Hide();                
                }
                
               
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
