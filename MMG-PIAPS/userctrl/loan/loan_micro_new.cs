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

namespace MMG_PIAPS.userctrl.loan
{
    public partial class loan_micro_new : UserControl
    {


        private decimal ANNUAL_INTEREST_RATE = 0;
        private decimal MAXIMUM_ALLOWED_LOAN = 0;
        private decimal MAXIMUM_ALLOWED_AMORT_PERIOD = 0;


        Member mem = new Member();

        Loan l = new Loan();





        public loan_micro_new()
        {
            InitializeComponent();
        }

        private void loan_micro_new_Load(object sender, EventArgs e)
        {
            ANNUAL_INTEREST_RATE = l.GET_MICRO_LOAN_ANNUAL_INTEREST_RATE();

            label1.Text += "- with ANNUAL_INTEREST_RATE of : " + ANNUAL_INTEREST_RATE.ToString("0.0%");

            mem.LoadMembers(cboMem);

        }

        private void cboMem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtinterest.Text = "";
            txtinterest_amort.Text = "";
            txtprincipal.Text = "";
            txtprincipal_amort.Text = "";
            txttotal_amort.Text = "";
            MAXIMUM_ALLOWED_AMORT_PERIOD = 0;
            MAXIMUM_ALLOWED_LOAN = 0;


            if (cboMem.Text != "")
            {
                String[] c = cboMem.Text.ToString().Split('-');
                String id = c[c.Length-2] + "-" + c[c.Length-1];
                Member m, m2 = new Member();
                //MessageBox.Show(id);
                m2.memid = id;
                m = m2.SELECT_BY_ID();
                m2.GET_IMAGE_BY_ID();
               
                lblmem.Text = m.fullname.ToString().ToUpper() + " - " + m.occupation.ToString();
                lblmemdata.Text = "MEMBER SINCE :" + m.acceptance_date.ToShortDateString();
                lblmemdata2.Text = "PAID-UP CAPITAL :" + m.GET_TOTAL_PAIDUP_CAPITAL();



                if (m2.pic != null)
                {
                    MemoryStream ms = new MemoryStream(m2.pic);
                    pb.Image = Image.FromStream(ms);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pb.Image = Properties.Resources.noimagefound;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }


            }



           


        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }
    }
}
