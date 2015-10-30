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

namespace MMG_PIAPS.userctrl.loan
{
    public partial class loan_salary_new : UserControl
    {

        private string LOAN_TYPE = "SALARY";

        private decimal ANNUAL_INTEREST_RATE = 0;
        private decimal MAXIMUM_ALLOWED_LOAN = 0; //maximum loanable amount
        private decimal MAXIMUM_ALLOWED_AMORT_PERIOD = 0;//maximum amortization period
        private decimal MINIMUM_SHARED_CAPITAL = 0;//capital that is not loanable
        private decimal MINIMUM_SHARED_CAPITAL_TO_AVAIL_LOAN = 0;//minimum capital to avail loan
        private decimal PERCENTAGE_TOGET_LOANABLE_AMOUNT = 0;//PERCENTAGE TO GET LOANABLE AMOUNT
        private decimal PERCENTAGE_OFLOAN_TO_CBU = 0;// THE LOANABLE AMOUNT WILL BE DEDUCTED TO ADD TO CBU
        private decimal LATEST_MICRO_LOAN = 0;//THE LATEST MICRO LOAN OF A MEMBER
        private decimal LATEST_MICRO_LOAN_TOTAL_PAYMENT = 0;//total payment for the latest micro loan.
        private decimal UNPAID_BALANCE_TO_DATE = 0;//unpaid balance of a member
        private decimal ML_CONTROL_NUMBER = 0;
        private decimal SL_CONTROL_NUMBER = 0;



        private decimal SELECTED_AMORTIZATION = 0;
        private string SELECTED_PAYMENT_PERIOD = "";
        private string SELECTED_COLLECTION_DAY = "";
        private decimal APPLIED_LOAN_AMOUNT = 0;
        private decimal AUTO_CREDIT_TO_CBU = 0;
        private decimal NET_PROCEEDS = 0;
        private decimal INTEREST_ON_PRINCIPAL = 0;
        private decimal AMORTIZATION_ON_PRINCIPAL = 0;
        private decimal AMORTIZATION_ON_INTEREST = 0;
        private decimal TOTAL_AMORTIZATION = 0;



        Employee applicant = new Employee();
        Employee comaker = new Employee();

        Loan l = new Loan();

        public loan_salary_new()
        {
            InitializeComponent();
        }








        private void loan_new_Load(object sender, EventArgs e)
        {

            //interest rate as MicroLoan
            ANNUAL_INTEREST_RATE = l.GET_SALARY_LOAN_ANNUAL_INTEREST_RATE();
            //yung hindi pwdeng utangin 
            
            SL_CONTROL_NUMBER = l.GET_SALARY_LOAN_COUNTER();


            lblapplicationno.Text = "SL-" + DateTime.Now.Month.ToString("00") + "-" + SL_CONTROL_NUMBER.ToString("000") + "-" + DateTime.Now.ToString("yy");


            ANNUAL_INTEREST_RATE = l.GET_SALARY_LOAN_ANNUAL_INTEREST_RATE();
          
            label1.Text += "- with ANNUAL_INTEREST_RATE of : " + ANNUAL_INTEREST_RATE.ToString("0.0%");



            applicant.LoadRegularEmployee(cboemp);
            applicant.LoadRegularEmployee(cboComaker);       
          
       
           
        }








        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

      
        private void cboemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtinterest.Text = "";
            txtinterest_amort.Text = "";
            txtprincipal.Text = "";
            txtprincipal_amort.Text = "";
            txttotal_amort.Text = "";
            MAXIMUM_ALLOWED_AMORT_PERIOD = 0;
            MAXIMUM_ALLOWED_LOAN = 0;
            txtbalance.Text = "";
            cbopayment_mode.Text = "";
            cbocollection_day.Text = "";
            cboamortization_period.Text = "";
            txtnetproceeds.Text = "";


            if (cboemp.Text != "")
            {
                String[] c = cboemp.Text.ToString().Split('-');
                String id = c[1] + "-" + c[2];
                Employee emp2 = new Employee();
                emp2.empid = id;

               applicant = emp2.SELECT_BY_ID();
                


                //GET LATEST BASIC SAL
                decimal BASIC_PAY = applicant.GET_BASIC_PAY();

                //emp1.SELECT_BY_ID();                                
                applicant.GET_IMAGE_BY_ID();






                String pos = (applicant.GET_CURRENT_POSITION() != "") ? applicant.position.ToString() : "NO_POSITION_INDICATED";
                lblemp.Text = applicant.lname.ToUpper() + ", " + applicant.fname.ToUpper() + " " + applicant.mname.ToUpper() + " - " + pos;


                //WHEN WAS THE EMPLOYEE BECAME REGULAR?
                DateTime regularization_date = applicant.GET_REGULAR_STATUS_DATE();
                int months_as_regular = Global.GetMonths(regularization_date, DateTime.Now);

                //DISPLAY REGULARIZATION DATE
                //lblemployement.Text = "BECAME REGULAR SINCE :" + regularization_date.ToShortDateString() + "   TOTAL MONTHS_IN_SEVICE AS REGULAR : " + months_as_regular.ToString();
                //lblloancategory.Text = "";

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
               // lblloancategory.Text = "MAXIMUM_ALLOWED_AMOUNT : " + MAXIMUM_ALLOWED_LOAN.ToString("#,##0.00") + " MAXIMUM_AMORTIZATION_PERIOD : " + MAXIMUM_ALLOWED_AMORT_PERIOD.ToString();
                //nmamortperiod.Maximum = MAXIMUM_ALLOWED_AMORT_PERIOD;
                //nmamortperiod.Value = nmamortperiod.Maximum;

                if (applicant.pic != null)
                {
                    MemoryStream ms = new MemoryStream(applicant.pic);
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

        private void cboamortization_period_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtprincipal.Text != "")
            {
                APPLIED_LOAN_AMOUNT = Convert.ToDecimal(txtprincipal.Text);
                //txtprincipal.Text = String.Format("{0:C2}", APPLIED_LOAN_AMOUNT );
                String[] c = cboamortization_period.Text.Split('-');
                SELECTED_AMORTIZATION = Convert.ToDecimal(c[0]);

                INTEREST_ON_PRINCIPAL = ((ANNUAL_INTEREST_RATE / 12) * SELECTED_AMORTIZATION) * APPLIED_LOAN_AMOUNT;
                txtinterest.Text = INTEREST_ON_PRINCIPAL.ToString("####.##");

                AMORTIZATION_ON_PRINCIPAL = APPLIED_LOAN_AMOUNT / SELECTED_AMORTIZATION;
                txtprincipal_amort.Text = AMORTIZATION_ON_PRINCIPAL.ToString("###0.00");


                AMORTIZATION_ON_INTEREST = INTEREST_ON_PRINCIPAL / SELECTED_AMORTIZATION;
                txtinterest_amort.Text = AMORTIZATION_ON_INTEREST.ToString("###0.00");

                TOTAL_AMORTIZATION = AMORTIZATION_ON_INTEREST + AMORTIZATION_ON_PRINCIPAL;
                txttotal_amort.Text = TOTAL_AMORTIZATION.ToString("###0.00");

              
                decimal bal;
                if ((txtbalance.Text != "") && (Decimal.TryParse(txtbalance.Text.ToString(), out bal)))
                {
                    NET_PROCEEDS = (bal != 0) ? APPLIED_LOAN_AMOUNT - bal: APPLIED_LOAN_AMOUNT;
                }
                else
                {
                    NET_PROCEEDS = APPLIED_LOAN_AMOUNT;
                }

                txtnetproceeds.Text = NET_PROCEEDS.ToString("###0.00");

            }
        }

        private void btnComputeNetProceeds_Click(object sender, EventArgs e)
        {
            if (txtprincipal.Text != "")
            {
                APPLIED_LOAN_AMOUNT = Convert.ToDecimal(txtprincipal.Text);
                //txtprincipal.Text = String.Format("{0:C2}", APPLIED_LOAN_AMOUNT );
                String[] c = cboamortization_period.Text.Split('-');
                SELECTED_AMORTIZATION = Convert.ToDecimal(c[0]);

                INTEREST_ON_PRINCIPAL = ((ANNUAL_INTEREST_RATE / 12) * SELECTED_AMORTIZATION) * APPLIED_LOAN_AMOUNT;
                txtinterest.Text = INTEREST_ON_PRINCIPAL.ToString("####.##");

                AMORTIZATION_ON_PRINCIPAL = APPLIED_LOAN_AMOUNT / SELECTED_AMORTIZATION;
                txtprincipal_amort.Text = AMORTIZATION_ON_PRINCIPAL.ToString("###0.00");


                AMORTIZATION_ON_INTEREST = INTEREST_ON_PRINCIPAL / SELECTED_AMORTIZATION;
                txtinterest_amort.Text = AMORTIZATION_ON_INTEREST.ToString("###0.00");

                TOTAL_AMORTIZATION = AMORTIZATION_ON_INTEREST + AMORTIZATION_ON_PRINCIPAL;
                txttotal_amort.Text = TOTAL_AMORTIZATION.ToString("###0.00");


                decimal bal;
                if ((txtbalance.Text != "") && (Decimal.TryParse(txtbalance.Text.ToString(), out bal)))
                {
                    NET_PROCEEDS = (bal != 0) ? APPLIED_LOAN_AMOUNT - bal : APPLIED_LOAN_AMOUNT;
                }
                else
                {
                    NET_PROCEEDS = APPLIED_LOAN_AMOUNT;
                }

                txtnetproceeds.Text = NET_PROCEEDS.ToString("###0.00");

            }
        }

        private void cboComaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboComaker.Text != "")
            {
                String[] c = cboComaker.Text.ToString().Split('-');
                String id = c[1] + "-" + c[2];
                Employee emp2 = new Employee();
                emp2.empid = id;

                comaker = emp2.SELECT_BY_ID();



                //GET LATEST BASIC SAL
                decimal BASIC_PAY = comaker.GET_BASIC_PAY();

                //emp1.SELECT_BY_ID();                                
                comaker.GET_IMAGE_BY_ID();






                String pos = (comaker.GET_CURRENT_POSITION() != "") ? comaker.position.ToString() : "NO_POSITION_INDICATED";
                lblcomaker.Text = comaker.lname.ToUpper() + ", " + comaker.fname.ToUpper() + " " + comaker.mname.ToUpper() + " - " + pos;


                //WHEN WAS THE EMPLOYEE BECAME REGULAR?
                DateTime regularization_date = comaker.GET_REGULAR_STATUS_DATE();
                int months_as_regular = Global.GetMonths(regularization_date, DateTime.Now);

                //DISPLAY REGULARIZATION DATE
                //lblemployement.Text = "BECAME REGULAR SINCE :" + regularization_date.ToShortDateString() + "   TOTAL MONTHS_IN_SEVICE AS REGULAR : " + months_as_regular.ToString();
                //lblloancategory.Text = "";

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
                //txtprincipal.Text = MAXIMUM_ALLOWED_LOAN.ToString("0.00");
                // lblloancategory.Text = "MAXIMUM_ALLOWED_AMOUNT : " + MAXIMUM_ALLOWED_LOAN.ToString("#,##0.00") + " MAXIMUM_AMORTIZATION_PERIOD : " + MAXIMUM_ALLOWED_AMORT_PERIOD.ToString();
                //nmamortperiod.Maximum = MAXIMUM_ALLOWED_AMORT_PERIOD;
                //nmamortperiod.Value = nmamortperiod.Maximum;

                if (comaker.pic != null)
                {
                    MemoryStream ms = new MemoryStream(applicant.pic);
                    pbcomaker.Image = Image.FromStream(ms);
                    pbcomaker.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbcomaker.Image = Properties.Resources.noimagefound;
                    pbcomaker.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

       













    }
}
