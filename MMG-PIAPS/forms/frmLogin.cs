using MMG_PIAPS.classes;
using MMG_PIAPS.forms;
using MMG_PIAPS.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            Global.CURRENT_USER = new Employee();
            //Global.CREATE_JECBASCO();
        
        }      
        private void txtid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("Return"))
            {
                txtpassword.Focus();
            }
        }


        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void tztpassword_KeyDown(object sender, KeyEventArgs e)
        {

           



           if (e.KeyCode.ToString().Equals("Return"))
            {

                Employee emp, emp1 = new Employee();
                emp1.empid = txtid.Text;                
                String hash;
                using (MD5 md5Hash = MD5.Create())
                {               
                    hash = Global.GetMd5Hash(md5Hash, txtpassword.Text);
                }

                emp1.password = hash;
                emp = emp1.SELECT_BY_IDPASS();

                //MessageBox.Show(hash);

                if (emp != null)
                {


                    Global.CURRENT_USER.empid = emp.empid;
                    Global.CURRENT_USER = emp;
                    Global.CURRENT_USER.pic = emp.GET_IMAGE_BY_ID();
                    Global.CURRENT_USER.basic_pay = emp.GET_BASIC_PAY();
                    Global.CURRENT_USER.emp_status = emp.GET_EMPLOYMENT_STATUS();
                    Global.CURRENT_USER.position = emp.GET_CURRENT_POSITION();
                    Global.CURRENT_USER.branch = emp.GET_BRANCH_ASSIGNMENT();

                    //CREATE A RESTRICTION OBJECT              
                    Emp_Restriction r = new Emp_Restriction();
                    //SET CURRENT USER RESTRICTION 
                    r.empid = Global.CURRENT_USER.empid;
                    Global.CURRENT_USER.restriction = r.SELECT_BY_ID();
                    Global.CURRENT_USER.LIST_BENEFITS();


                    //GET CURRENT USER LATEST SCHEDULE
                    Emp_Sched es = new Emp_Sched();
                    es.empid = Global.CURRENT_USER.empid;
                    Global.CURRENT_USER.schedule = es.SELECT_BY_EMPID();

                    Global.CURRENT_USER.ISLOGGEDIN = true;

                    frmMain f = new frmMain();
                    f.Show();

                    this.Hide();

                }
                else {
                    MessageBox.Show("Nothing found");
                }


            }
        }
    }
}
