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
        private decimal LATEST_SALARY_LOAN = 0;//THE LATEST MICRO LOAN OF A MEMBER
        private decimal LATEST_SALARY_LOAN_TOTAL_PAYMENT = 0;//total payment for the latest micro loan.
        private decimal UNPAID_BALANCE_TO_DATE = 0;//unpaid balance of a member
        private decimal ML_CONTROL_NUMBER = 0;
        private decimal SL_CONTROL_NUMBER = 0;

        private decimal COMAKERS_LATEST_SALARY_LOAN = 0;//THE LATEST MICRO LOAN OF A MEMBER
        private decimal COMAKERS_LATEST_SALARY_LOAN_TOTAL_PAYMENT = 0;//total payment for the latest micro loan.
      

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
        Loan PREV_LOAN = new Loan();


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
            cboprincipal.Text = "";
            txtprincipal_amort.Text = "";
            txttotal_amort.Text = "";
            MAXIMUM_ALLOWED_AMORT_PERIOD = 0;
            MAXIMUM_ALLOWED_LOAN = 0;
            txtbalance.Text = "";
            cbopayment_mode.Text = "";
            cbocollection_day.Text = "";
            cboamortization_period.Text = "";
            txtnetproceeds.Text = "";
            lbapplicantsdata.Items.Clear();
            lblatestloan.Items.Clear();            
            lbcomakersdata.Items.Clear();
            lbcomakerslatestloan.Items.Clear();

            if (cboemp.Text != "")
            {
                String[] c = cboemp.Text.ToString().Split('-');
                String id = c[1];
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
                lbapplicantsdata.Items.Add("EMPLOYEE INFORMATION");
                lbapplicantsdata.Items.Add("BECAME REGULAR SINCE :" + regularization_date.ToShortDateString());
                lbapplicantsdata.Items.Add("TOTAL MONTHS_IN_SEVICE AS REGULAR : " + months_as_regular.ToString());
                lbapplicantsdata.Items.Add("BASIC SALARY : " + BASIC_PAY.ToString("#,##0.00"));



                //DETERMINE HOW MUCH LOAN IS ALLOWED FOR THIS CERTAIN EMPLOYEE
                //ACCORDING TO HIS/HER BASIC PAY
                //MessageBox.Show(months_as_regular + " - " + BASIC_PAY.ToString());
                if ((months_as_regular >= 6) && (months_as_regular <= 12))
                {
                    MAXIMUM_ALLOWED_LOAN = 2 * BASIC_PAY;
                    MAXIMUM_ALLOWED_AMORT_PERIOD = 6;

                    iteratesalary(BASIC_PAY, cboprincipal, 2);
                    
                }
                else if ((months_as_regular > 12) && (months_as_regular <= 24))
                {
                    MAXIMUM_ALLOWED_LOAN = 4 * BASIC_PAY;                    
                    MAXIMUM_ALLOWED_AMORT_PERIOD = 24;
                    iteratesalary(BASIC_PAY, cboprincipal, 4);
                }
                else if (months_as_regular > 24)
                {
                    MAXIMUM_ALLOWED_LOAN = 6 * BASIC_PAY;
                    MAXIMUM_ALLOWED_AMORT_PERIOD = 24;
                    iteratesalary(BASIC_PAY, cboprincipal, 6);

                }





                //display latest loan

                l.empid = applicant.empid;

                Loan applicant_latest_loan = l.GET_LATEST_LOAN("SALARY");
                PREV_LOAN = applicant_latest_loan;
                // GET THE LATEST MICRO LOAN OF A MEMBER
                lblatestloan.Items.Add("LATEST MICRO LOAN");
                LATEST_SALARY_LOAN = (applicant_latest_loan != null) ? applicant_latest_loan.principal : 0;

                if (LATEST_SALARY_LOAN != 0)
                {
                    lblatestloan.Items.Add("APPLICATION NO : " + applicant_latest_loan.application_no);
                    lblatestloan.Items.Add("PRINCIPAL : PhP " + applicant_latest_loan.principal.ToString("#,##0.00"));
                    lblatestloan.Items.Add("INTEREST : PhP " + applicant_latest_loan.interest.ToString("#,##0.00"));
                    lblatestloan.Items.Add("MONTHLY AMORTIZATION: PhP " + (applicant_latest_loan.amortization_on_interest + applicant_latest_loan.amortization_on_principal).ToString("#,##0.00"));
                    lblatestloan.Items.Add("BALANCE: ---(under development)---");
                }
                else {
                    lblatestloan.Items.Add("Nothing found...");
                    lblatestloan.Items.Add("MAXIMUM ALLOWED LOAN :" + MAXIMUM_ALLOWED_LOAN.ToString("#,##0.00"));
                    lblatestloan.Items.Add("MAXIMUM AMORTIZATION PERIOD :" + MAXIMUM_ALLOWED_AMORT_PERIOD.ToString());                            
                }



                cboprincipal.Text = MAXIMUM_ALLOWED_LOAN.ToString("0.00");
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
            if (cboprincipal.Text != "")
            {
                APPLIED_LOAN_AMOUNT = Convert.ToDecimal(cboprincipal.Text);
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
            if (cboprincipal.Text != "")
            {
                APPLIED_LOAN_AMOUNT = Convert.ToDecimal(cboprincipal.Text);
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
       
            lbcomakersdata.Items.Clear();
            lbcomakerslatestloan.Items.Clear();


            if (cboComaker.Text != "")
            {
                String[] c = cboComaker.Text.ToString().Split('-');
                String id = c[1];
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
                lbcomakersdata.Items.Add("EMPLOYEE INFORMATION");
                lbcomakersdata.Items.Add("BECAME REGULAR SINCE :" + regularization_date.ToShortDateString());
                lbcomakersdata.Items.Add("TOTAL MONTHS_IN_SEVICE AS REGULAR : " + months_as_regular.ToString());
                lbcomakersdata.Items.Add("BASIC SALARY : " + BASIC_PAY.ToString("#,##0.00"));


                //display latest loan

                l.empid = comaker.empid;

                Loan comakers_latest_loan = l.GET_LATEST_LOAN("SALARY");

                // GET THE LATEST MICRO LOAN OF A MEMBER
                lbcomakerslatestloan.Items.Add("LATEST MICRO LOAN");
                COMAKERS_LATEST_SALARY_LOAN = (comakers_latest_loan != null) ? comakers_latest_loan.principal : 0;

                if (COMAKERS_LATEST_SALARY_LOAN != 0)
                {
                    lbcomakerslatestloan.Items.Add("APPLICATION NO : " + comakers_latest_loan.application_no);
                    lbcomakerslatestloan.Items.Add("PRINCIPAL : PhP " + comakers_latest_loan.principal.ToString("#,##0.00"));
                    lbcomakerslatestloan.Items.Add("INTEREST : PhP " + comakers_latest_loan.interest.ToString("#,##0.00"));
                    lbcomakerslatestloan.Items.Add("MONTHLY AMORTIZATION: PhP " + (comakers_latest_loan.amortization_on_interest + comakers_latest_loan.amortization_on_principal).ToString("#,##0.00"));
                    lbcomakerslatestloan.Items.Add("BALANCE: ---(under development)---");
                }
                else
                {

                    lbcomakerslatestloan.Items.Add("Nothing found...");

                }

                //CHECK IF THIS COMAKER HAS BEEN A COMAKER FOR MORE THAN ONE(1) MEMBER_EMPLOYEE
                 //==========================================================================
                //-------> INSERT CODE HERE 

                lbcomakerslatestloan.Items.Add("CURRENTLY COMAKER TO : ...{under development}...");
                //===========================================================================
                




                // LOAD EMPLOYEE PICTURE 
                if (comaker.pic != null)
                {
                    MemoryStream ms = new MemoryStream(comaker.pic);
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












        private void iteratesalary(decimal sal, ComboBox cb, int loop)
        {
            cb.Items.Clear();
            decimal salitem=sal;
            for (int x = 0; x < loop; x++) {
                cb.Items.Add(salitem);
                salitem += sal;                
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Loan nl = new Loan();
            nl.application_no = lblapplicationno.Text;
            //its okey EMPID and MEMID are treated same way in database.
            nl.empid = applicant.empid;
            nl.comakerid = comaker.empid;
            nl.principal = Convert.ToDecimal(cboprincipal.Text);
            nl.interest = Convert.ToDecimal(txtinterest.Text);
            nl.amortization_period = (int)SELECTED_AMORTIZATION;
            nl.amortization_on_principal = Convert.ToDecimal(txtprincipal_amort.Text);
            nl.amortization_on_interest = Convert.ToDecimal(txtinterest_amort.Text);
            nl.loantype = "SALARY";
            nl.payment_period = cbopayment_mode.Text;
            nl.collection_day = cbocollection_day.Text;
            nl.auto_credit_to_cbu = 0;
            nl.net_proceeds = Convert.ToDecimal(txtnetproceeds.Text);
            nl.prev_loan_application_no = (PREV_LOAN != null) ? PREV_LOAN.application_no : "";


            if (nl.save())
            {
                l.INCREASE_SALARY_LOAN_COUNTER();
                MessageBox.Show("Successful");
                btncancel.PerformClick();
            }
            else
            {
                MessageBox.Show("There was a problem saving your SALARY_LOAN_APPLICATION :");
            }
        }










    }
}
