using MMG_PIAPS.modules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.classes
{
    class Member_Standing
    {
        public string memid { get; set; }
        public Boolean PAYMENT_TENK_WITHIN_SIX_MONTHS { get; set; }
        public Boolean PAYMENT_FIFTYK_WITHIN_FIVE_YEARS { get; set; }
        public Boolean PATRONAGE_OF_MMG_SERVICES { get; set; }
        public Boolean ATTENDANCE { get; set; }
        public String STANDING { get{

            String s;
            s = (GET_STANDING() == true) ? "MIGS" : "NON-MIGS";
            return s;        
        }                
        }




        public Boolean GET_STANDING()
        {
            MySqlCommand cmd = new MySqlCommand();

            db.SET_COMMAND_PARAMS(cmd, "MEMBER_GET_STANDING");
            cmd.Parameters.AddWithValue("_memid", memid);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    //declare 4 criteria (to become MIGS)
                    Boolean crit1, crit2, crit3, crit4;
                    crit1 = (Boolean)r["PAYMENT_TENK_WITHIN_SIX_MONTHS"];
                    crit2 = (Boolean)r["PAYMENT_FIFTYK_WITHIN_FIVE_YEARS"];
                    crit3 = (Boolean)r["PATRONAGE_OF_MMG_SERVICES"];
                    crit4 = (Boolean)r["ATTENDANCE"];

                    if (crit1 == true && crit2 == true && crit3 == true && crit4 == true)
                    {
                        return true;
                    }
                    else {
                        return false;
                    }

                }
                else {
                    return false;
                }
             
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e.Message);
                return false;
            }
        }

        public Boolean save() {
            MySqlCommand cmd = new MySqlCommand();

            db.SET_COMMAND_PARAMS(cmd, "MEMBER_STANDING_INSERT");
            cmd.Parameters.AddWithValue("_PAYMENT_TENK_WITHIN_SIX_MONTHS", PAYMENT_TENK_WITHIN_SIX_MONTHS);
            cmd.Parameters.AddWithValue("_PAYMENT_FIFTYK_WITHIN_FIVE_YEARS", PAYMENT_FIFTYK_WITHIN_FIVE_YEARS);
            cmd.Parameters.AddWithValue("_PATRONAGE_OF_MMG_SERVICES", PATRONAGE_OF_MMG_SERVICES);
            cmd.Parameters.AddWithValue("_ATTENDANCE", ATTENDANCE);
   
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
        }//END SAVE
        



    }
}
