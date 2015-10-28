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

namespace MMG_PIAPS.userctrl.member
{
    public partial class mem_update : UserControl
    {
        public Member mem = new Member();
        
        public mem_update()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Member m = new Member();
            m.memid = txtid.Text;
            m.fullname = txtlname.Text;

            m.gender = cbogender.Text;
            m.birthdate = dtBday.Value;
            m.contactno = txtcontactno.Text;
            m.address = txtaddress.Text;
            m.occupation = txtoccupation.Text;         
            m.typeofmembership = cbomembershiptype.Text;
            m.email = txtemail.Text;
            m.tinno = txttinno.Text;


            if (pbMemPic.Image != null)
            {
                long filesize;
                MemoryStream mstream = new MemoryStream();
                pbMemPic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] arrImage = mstream.GetBuffer();
                filesize = mstream.Length;
                m.pic = arrImage;
            }

            if (m.update())
            {
                MessageBox.Show("Successful", "Updating...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.Parent.Height = 0;
                this.Parent.Controls.Clear();
                this.Dispose();
            }
            else
            {
                Logger.WriteErrorLog(db.err.ToString());
                MessageBox.Show("Error : " + db.err.ToString(), "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }




        private void mem_update_Load(object sender, EventArgs e)
        {
            txtaddress.Text = mem.address;
            txtcontactno.Text = mem.contactno;
            txtemail.Text = mem.email;
            txtlname.Text = mem.fullname;
            txtid.Text = mem.memid;
            txtoccupation.Text = mem.occupation;
            cbogender.Text = mem.gender;
            txttinno.Text = mem.tinno;




            if (mem.acceptance_date < dtpacceptancedate.MinDate) {
                dtpacceptancedate.Value = dtpacceptancedate.MinDate;
            }
            else
            {
                dtpacceptancedate.Value = mem.acceptance_date;
                cbomembershiptype.Text = mem.typeofmembership;
            }
           
            
            
            
            
            
            
            cbomembershiptype.Enabled = false;
            cbogender.Enabled = false;



            //LOAD PICTURE
            if (mem.pic != null)
            {
                MemoryStream ms = new MemoryStream(mem.pic);
                pbMemPic.Image = Image.FromStream(ms);
                pbMemPic.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {

                pbMemPic.Image = Properties.Resources.noimagefound;
                pbMemPic.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void cbomembershiptype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pbMemPic.Image = new Bitmap(open.FileName);
                // image file path
                //textBox1.Text = open.FileName;

                long filesize;
                MemoryStream mstream = new MemoryStream();
                pbMemPic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] arrImage = mstream.GetBuffer();
                filesize = mstream.Length;
                // emp.pic = arrImage;
               
            }
        }
    }
}
