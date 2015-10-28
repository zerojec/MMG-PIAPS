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

        //TO GET LOANABLE AMOUNT
        //1. GET THE CBU (CAPITAL BUILD-UP) OF THE MEMBER
        //2. SUBTRACT MINIMUM_SHARED_CAPITAL FROM CBU THEN 
        //   MULTIPLY BY PERCENTAGE_TOGET_LOANABLE_AMOUNT
        //       NOTE:   MINIMUM_SHARED_CAPITAL----> A MEMBER CAPITAL THAT IS NOT LOANABLE
        


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
        private string SELECTED_COLLECTION_DAY="";
        private decimal APPLIED_LOAN_AMOUNT = 0;
        private decimal AUTO_CREDIT_TO_CBU = 0;
        private decimal INTEREST_ON_PRINCIPAL = 0;
        private decimal AMORTIZATION_ON_PRINCIPAL = 0;
        private decimal AMORTIZATION_ON_INTEREST = 0;
        private decimal TOTAL_AMORTIZATION = 0;


        Member applicant = new Member();
        Member comaker = new Member();
        Loan l = new Loan();





        public loan_micro_new()
        {
            InitializeComponent();
        }

        private void loan_micro_new_Load(object sender, EventArgs e)
        {
            //interest rate as MicroLoan
            ANNUAL_INTEREST_RATE = l.GET_MICRO_LOAN_ANNUAL_INTEREST_RATE();
            //yung hindi pwdeng utangin 
            MINIMUM_SHARED_CAPITAL = l.GET_MINIMUM_SHARED_CAPITAL();
            //pupuwede lang mag loan kapag parehas or mahigit sa amount na ito
            MINIMUM_SHARED_CAPITAL_TO_AVAIL_LOAN = l.GET_MINIMUM_SHARED_CAPITAL_ALLOWED_TO_LOAN();
            //ILANG PORSYENTO LANG ANG PWDENG I- LOAN HINDI LAHAT NG NATIRA.
            PERCENTAGE_TOGET_LOANABLE_AMOUNT = l.GET_PERCENTAGE_TOGET_LOANABLE_AMOUNT();
            //ilang porsyento ang madadagdag sa CBU? ito yun-->
            PERCENTAGE_OFLOAN_TO_CBU = l.GET_PERCENTAGE_OFLOAN_TO_CBU();
            //
            MAXIMUM_ALLOWED_AMORT_PERIOD = l.GET_MICRO_MAX_AMORTIZATION_PERIOD();

            ML_CONTROL_NUMBER = l.GET_MICRO_LOAN_COUNTER();
            


            label1.Text += "- with ANNUAL_INTEREST_RATE of : " + ANNUAL_INTEREST_RATE.ToString("0.0%");


            lblapplicationno.Text = "ML-" + DateTime.Now.Month.ToString("00") + "-" + ML_CONTROL_NUMBER.ToString("000") + "-" + DateTime.Now.ToString("yy");

            applicant.LoadMembers(cboMem);
            applicant.LoadMembers(cboComaker);

        }

        private void cboMem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtinterest.Text = "";
            txtinterest_amort.Text = "";
            txtprincipal.Text = "";
            txtprincipal_amort.Text = "";
            txttotal_amort.Text = "";
            cbocollection_day.Text = "";
            cbopayment_mode.Text = "";
            txtinterest.Text = "";
            cboamortization_period.Text = "";
            MAXIMUM_ALLOWED_LOAN = 0;

            lbmembersdata.Items.Clear();
            lblatestloan.Items.Clear();
            cboComaker.Text = "";
            pbcomaker.Image = null;
            lblcomaker.Text = "";
            lblcomaker.BackColor = Color.Transparent;
            lbcomakersdata.Items.Clear();
            lbcomakerslatestloan.Items.Clear();



            if (cboMem.Text != "")
            {
                String[] c = cboMem.Text.ToString().Split('-');
                String id = c[c.Length-2] + "-" + c[c.Length-1];
                Member m2 = new Member();
                //MessageBox.Show(id);
                m2.memid = id;
                applicant = m2.SELECT_BY_ID();
                m2.GET_IMAGE_BY_ID();
               
                lblmem.Text = applicant.fullname.ToString().ToUpper() + " - " + applicant.occupation.ToString();
                //lblmemdata.Text = "MEMBER SINCE :" + m.acceptance_date.ToShortDateString();


                Member_Capital mc = new Member_Capital();
                mc.memid = applicant.memid;

                decimal cbu = mc.GET_CURRENT_PAID_UP_CAPITAL();
                
                lbmembersdata.Items.Add("MEMBER'S VERIFICATION DATA");              
                lbmembersdata.Items.Add("CBU AS OF " + DateTime.Now.ToShortDateString() + " : PhP " + cbu.ToString("#,##0.00"));



                // GET THE LATEST MICRO LOAN OF A MEMBER
                lblatestloan.Items.Add("LATEST MICRO LOAN");
                LATEST_MICRO_LOAN = (l.GET_LATEST_LOAN("SALARY")!=null)? l.GET_LATEST_LOAN("SALARY").principal : 0;
                lblatestloan.Items.Add("AMOUNT GRANTED : PhP " + LATEST_MICRO_LOAN.ToString("#,##0.00"));

                //lblmemdata2.Text = "CAPITAL BUILD-UP :" +cbu.ToString("#,##0.00");

                if (cbu >= MINIMUM_SHARED_CAPITAL_TO_AVAIL_LOAN)
                {
                    //lblStatus.Text = "ALLOWED_TO_LOAN";
                    //lblStatus.BackColor = Color.Green;
                    lblmem.BackColor = Color.Green;
                    //lblStatus.Dock = DockStyle.Fill;
                    

                    //subtract minimum shared capital from the CBU
                    //then get the 60% -- because 60% of (CBU-MINIMUM_SHARED_CAPITAL) is the 
                    //LOANABLE_AMOUNT
                    MAXIMUM_ALLOWED_LOAN = (cbu - MINIMUM_SHARED_CAPITAL) * PERCENTAGE_TOGET_LOANABLE_AMOUNT;
                    lbmembersdata.Items.Add("MAX LOANABLE AMOUNT : PhP " + MAXIMUM_ALLOWED_LOAN.ToString("#,##0.00")); 
                    //lblMAX_LOANABLE_AMOUNT.Text = "MAX_LOANABLE_AMOUNT : " + MAXIMUM_ALLOWED_LOAN.ToString("#,##0.00");
                    //lblMAX_AMORT_PERIOD.Text = "MAX_AMORTIZATION_PERIOD : " + MAXIMUM_ALLOWED_AMORT_PERIOD.ToString("0");

                }
                else {
                    //lblStatus.Text = "NOT_ALLOWED_TO_LOAN";
                    //lblStatus.BackColor = Color.Red;
                    lblmem.BackColor = Color.Red;
                    //lblStatus.Dock = DockStyle.Fill;
                    //lblMAX_LOANABLE_AMOUNT.Text = "MAX_LOANABLE_AMOUNT : 0.00";
                    //lblMAX_AMORT_PERIOD.Text = "MAX_AMORTIZATION_PERIOD : 0";
                    

                }
                
                
              //  lblmemdata2.Text = "PAID-UP CAPITAL :" + m.GET_TOTAL_PAIDUP_CAPITAL();



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

        private void cboMem_MouseClick(object sender, MouseEventArgs e)
        {
            cboMem.Text = "";
        }

        private void txtprincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else { 
                
            }
         
        }

        private void cboComaker_SelectedIndexChanged(object sender, EventArgs e)
        {

            lbcomakersdata.Items.Clear();
            lbcomakerslatestloan.Items.Clear();

            if ((cboComaker.Text != "") && (cboMem.Text != "") && (cboMem.Text != cboComaker.Text))
            {
                String[] c = cboComaker.Text.ToString().Split('-');
                String id = c[c.Length - 2] + "-" + c[c.Length - 1];
                Member m2 = new Member();
                
                m2.memid = id;
                comaker= m2.SELECT_BY_ID();
                m2.GET_IMAGE_BY_ID();

                lblcomaker.Text = comaker.fullname.ToString().ToUpper() + " - " + comaker.occupation.ToString();
                lblcomaker.BackColor = (comaker.standing == "MIGS") ? Color.Green : Color.Red;



                
                Member_Capital mc = new Member_Capital();
                mc.memid = comaker.memid;

                decimal cbu = mc.GET_CURRENT_PAID_UP_CAPITAL();

                lbcomakersdata.Items.Add("COMAKER'S VERIFICATION DATA");
                lbcomakersdata.Items.Add("CBU AS OF " + DateTime.Now.ToShortDateString() + " : PhP " + cbu.ToString("#,##0.00"));

                Loan cl = new Loan();
                cl.empid = mc.memid;

                // GET THE LATEST MICRO LOAN OF A COMAKER
                lbcomakerslatestloan.Items.Add("LATEST MICRO LOAN");
                LATEST_MICRO_LOAN = (cl.GET_LATEST_LOAN("SALARY") != null) ? cl.GET_LATEST_LOAN("SALARY").principal : 0;
                lbcomakerslatestloan.Items.Add("AMOUNT GRANTED : PhP " + LATEST_MICRO_LOAN.ToString("#,##0.00"));




                if (m2.pic != null)
                {
                    MemoryStream ms = new MemoryStream(m2.pic);
                    pbcomaker.Image = Image.FromStream(ms);
                    pbcomaker.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbcomaker.Image = Properties.Resources.noimagefound;
                    pbcomaker.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else {               
                    cboComaker.Text = "";
                    pbcomaker.Image = null;
                    lblcomaker.Text = "";
                    lblcomaker.BackColor = Color.Transparent;               
            }   
        }

        private void cboComaker_MouseClick(object sender, MouseEventArgs e)
        {
            cboComaker.Text = "";
        }

        private void cboamortization_period_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (txtprincipal.Text != "") {
                APPLIED_LOAN_AMOUNT = Convert.ToDecimal(txtprincipal.Text);
                //txtprincipal.Text = String.Format("{0:C2}", APPLIED_LOAN_AMOUNT );
                String[] c = cboamortization_period.Text.Split('-');
                SELECTED_AMORTIZATION = Convert.ToDecimal(c[0]);

                INTEREST_ON_PRINCIPAL = (SELECTED_AMORTIZATION / 100) * APPLIED_LOAN_AMOUNT;
                txtinterest.Text = INTEREST_ON_PRINCIPAL.ToString("###0.00");

                AMORTIZATION_ON_PRINCIPAL = APPLIED_LOAN_AMOUNT / SELECTED_AMORTIZATION;
                txtprincipal_amort.Text = AMORTIZATION_ON_PRINCIPAL.ToString("###0.00");


                AMORTIZATION_ON_INTEREST = INTEREST_ON_PRINCIPAL / SELECTED_AMORTIZATION;
                txtinterest_amort.Text = AMORTIZATION_ON_INTEREST.ToString("###0.00");

                TOTAL_AMORTIZATION = AMORTIZATION_ON_INTEREST + AMORTIZATION_ON_PRINCIPAL;
                txttotal_amort.Text = TOTAL_AMORTIZATION.ToString("###0.00");
            }
           
            
        }

        private void cbopayment_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbocollection_day.Items.Clear();
            cbocollection_day.Text = "";
          
            if (cbopayment_mode.Text == "BI-MONTHLY")
            {
                cbocollection_day.Items.Add("15th and 30th");
                cbocollection_day.Text = "15th and 30th";
            }
            else {               
                cbocollection_day.Items.Add("15th");
                cbocollection_day.Items.Add("30th");
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            Loan nl = new Loan();
            nl.application_no = lblapplicationno.Text;
            //its okey EMPID and MEMID are treated same way in database.
            nl.empid = applicant.memid;
            nl.comakerid = comaker.memid;
            nl.principal = Convert.ToDecimal(txtprincipal.Text);
            nl.interest = Convert.ToDecimal(txtinterest.Text);
            nl.amortization_period = (int)SELECTED_AMORTIZATION;
            nl.amortization_on_principal = Convert.ToDecimal(txtprincipal_amort.Text);
            nl.amortization_on_interest = Convert.ToDecimal(txtinterest_amort.Text);
            nl.loantype = "MICRO";
            nl.payment_period = cbopayment_mode.Text;
            nl.collection_day = cbocollection_day.Text;

            if (nl.save())
            {
                l.INCREASE_MICRO_LOAN_COUNTER();                
                MessageBox.Show("Successful");
                btncancel.PerformClick();
            }
            else {
                MessageBox.Show("There was a problem saving your LOAN_APPLICATION :");
            }
            

            //do this if successfully saved
            //
        }

        private void cboamortization_period_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbopayment_mode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbocollection_day_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

       

    }
}
