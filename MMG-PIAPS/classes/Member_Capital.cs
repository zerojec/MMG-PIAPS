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
    class Member_Capital
    {
        public String memid { get; set; }
        public Decimal paid_up_capital { get; set; }
        public String paid_up_ref { get; set; }
        public String paid_up_explanation { get; set; }
        public String transaction_type { get; set; }
        public DateTime date_updated { get; set; }


        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "MEMBER_CAPITAL_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_memid", memid);
            cmd.Parameters.AddWithValue("_paid_up_capital", paid_up_capital);
            cmd.Parameters.AddWithValue("_paid_up_reference", paid_up_ref);
            cmd.Parameters.AddWithValue("_paid_up_explanation", paid_up_explanation);
            cmd.Parameters.AddWithValue("_transaction_type_", transaction_type);
            cmd.Parameters.AddWithValue("_date_updated", date_updated);
            try
            {
                //db.con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                Logger.WriteErrorLog("MEMBER_CAPITAL_SAVE_MODULE :" + e.Message);
                return false;
            }
        }//end save








        public Decimal GET_CURRENT_PAID_UP_CAPITAL()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "MEMBER_GET_TOTAL_PAID_UP");
            cmd.Parameters.AddWithValue("_memid", memid);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Decimal total = dt.Rows[0].Field<Decimal>("total");
                  
                    return total;
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

        }//end 







        public DataTable SELECT_BY_MEMID()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "MEMBER_CAPITAL_SELECT_BYMEMID");
            cmd.Parameters.AddWithValue("_memid", memid);

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





        public void LoadMembersCapitals(ListBox lst)
        {

            
            DataTable dt = new DataTable();

            dt = SELECT_BY_MEMID();

            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Items.Add(Convert.ToDateTime(r["date_updated"]).ToShortDateString() + "\t-\t" + r["transaction_type_"] + "\t-\t" + Convert.ToDecimal(r["paid_up_capital"]).ToString("#,##0.00"));
                }
            }
            else {
                Logger.WriteErrorLog("MEMBER_CAPITAL: dt is nothing");                
            }


        }


    }
}
