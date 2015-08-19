using MMG_PIAPS.modules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.classes
{
    class Employee_Schedule
    {
        public int empid { get; set; }
        public String mon { get; set; }
        public String tue { get; set; }
        public String wed { get; set; }
        public String thu { get; set; }
        public String fri { get; set; }
        public String sat { get; set; }
        public String sun { get; set; }

        public Boolean save() { 
         MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_SCHEDULE_INSERT");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_mon", mon);
            cmd.Parameters.AddWithValue("_tue", tue);          
            cmd.Parameters.AddWithValue("_wed", wed);
            cmd.Parameters.AddWithValue("_thu", thu);
            cmd.Parameters.AddWithValue("_fri", fri);
            cmd.Parameters.AddWithValue("_sat", sat);
            cmd.Parameters.AddWithValue("_sun", sun);   
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                db.err = null;
                db.err = e;                
                return false;
            }                   
        }//end save

        }

    }

