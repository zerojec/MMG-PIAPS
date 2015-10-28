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

namespace MMG_PIAPS.userctrl.loan
{
    public partial class loan_current_user_micro : UserControl
    {

        private decimal ANNUAL_INTEREST_RATE = 0;
        private decimal MAXIMUM_ALLOWED_LOAN = 0;
        private decimal MAXIMUM_ALLOWED_AMORT_PERIOD = 0;

        Member mem = new Member();

        Loan l = new Loan();

        public loan_current_user_micro()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }

        private void loan_current_user_micro_Load(object sender, EventArgs e)
        {
            txtinterest.Text = "";
            txtinterest_amort.Text = "";
            txtprincipal.Text = "";
            txtprincipal_amort.Text = "";
            txttotal_amort.Text = "";
            MAXIMUM_ALLOWED_AMORT_PERIOD = 0;
            MAXIMUM_ALLOWED_LOAN = 0;


         
           
        }
    }
}
