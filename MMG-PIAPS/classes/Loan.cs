using MMG_PIAPS.modules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.classes
{
    public class Loan
    {
        public int loanid { get; set; }
        public String empid { get; set; }
        public decimal principal { get; set; } //THIS IS ALSO KNOWN AS "THE_AMOUNT_OF_MONEY" LOANED        
        public decimal interest { get; set; }
        public DateTime filingdate { get; set; } //DATE OF LOAN APPLICATION
        public DateTime approveddate { get; set; } //DATE OF APPROVAL
        public Decimal amortization_on_principal { get; set; } //
        public Decimal amortization_on_interest { get; set; } //

        public String loantype { get; set; }

        public decimal amortization_period { get; set; }
        //public Decimal total_payment { get; set; }


        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LOAN_INSERT");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_principal", principal);
            cmd.Parameters.AddWithValue("_interest", interest);
            cmd.Parameters.AddWithValue("_filingdate", filingdate);
            cmd.Parameters.AddWithValue("_approveddate", approveddate);
            cmd.Parameters.AddWithValue("_amortization_on_principal", amortization_on_principal);
            cmd.Parameters.AddWithValue("_amortization_on_interest", amortization_on_interest);
            cmd.Parameters.AddWithValue("_loantype", loantype);
            cmd.Parameters.AddWithValue("_amortization_period", amortization_period);
            

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










    }
}
