using MMG_PIAPS.modules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.classes
{
    class BasicPay
    {
        public int empid { get; set; }
        public decimal basic_pay { get; set; }
        public DateTime date_updated { get; set; }

        public Boolean save() {

            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_BASIC_PAY_INSERT");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_basic_pay", basic_pay);
            //cmd.Parameters.AddWithValue("_date_updated", date_updated);
            try {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                db.err = null;
                db.err = e;
                return false;
            }
        }

    }
}
