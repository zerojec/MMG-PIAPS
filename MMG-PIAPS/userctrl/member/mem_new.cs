using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MMG_PIAPS.classes;
using MMG_PIAPS.modules;

namespace MMG_PIAPS.userctrl.member
{

    
    public partial class mem_new : UserControl
    {

        Member mem = new Member();


        public mem_new()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {


            Member m = new Member();
            m.memid = txtid.Text;
            m.fullname = txtlname.Text + ", " + txtfname.Text + " " + txtmname.Text;
         
            m.gender = cbogender.Text;
            m.birthdate = dtBday.Value;
            m.contactno = txtcontactno.Text;
            m.address = txtaddress.Text;
            m.occupation = txtoccupation.Text;
            m.status = "ACTIVE"; //STATUS = ACTIVE, STAFF, WITHDRAWN
            m.standing = "IN_GOOD_STANDING"; // STANDING = IN_GOO_STANDING, NOT_IN_GOOD_STANDING
            m.typeofmembership = cbomembershiptype.Text; // REGULAR, ASSOCIATE
            m.email = txtemail.Text;

            if (pbEmpPic.Image != null)
            {
                long filesize;
                MemoryStream mstream = new MemoryStream();
                pbEmpPic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] arrImage = mstream.GetBuffer();
                filesize = mstream.Length;
                m.pic = arrImage;
            }

            if(m.save()){
                    MessageBox.Show("Successful", "Saving...", MessageBoxButtons.OK,MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.Parent.Height = 0;
                    this.Parent.Controls.Clear();
                    this.Dispose();
            }
            else{
                Logger.WriteErrorLog(db.err.ToString());
                MessageBox.Show("Error : " + db.err.ToString() , "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

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
