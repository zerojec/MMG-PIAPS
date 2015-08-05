using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using MMG_PIAPS.modules;
using System.IO;

namespace MMG_PIAPS.userctrl.emp
{
    public partial class emp_new : UserControl
    {
        public emp_new()
        {
            InitializeComponent();
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

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();           
            this.Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
                Employee emp = new Employee();
                emp.empid= txtid.Text;
                emp.fname= txtfname.Text;
                emp.lname = txtlname.Text;
                emp.mname = txtmname.Text;
                emp.gender = cbogender.Text;
                emp.birthdate = dtBday.Value;
                emp.contactno = txtcontactno.Text;
                emp.address = txtaddress.Text;
                emp.position = cbopositions.Text;
                emp.basic_pay = Convert.ToDecimal(txtbasicpay.Text);
                emp.date_hired = dtemploymentdate.Value;
                emp.emp_status = cboemploymentstatus.Text;
                emp.branch = cbobranch.Text;
                emp.position = cbopositions.Text;


                if (pbEmpPic.Image != null){
                    long filesize;
                    MemoryStream mstream = new MemoryStream();
                    pbEmpPic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Byte[] arrImage = mstream.GetBuffer();
                    filesize = mstream.Length;
                    emp.pic = arrImage;
                }
               
             
                if (emp.save()) {
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


        public void LoadBranches() {
            Branch b = new Branch();
            DataTable dt = new DataTable();
            dt = b.SELECT_ALL();

            foreach (DataRow r in dt.Rows)
            {
                cbobranch.Items.Add(r["branch"].ToString());
            }
        }


        public void LoadPositions()
        {
            Position p= new Position();
            DataTable dt = new DataTable();
            dt = p.SELECT_ALL();

            foreach (DataRow r in dt.Rows)
            {
                cbopositions.Items.Add(r["positionname"].ToString());
            }
        }

        private void emp_new_Load(object sender, EventArgs e)
        {
            LoadBranches();
            LoadPositions();
        }

        private void btnrotate_Click(object sender, EventArgs e)
        {
            pbEmpPic.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbEmpPic.Refresh();

        }          
    }
}
