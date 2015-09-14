using MMG_PIAPS.modules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.classes
{
    class Member_Capital
    {
        public String memid { get; set; }
        public Decimal paid_up_capital { get; set; }
        public String paid_up_capital_ref { get; set; }
        public String paid_up_capital_expalantation { get; set; }


        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "MEMBER_CAPITAL_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("_memid", memid);
            cmd.Parameters.AddWithValue("_paid_up_capital", paid_up_capital);
            cmd.Parameters.AddWithValue("_paid_up_capital_ref", paid_up_capital_ref);
            cmd.Parameters.AddWithValue("_paid_up_capital_expalantation", paid_up_capital_expalantation);
           
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
                return false;
            }
        }//end save

    }
}
