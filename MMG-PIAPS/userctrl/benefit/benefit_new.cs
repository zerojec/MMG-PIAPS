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

namespace MMG_PIAPS.userctrl.benefit
{
    public partial class benefit_new : UserControl
    {
        public benefit_new()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Benefit b = new Benefit();
            b.code = txtcode.Text;
            b.name_ = txtname.Text;
            
            b.type_ = (rdbCompanyBenefit.Checked) ? "COMPANY_BENEFIT" :"PREMIUM";

            if (chkBracket.Checked)
            {
                b.amount_lookup = cboBracket.Text;
                b.amount = 0;
            }
            else
            {
                b.amount_lookup = "here";
                if (txtamount.Text != "")
                {
                    b.amount = Convert.ToDecimal(txtamount.Text);
                }
                else
                {
                    b.amount = 0;
                }
            }  
            //b.amount_lookup = txtamount_lookup.Text;
            

            if (b.save())
            {
                MessageBox.Show("Successful", "Save");
                this.Parent.Height = 0;
                this.Parent.Controls.Clear();
                this.Dispose();                
            }
            else {
                MessageBox.Show("There was a problem saving new benefit: \n" + db.err.Message);
                this.Parent.Height = 0;
                this.Parent.Controls.Clear();
                this.Dispose();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

        private void chkBracket_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBracket.Checked)
            {
                cboBracket.Text = "";
                cboBracket.Enabled = true;
                txtamount.Enabled = false;
            }
            else
            {
                cboBracket.Text = "";
                cboBracket.Enabled =false;
                txtamount.Enabled = true;
                
            }
        }

        private void rdbCompanyBenefit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompanyBenefit.Checked) {
                chkBracket.Checked = false;
                pnlbracket.Enabled = false;               
            }
        }

        private void rdbPremium_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPremium.Checked)
            {
                pnlbracket.Enabled = true;
            }
            else {
                pnlbracket.Enabled = false;
            }
        }

        private void benefit_new_Load(object sender, EventArgs e)
        {
            if (rdbPremium.Checked)
            {
                pnlbracket.Enabled = true;
            }
            else
            {
                pnlbracket.Enabled = false;
            }
        }
    }
}
