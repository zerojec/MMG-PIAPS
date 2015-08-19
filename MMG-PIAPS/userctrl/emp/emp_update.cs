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
using MMG_PIAPS.forms.emp;

namespace MMG_PIAPS.userctrl.emp
{
    public partial class emp_update : UserControl
    {

        public Employee emp = new Employee();

        public emp_update()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

        private void emp_update_Load(object sender, EventArgs e)
        {

            Branch b = new Branch();
            b.LoadBranches(cbobranch);


            Position p = new Position();
            p.LoadPositions(cbopositions);
            
            
            
            txtid.Text = emp.empid;
            txtfname.Text = emp.fname;
            txtlname.Text = emp.lname;
            txtmname.Text = emp.mname;
            
            txtaddress.Text = emp.address;
            txtbasicpay.Text = emp.basic_pay.ToString();
            txtcontactno.Text = emp.contactno;

            cbogender.Text = emp.gender;
            cbobranch.Text = emp.branch;
            cboemploymentstatus.Text = emp.emp_status;
            cbopositions.Text = emp.position;

            dtBday.Value = emp.birthdate;
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

        }// end


       


      

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.empid = txtid.Text;
            emp.fname = txtfname.Text;
            emp.lname = txtlname.Text;
            emp.mname = txtmname.Text;
            emp.gender = cbogender.Text;
            emp.birthdate = dtBday.Value;
            emp.contactno = txtcontactno.Text;
            emp.address = txtaddress.Text;
            emp.position = cbopositions.Text;
            emp.basic_pay = Convert.ToDecimal(txtbasicpay.Text);
            emp.date_hired = dtemploymentdate.Value;
           
            long filesize;
            MemoryStream mstream = new MemoryStream();
            pbEmpPic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Byte[] arrImage = mstream.GetBuffer();
            filesize = mstream.Length;
            
           

           

            if (pbEmpPic.Image != null && (arrImage != emp.pic))
            {
                emp.pic = arrImage;
            }


            if (emp.update())
            {
                MessageBox.Show("Successful", "Updating...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.Parent.Height = 0;
                this.Parent.Controls.Clear();
                this.Dispose();
            }
            else
            {
                Logger.WriteErrorLog(db.err.ToString());
                MessageBox.Show("Error : " + db.err.ToString(), "Updating...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
                           
        }

        private void btnChangePosition_Click(object sender, EventArgs e)
        {
            frmEmpPosition frm = new frmEmpPosition();
            frm.emp = emp;
            frm.SetDesktopLocation(MousePosition.X- frm.Width, MousePosition.Y);            
            frm.ShowDialog();

        }

        private void btnBasicPay_Click(object sender, EventArgs e)
        {
            frmEmpBasicPay frm = new frmEmpBasicPay();
            frm.emp = emp;
            frm.SetDesktopLocation(MousePosition.X - frm.Width, MousePosition.Y);
            frm.ShowDialog();
        }

        private void btnEmpStatus_Click(object sender, EventArgs e)
        {
            frmEmpStatus frm = new frmEmpStatus();
            frm.emp = emp;
            frm.SetDesktopLocation(MousePosition.X - frm.Width, MousePosition.Y);
            frm.ShowDialog();
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            frmEmpBranchAssignment frm = new frmEmpBranchAssignment();
            frm.emp = emp;
            frm.SetDesktopLocation(MousePosition.X - frm.Width, MousePosition.Y);
            frm.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pbEmpPic.Image = new Bitmap(open.FileName);
                // image file path
                //textBox1.Text = open.FileName;

                long filesize;
                MemoryStream mstream = new MemoryStream();
                pbEmpPic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] arrImage = mstream.GetBuffer();
                filesize = mstream.Length;
                // emp.pic = arrImage;
                MessageBox.Show(filesize.ToString());
            }
        }

        private void btnrotate_Click(object sender, EventArgs e)
        {
            pbEmpPic.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbEmpPic.Refresh();
        }
    }
}
