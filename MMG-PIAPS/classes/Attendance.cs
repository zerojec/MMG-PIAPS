using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MMG_PIAPS.modules;

namespace MMG_PIAPS.classes
{
    class Attendance
    {
        public int empid{get;set;}
        public int state{get;set;}
        public DateTime date_time{get;set;}   
        public int work_code{get;set;}

        public Boolean save() {

            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "ATTENDANCE_INSERT");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_state", state);
            cmd.Parameters.AddWithValue("_work_code", work_code);
            cmd.Parameters.AddWithValue("_date_time", date_time);
           
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                Logger.WriteErrorLog(e.Message.ToString());
                return false;
            }            
        }

    }
}
