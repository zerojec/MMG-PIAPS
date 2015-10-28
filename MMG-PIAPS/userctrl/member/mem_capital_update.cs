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

namespace MMG_PIAPS.userctrl.member_capital
{
    public partial class mem_capital_update : UserControl
    {





        public Member mem = new Member();
        




        public mem_capital_update()
        {
            InitializeComponent();
        }





        private void mem_capital_ctrl_Load(object sender, EventArgs e)
        {
            LoadPaidUpReference();

            lblMemberNamePos.Text = mem.fullname + " - " + mem.occupation;
            txtMemberID.Text = mem.memid;
            //GET MEMBER CURRENT TOTAL PAID-UP CAPITAL
            txtCurrentPaidUp.Text = "";

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



            Member_Capital mc = new Member_Capital();
            mc.memid = mem.memid;
            txtCurrentPaidUp.Text = mc.GET_CURRENT_PAID_UP_CAPITAL().ToString("#,##0.00");

            mc.LoadMembersCapitals(lstTransactionList);


        }





        void LoadPaidUpReference()
        {
            foreach (string l in Properties.Settings.Default.PAID_UP_REFERENCE)
            {
                cboPaidUpRef.Items.Add(l);
            }
        }




        private void btnsave_Click(object sender, EventArgs e)
        {
            Member_Capital mc = new Member_Capital();
            mc.memid = mem.memid;
            mc.paid_up_ref = cboPaidUpRef.Text;
            mc.paid_up_capital = Convert.ToDecimal(txtInput.Text);
            mc.date_updated = dtupdate.Value;
            mc.transaction_type = (rdbCredit.Checked == true) ? "CREDIT" : "DEBIT";
            mc.paid_up_explanation = "UPDATE TO PAID_UP_CAPITAL";

            if (mc.save()) {
                MessageBox.Show("Successful", "Save");
            }else{
                MessageBox.Show("There was a problem updating paid-up capital", "Saving Failed");
            }
        }
    }
}
