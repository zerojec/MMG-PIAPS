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
    public partial class loan_current_user_salary : UserControl
    {


        private decimal ANNUAL_INTEREST_RATE = 0;
        private decimal MAXIMUM_ALLOWED_LOAN = 0;
        private decimal MAXIMUM_ALLOWED_AMORT_PERIOD = 0;
        private string LOAN_TYPE = "SALARY";


        Employee emp = new Employee();

        Loan l = new Loan();


        public loan_current_user_salary()
        {
            InitializeComponent();
        }

        private void loan_current_user_salary_Load(object sender, EventArgs e)
        {
            ANNUAL_INTEREST_RATE = l.GET_SALARY_LOAN_ANNUAL_INTEREST_RATE();

            DataTable dt = l.SELECT_SALARY_LOAN_BRACKET();

            lstloanbracket.Items.Add("=======Loan Guides=======");
            foreach (DataRow r in dt.Rows)
            {
                lstloanbracket.Items.Add(r["name_"].ToString() + " - [" + r["allowed_basic_sal_min"].ToString() + "-" + r["allowed_basic_sal_max"].ToString() + " MONTHS of BASIC_SALARY]");
            }

            txtinterest.Text = "";
            txtinterest_amort.Text = "";
            txtprincipal.Text = "";
            txtprincipal_amort.Text = "";
            txttotal_amort.Text = "";
            MAXIMUM_ALLOWED_AMORT_PERIOD = 0;
            MAXIMUM_ALLOWED_LOAN = 0;

            decimal BASIC_PAY = Global.CURRENT_USER.GET_BASIC_PAY();

                       //WHEN WAS THE EMPLOYEE BECAME REGULAR?
            DateTime regularization_date = Global.CURRENT_USER.GET_REGULAR_STATUS_DATE();
            int months_as_regular = Global.GetMonths(regularization_date, DateTime.Now);

            //DISPLAY REGULARIZATION DATE
            lblemployement.Text = "BECAME REGULAR SINCE :" + regularization_date.ToShortDateString() + "   TOTAL MONTHS_IN_SEVICE AS REGULAR : " + months_as_regular.ToString();
            lblloancategory.Text = "";




            //DETERMINE HOW MUCH LOAN IS ALLOWED FOR THIS CERTAIN EMPLOYEE
            //ACCORDING TO HIS/HER BASIC PAY
            //MessageBox.Show(months_as_regular + " - " + BASIC_PAY.ToString());
              
            if ((months_as_regular >= 6) && (months_as_regular <= 12))
            {
                MAXIMUM_ALLOWED_LOAN = 2 * BASIC_PAY;
                MAXIMUM_ALLOWED_AMORT_PERIOD = 6;
            }
            else if ((months_as_regular > 12) && (months_as_regular <= 24))
            {
                MAXIMUM_ALLOWED_LOAN = 4 * BASIC_PAY;
                MAXIMUM_ALLOWED_AMORT_PERIOD = 24;
            }
            else if (months_as_regular > 24)
            {
                MAXIMUM_ALLOWED_LOAN = 6 * BASIC_PAY;
                MAXIMUM_ALLOWED_AMORT_PERIOD = 24;

            }
            txtprincipal.Text = MAXIMUM_ALLOWED_LOAN.ToString("0.00");
            lblloancategory.Text = "MAXIMUM_ALLOWED_AMOUNT : " + MAXIMUM_ALLOWED_LOAN.ToString("#,##0.00") + " MAXIMUM_AMORTIZATION_PERIOD : " + MAXIMUM_ALLOWED_AMORT_PERIOD.ToString();
            nmamortperiod.Maximum = MAXIMUM_ALLOWED_AMORT_PERIOD;
            nmamortperiod.Value = nmamortperiod.Maximum;


        }

        private void nmamortperiod_ValueChanged(object sender, EventArgs e)
        {
            txttotal_amort.Text = "";
            txtinterest.Text = "";
            try
            {
                decimal principal = Convert.ToDecimal(txtprincipal.Text);
                decimal amortization_period = nmamortperiod.Value;
                decimal interest_rate = (ANNUAL_INTEREST_RATE / 12) * amortization_period;
                decimal interest = principal * interest_rate;
                decimal amortization_on_principal = principal / amortization_period;
                decimal amortization_on_interest = interest / amortization_period;

                txtinterest.Text = interest.ToString("0.00");
                txtinterest_amort.Text = amortization_on_interest.ToString("0.00");
                txtprincipal_amort.Text = amortization_on_principal.ToString("0.00");
                txttotal_amort.Text = (amortization_on_principal + amortization_on_interest).ToString("0.00");

            }
            catch (Exception err)
            {
                db.err = err;
                Logger.WriteErrorLog("LOAN MODULE ERROR :" + err.Message);
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

            Loan l = new Loan();
            l.empid = Global.CURRENT_USER.empid;
            l.principal = Convert.ToDecimal(txtprincipal.Text);
            l.interest = Convert.ToDecimal(txtinterest.Text);
            l.amortization_on_interest = Convert.ToDecimal(txtinterest_amort.Text);
            l.amortization_on_principal = Convert.ToDecimal(txtprincipal_amort.Text);
            l.loantype = LOAN_TYPE;
            l.amortization_period = (Int32)nmamortperiod.Value;
            l.filingdate = dtfilingdate.Value;


            if (l.save())
            {
                MessageBox.Show("Successful");
            }
            else
            {
                MessageBox.Show("There was a problem saving leave :\n" + db.err.Message);
            }
        }
    }
}
