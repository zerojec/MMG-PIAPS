using MMG_PIAPS.modules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.classes
{
    public class Loan
    {
        public string application_no { get; set; }
        public String empid { get; set; }
        public decimal principal { get; set; } //THIS IS ALSO KNOWN AS "THE_AMOUNT_OF_MONEY" LOANED        
        public decimal interest { get; set; }
        public DateTime filingdate { get; set; } //DATE OF LOAN APPLICATION
        public DateTime approveddate { get; set; } //DATE OF APPROVAL
        public Decimal amortization_on_principal { get; set; } //
        public Decimal amortization_on_interest { get; set; } //
        public String loantype { get; set; }
        public int amortization_period { get; set; }

        public string comakerid { get; set; }

        public string payment_period { get; set; }//monthly or bi-monthly

        public string collection_day { get; set; }//15th or 30th or both 
        //public Decimal total_payment { get; set; }


        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_INSERT");
            cmd.Parameters.AddWithValue("_application_no", application_no);
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_principal", principal);
            cmd.Parameters.AddWithValue("_interest", interest);
            cmd.Parameters.AddWithValue("_filingdate", filingdate);
            cmd.Parameters.AddWithValue("_approveddate", approveddate);
            cmd.Parameters.AddWithValue("_amortization_on_principal", amortization_on_principal);
            cmd.Parameters.AddWithValue("_amortization_on_interest", amortization_on_interest);
            cmd.Parameters.AddWithValue("_loantype", loantype);
            cmd.Parameters.AddWithValue("_amortization_period", amortization_period);
            cmd.Parameters.AddWithValue("_comakerid", comakerid);
            cmd.Parameters.AddWithValue("_payment_period", payment_period);
            cmd.Parameters.AddWithValue("_collection_day", collection_day);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                Logger.WriteErrorLog("SAVE LOAN MODULE :" + e.Message);
                return false;
            }
        }//end save







        public DataTable SELECT_ALL()
        {

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e.Message);
                return null;
            }

        }


        public void LoadLoansInListView(ListView lv)
        {

            Loan e = new Loan();
            DataTable dt = new DataTable();

            dt = e.SELECT_ALL();
            if (dt != null)
            {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["empid"].ToString());
                    li.SubItems.Add(r["principal"].ToString());
                    li.SubItems.Add(r["interest"].ToString());
                    //amortization on interest
                    decimal amointe = Convert.ToDecimal(r["amortization_on_interest"].ToString());

                    //amortization on principal
                    decimal amoprin = Convert.ToDecimal(r["amortization_on_principal"].ToString());

                    li.SubItems.Add((amoprin + amoprin).ToString("#,##0.00"));

                    li.SubItems.Add(r["amortization_period"].ToString());

                    li.SubItems.Add(r["loantype"].ToString());
                    

                    lv.Items.Add(li);
                    ctr++;

                }
            }

        }//end LoadMembersInListView





        public decimal GET_MICRO_LOAN_COUNTER()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_SELECT_ML_COUNTER");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {

                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        return Convert.ToDecimal(r["ML_COUNTER"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    Logger.WriteErrorLog("ERROR ON LOAN_MODULE ML_COUNTER");
                    return 0;
                }

            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ERROR ON LOAN_MODULE ML_COUNTER :" + e.Message);

                return 0;
            }

        }






        public Boolean INCREASE_MICRO_LOAN_COUNTER()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_ML_COUNTER_INCREASE");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                return false;
            }
        }


        public Boolean RESET_MICRO_LOAN_COUNTER()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_ML_COUNTER_RESET");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                return false;
            }

        }






        public decimal GET_SALARY_LOAN_COUNTER()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_SL_COUNTER");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {

                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        return Convert.ToDecimal(r["SL_COUNTER"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    Logger.WriteErrorLog("ERROR ON LOAN_MODULE SL_COUNTER");
                    return 0;
                }

            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ERROR ON LOAN_MODULE SL_COUNTER :" + e.Message);

                return 0;
            }

        }












        //SALARAY LOAN ANNUAL_INTEREST_RATE IS CURRENTLY SET TO 5% 
        //0R 2.5% FOR 6 MONTHS
        public decimal GET_SALARY_LOAN_ANNUAL_INTEREST_RATE() {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_SAL_PERCENTAGE_PERANNUM");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try {

                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        return Convert.ToDecimal(r["SALARY_LOAN_PERCENTAGE_PER_ANNUM"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    Logger.WriteErrorLog("ERROR ON LOAN_MODULE ANNUAL_INTEREST_RATE");
                    return 0;
                }
            
            }
            catch (Exception e) {
                Logger.WriteErrorLog("ERROR ON LOAN_MODULE ANNUAL_INTEREST_RATE :" + e.Message);

                return 0;
            }
            
        }









        //MICRO LOAN ANNUAL INTEREST_RATE IS CURRENTLY SET TO 12% OR 1% PER MONTH.
        
        public decimal GET_MICRO_LOAN_ANNUAL_INTEREST_RATE()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_MICRO_PERCENTAGE_PERANNUM");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {

                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        return Convert.ToDecimal(r["MICRO_LOAN_PERCENTAGE_PER_ANNUM"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    Logger.WriteErrorLog("ERROR ON LOAN_MODULE MICRO ANNUAL_INTEREST_RATE");
                    return 0;
                }

            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ERROR ON LOAN_MODULE MICRO ANNUAL_INTEREST_RATE :" + e.Message);

                return 0;
            }

        }








        //MINIMUM SHARED CAPITAL IS THE
        //LEAST CONTRIBUTION OF A COOPERATOR 
        //THAT IS NOT LOANABLE. EXAMPLE :
        //MEMBERS TOTAL CBU: 50,000
        //MINIMUM_SHARED_CAPITAL : 10,000 ----->CDA RULING
        //THEREFORE, MINIMUM_SHARED_CAPITAL
        //SHOULD BE DEDUCTED TO LOANABLE AMOUNT

        public decimal GET_MINIMUM_SHARED_CAPITAL()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_MICRO_MINIMUM_SHARED_CAPITAL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {

                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        return Convert.ToDecimal(r["MINIMUM_SHARED_CAPITAL"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    Logger.WriteErrorLog("ERROR ON LOAN_MODULE MICRO MINIMUM_SHARED_CAPITAL");
                    return 0;
                }

            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ERROR ON LOAN_MODULE MICRO MINIMUM_SHARED_CAPITAL :" + e.Message);

                return 0;
            }

        }






        //MINIMUM_SHARED_CAPITAL IS CURRENTLY SET TO 50,000
        //MEANING ONLY THOSE COOPERATORS OR MEMBERS WHICH HAVE 50K CBU
        //WILL BE ALLOWED TO AVAIL MICROL LOAN.

        public decimal GET_MINIMUM_SHARED_CAPITAL_ALLOWED_TO_LOAN()
        {
        
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_MICRO_MINIMUM_SHARED_CAPITAL_ALLOWED_TO_LOAN");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {

                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        return Convert.ToDecimal(r["MINIMUM_SHARED_CAPITAL_ALLOWED_TO_LOAN"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    Logger.WriteErrorLog("ERROR ON LOAN_MODULE MICRO LOAN_MICRO_MINIMUM_SHARED_CAPITAL_ALLOWED_TO_LOAN");
                    return 0;
                }

            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ERROR ON LOAN_MODULE MICRO LOAN_MICRO_MINIMUM_SHARED_CAPITAL_ALLOWED_TO_LOAN :" + e.Message);

                return 0;
            }

        }









        //CURRENTLY LOANABLE AMOUNT IS SET TO 60% OF (CBU-MINIMUM_SHARED_CAPITAL)
        public decimal GET_PERCENTAGE_TOGET_LOANABLE_AMOUNT()
        {

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_MICRO_PERCENTAGE_TOGET_LOANABLE_AMOUNT");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {

                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        return Convert.ToDecimal(r["PERCENTAGE_TOGET_LOANABLE_AMOUNT"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else {
                    return 0;
                }        

            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ERROR ON LOAN_MODULE MICRO LOAN_MICRO_PERCENTAGE_TOGET_LOANABLE_AMOUNT :" + e.Message);
                return 0;
            }

        }






        //YOU WILL NOT GET ALL THE MONEY WHEN YOU LOAN
        //SOME OF THEM WILL GO BACK TO YOUR CBU.
        //CURRENTLY IT IS SET TO 2.5% OF YOU LOANABLE_AMOUNT

        public decimal GET_PERCENTAGE_OFLOAN_TO_CBU()
        {

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_MICRO_PERCENTAGE_OFLOAN_TO_CBU");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {

                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        return Convert.ToDecimal(r["PERCENTAGE_OFLOAN_TO_CBU"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {                    
                    return 0;
                }

            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ERROR ON LOAN_MODULE MICRO PERCENTAGE_OFLOAN_TO_CBU :" + e.Message);

                return 0;
            }

        }







        //THE MAXIMUM_AMORTIZATION_PERIOD OF A MICRO LOAN
        public Int32 GET_MICRO_MAX_AMORTIZATION_PERIOD()
        {

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_MICRO_MAX_TERM");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            try
            {

                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        return Convert.ToInt32(r["MICRO_LOAN_MAX_TERM"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ERROR ON LOAN_MODULE MICRO MICRO_LOAN_MAX_TERM :" + e.Message);

                return 0;
            }

        }





        //SALARY LOAN BRACKET

        public DataTable SELECT_SALARY_LOAN_BRACKET()
        {

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_SELECT_SALARY_LOAN_BRACKET");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e.Message);
                return null;
            }

        }






        public Loan GET_LATEST_LOAN(String type_of_loan) {


            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_SELECT_LATEST_BYTYPE");
            cmd.Parameters.AddWithValue("_loantype", type_of_loan);
            cmd.Parameters.AddWithValue("_empid", empid);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
           
            try
            {
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    Loan l = new Loan();
                    l.empid = r["empid"].ToString();
                    l.principal = Convert.ToDecimal(r["principal"].ToString());

                    return l;


                }
                else {
                    return null;
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e.Message);
                return null;
            }
        }





    }
}
