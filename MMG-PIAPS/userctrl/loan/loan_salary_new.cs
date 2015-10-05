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

        private decimal ANNUAL_INTEREST_RATE=0;        
        private decimal MAXIMUM_ALLOWED_LOAN=0;
        private decimal MAXIMUM_ALLOWED_AMORT_PERIOD=0;
        private string LOAN_TYPE = "SALARY";

        Employee emp = new Employee();

        Loan l = new Loan();

        public loan_salary_new()
        {
            InitializeComponent();
        }

        private void cboEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtinterest.Text = "";
            txtinterest_amort.Text = "";
            txtprincipal.Text = "";
            txtprincipal_amort.Text = "";
            txttotal_amort.Text = "";
            MAXIMUM_ALLOWED_AMORT_PERIOD = 0;
            MAXIMUM_ALLOWED_LOAN = 0;

            
            if (cboEmp.Text != "")
            {
                String[] c = cboEmp.Text.ToString().Split('-');
                String id = c[1] + "-" + c[2];
                Employee emp1, emp2 = new Employee();
                emp2.empid = id;

                emp1 = emp2.SELECT_BY_ID();
                emp = emp1;


                //GET LATEST BASIC SAL
                decimal BASIC_PAY= emp1.GET_BASIC_PAY();

                //emp1.SELECT_BY_ID();                                
                emp1.GET_IMAGE_BY_ID();




                

                String pos = (emp1.GET_CURRENT_POSITION() != "") ? emp1.position.ToString() : "NO_POSITION_INDICATED";
                lblemp.Text = emp1.lname.ToUpper() + ", " + emp1.fname.ToUpper() + " " + emp1.mname.ToUpper() + " - " + pos;

                
                //WHEN WAS THE EMPLOYEE BECAME REGULAR?
                DateTime regularization_date = emp1.GET_REGULAR_STATUS_DATE();
                int months_as_regular = Global.GetMonths(regularization_date, DateTime.Now);
                
                //DISPLAY REGULARIZATION DATE
                lblemployement.Text = "BECAME REGULAR SINCE :" + regularization_date.ToShortDateString() + "   TOTAL MONTHS_IN_SEVICE AS REGULAR : " + months_as_regular.ToString();
                lblloancategory.Text = "";

                //DETERMINE HOW MUCH LOAN IS ALLOWED FOR THIS CERTAIN EMPLOYEE
                //ACCORDING TO HIS/HER BASIC PAY
                //MessageBox.Show(months_as_regular + " - " + BASIC_PAY.ToString());
                if((months_as_regular >=6 ) && (months_as_regular<= 12)){
                    MAXIMUM_ALLOWED_LOAN = 2 * BASIC_PAY;
                    MAXIMUM_ALLOWED_AMORT_PERIOD = 6;
                }
                else if ((months_as_regular > 12) && (months_as_regular <= 24))
                {
                    MAXIMUM_ALLOWED_LOAN = 4 * BASIC_PAY;
                    MAXIMUM_ALLOWED_AMORT_PERIOD = 24;
                }
                else if(months_as_regular > 24){
                    MAXIMUM_ALLOWED_LOAN = 6 * BASIC_PAY;
                    MAXIMUM_ALLOWED_AMORT_PERIOD = 24;
                    
                }
                txtprincipal.Text = MAXIMUM_ALLOWED_LOAN.ToString("0.00");
                lblloancategory.Text = "MAXIMUM_ALLOWED_AMOUNT : " + MAXIMUM_ALLOWED_LOAN.ToString("#,##0.00") + " MAXIMUM_AMORTIZATION_PERIOD : " + MAXIMUM_ALLOWED_AMORT_PERIOD.ToString();
                nmamortperiod.Maximum = MAXIMUM_ALLOWED_AMORT_PERIOD;
                nmamortperiod.Value = nmamortperiod.Maximum;

                if (emp1.pic != null)
                {
                    MemoryStream ms = new MemoryStream(emp1.pic);
                    pb.Image = Image.FromStream(ms);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pb.Image = Properties.Resources.noimagefound;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }//end cbo_selectedindexchanged








        private void loan_new_Load(object sender, EventArgs e)
        {
            ANNUAL_INTEREST_RATE = l.GET_SALARY_LOAN_ANNUAL_INTEREST_RATE();
          
            label1.Text += "- with ANNUAL_INTEREST_RATE of : " + ANNUAL_INTEREST_RATE.ToString("0.0%");


            emp.LoadRegularEmployee(cboEmp);
                 
            DataTable dt = l.SELECT_SALARY_LOAN_BRACKET();

            lstloanbracket.Items.Add("=======Loan Guides=======");   
            foreach (DataRow r in dt.Rows) {
                lstloanbracket.Items.Add(r["name_"].ToString() + " - [" + r["allowed_basic_sal_min"].ToString() + "-" + r["allowed_basic_sal_max"].ToString() + " MONTHS of BASIC_SALARY]");
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
            l.empid = emp.empid;
            l.principal = Convert.ToDecimal(txtprincipal.Text);
            l.interest = Convert.ToDecimal(txtinterest.Text);
            l.amortization_on_interest = Convert.ToDecimal(txtinterest_amort.Text);
            l.amortization_on_principal = Convert.ToDecimal(txtprincipal_amort.Text);
            l.loantype = LOAN_TYPE;
            l.amortization_period =(Int32)nmamortperiod.Value;
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

        private void nmamortperiod_ValueChanged(object sender, EventArgs e)
        {
            txttotal_amort.Text = "";
            txtinterest.Text = "";
            try {
                decimal principal = Convert.ToDecimal(txtprincipal.Text);
                decimal amortization_period = nmamortperiod.Value;
                decimal interest_rate = (ANNUAL_INTEREST_RATE / 12) * amortization_period;
                decimal interest = principal * interest_rate;
                decimal amortization_on_principal = principal / amortization_period;
                decimal amortization_on_interest = interest / amortization_period;

                txtinterest.Text = interest.ToString("0.00");
                txtinterest_amort.Text= amortization_on_interest.ToString("0.00");
                txtprincipal_amort.Text = amortization_on_principal.ToString("0.00");
                txttotal_amort.Text = (amortization_on_principal + amortization_on_interest).ToString("0.00");

            }catch(Exception err){
                db.err = err;
                Logger.WriteErrorLog("LOAN MODULE ERROR :" + err.Message);
            }
       


        }

        private void cboloantype_SelectedIndexChanged(object sender, EventArgs e)
        {
                      
        }














    }
}
