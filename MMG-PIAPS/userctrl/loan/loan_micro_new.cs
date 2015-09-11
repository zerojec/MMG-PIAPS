using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

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

        }
    }
}
