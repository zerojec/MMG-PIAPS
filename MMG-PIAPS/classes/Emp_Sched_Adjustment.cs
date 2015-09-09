using MMG_PIAPS.modules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.classes
{
    public class Emp_Sched_Adjustment
    {
        public String empid { get; set; }
        public String schedule_template_id { get; set; }
        public String when_applicable { get; set; }
        public String adjustment_day { get; set; }

        public Boolean save() {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_SCHED_ADJUSTMENT_INSERT");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_schedule_template", schedule_template_id);
            cmd.Parameters.AddWithValue("_when_applicable", when_applicable);
            cmd.Parameters.AddWithValue("_adjustment_day",adjustment_day);
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

       
    }
}
