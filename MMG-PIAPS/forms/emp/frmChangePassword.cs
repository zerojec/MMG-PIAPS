using MMG_PIAPS.classes;
using MMG_PIAPS.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.forms.emp
{
    public partial class frmChangePassword : Form
    {

        public Employee emp = new Employee();

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
           

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txtretypepass.Text == "" && txtnewpass.Text == "") { return; }
            
            String oldpass = emp.password;
            String hash;

            using (MD5 md5Hash = MD5.Create())
            {
                hash = Global.GetMd5Hash(md5Hash, txtoldpass.Text);               
            }



           // MessageBox.Show(oldpass + "---------" + hash);
            if (hash != oldpass)
            {
                txtnewpass.Text = "";
                txtretypepass.Text = "";
                txtoldpass.Text = "";
                txtoldpass.BackColor = Color.Red;
            }
            else {
                txtoldpass.BackColor = Color.GreenYellow;

                if ((txtnewpass.Text != txtretypepass.Text) && (txtnewpass.Text!="" || txtretypepass.Text !=""))
                {
                    txtnewpass.Text = "";
                    txtretypepass.Text = "";
                    txtnewpass.BackColor = Color.Red;
                    txtretypepass.BackColor = Color.Red;
                }
                else {

                    txtnewpass.BackColor = Color.GreenYellow;
                    txtretypepass.BackColor = Color.GreenYellow;                   
                    emp.password = txtretypepass.Text;


                
                        if (emp.update_password())
                        {
                            MessageBox.Show("Password updated...");
                            
                            Global.CURRENT_USER.Logout();

                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("There was a problem updating your password : " + db.err.Message);
                        }
                 
                  

                }
            
            }

        }









        private void txtoldpass_TextChanged(object sender, EventArgs e)
        {
            txtoldpass.BackColor = Color.White;
        }

        private void txtnewpass_TextChanged(object sender, EventArgs e)
        {
            txtnewpass.BackColor = Color.White;
        }

        private void txtretypepass_TextChanged(object sender, EventArgs e)
        {
            txtretypepass.BackColor = Color.White;
        }
    }
}
