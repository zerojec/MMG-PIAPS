using MMG_PIAPS.modules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.classes
{
    public class Emp_Restriction
    {
        public String empid { get; set; }
        public Boolean CAN_CHANGE_PASSWORD { get; set; }
        public Boolean CAN_ADD_LEAVE { get; set; }
        public Boolean CAN_ADD_PASS_SLIP { get; set; }
        public Boolean CAN_ADD_EMPLOYEE { get; set; }
        public Boolean CAN_ADD_SCHEDULE_TEMPLATE { get; set; }
        public Boolean CAN_ADD_EMP_SCHED { get; set; }
        public Boolean CAN_UPDATE_LEAVE { get; set; }
        public Boolean CAN_UPDATE_PASS_SLIP { get; set; }
        public Boolean CAN_UPDATE_EMPLOYEE { get; set; }
        public Boolean CAN_UPDATE_EMP_SCHED { get; set; }
        public Boolean CAN_LOG_IN { get; set; }
        public Boolean CAN_VIEW_ATTENDANCE { get; set; }
        public Boolean CAN_VIEW_LOAN { get; set; }
        public Boolean CAN_APPLY_LOAN { get; set; }
        public Boolean CAN_ADD_SERVICE_REQUEST { get; set; }
        public Boolean CAN_VIEW_SERVICE_REQUEST { get; set; }
        public Boolean CAN_VIEW_PROPERTIES { get; set; }
        public Boolean CAN_ADD_PROPERTIES { get; set; }
        public Boolean CAN_VIEW_SUPPLIES { get; set; }
        public Boolean CAN_ADD_SUPPLIES { get; set; }
        public Boolean CAN_ADD_SUPPLY_REQUEST { get; set; }
        public Boolean CAN_VIEW_SUPPLY_REQUEST { get; set; }
        public Boolean CAN_RECOMMEND { get; set; }


        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_RESTRICTION_INSERT");
            cmd.Parameters.AddWithValue("_empid", empid);
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








        public Boolean Toggle(String id,String _restriction_name, Boolean _newvalue)
        {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "TOGGLE_RESTRICTION");
            cmd.Parameters.AddWithValue("_empid", id);
            cmd.Parameters.AddWithValue("_restriction_name", _restriction_name);
            cmd.Parameters.AddWithValue("_newvalue", _newvalue);
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











        public Emp_Restriction SELECT_BY_ID()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_RESTRICTION_BYEMPID");
            cmd.Parameters.AddWithValue("_empid", empid);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Emp_Restriction er = new Emp_Restriction();
                    DataRow r = dt.Rows[0];
                    er.empid = r["empid"].ToString();
                    er.CAN_ADD_EMP_SCHED = (Boolean)r["CAN_ADD_EMP_SCHED"];
                    er.CAN_ADD_EMPLOYEE = (Boolean)r["CAN_ADD_EMPLOYEE"];
                    er.CAN_ADD_LEAVE = (Boolean)r["CAN_ADD_LEAVE"];
                    er.CAN_ADD_PASS_SLIP = (Boolean)r["CAN_ADD_PASS_SLIP"];
                    er.CAN_ADD_PROPERTIES = (Boolean)r["CAN_ADD_PROPERTIES"];
                    er.CAN_ADD_SCHEDULE_TEMPLATE = (Boolean)r["CAN_ADD_SCHEDULE_TEMPLATE"];
                    er.CAN_ADD_SERVICE_REQUEST = (Boolean)r["CAN_ADD_SERVICE_REQUEST"];
                    er.CAN_ADD_SUPPLIES = (Boolean)r["CAN_ADD_SUPPLIES"];
                    er.CAN_ADD_SUPPLY_REQUEST = (Boolean)r["CAN_ADD_SUPPLY_REQUEST"];
                    er.CAN_APPLY_LOAN = (Boolean)r["CAN_APPLY_LOAN"];
                    er.CAN_CHANGE_PASSWORD = (Boolean)r["CAN_CHANGE_PASSWORD"];
                    er.CAN_LOG_IN = (Boolean)r["CAN_LOG_IN"];
                    er.CAN_RECOMMEND = (Boolean)r["CAN_RECOMMEND"];
                    er.CAN_UPDATE_EMP_SCHED = (Boolean)r["CAN_UPDATE_EMP_SCHED"];
                    er.CAN_UPDATE_EMPLOYEE = (Boolean)r["CAN_UPDATE_EMPLOYEE"];
                    er.CAN_UPDATE_LEAVE = (Boolean)r["CAN_UPDATE_LEAVE"];
                    er.CAN_UPDATE_PASS_SLIP = (Boolean)r["CAN_UPDATE_PASS_SLIP"];
                    er.CAN_VIEW_ATTENDANCE = (Boolean)r["CAN_VIEW_ATTENDANCE"];
                    er.CAN_VIEW_LOAN = (Boolean)r["CAN_VIEW_LOAN"];
                    er.CAN_VIEW_PROPERTIES = (Boolean)r["CAN_VIEW_PROPERTIES"];
                    er.CAN_VIEW_SERVICE_REQUEST = (Boolean)r["CAN_VIEW_SERVICE_REQUEST"];
                    er.CAN_VIEW_SUPPLIES = (Boolean)r["CAN_VIEW_SUPPLIES"];
                    er.CAN_VIEW_SUPPLY_REQUEST = (Boolean)r["CAN_VIEW_SUPPLY_REQUEST"];

                    // e.date_hired = Convert.ToDateTime(r["mname"].ToString());
                    // e.position = r["position"].ToString();
                        // e.branch = r["branch"].ToString();

                  
                    return er;
                }
                else { return null; }

            }
            else
            {
                return null;
            }

        }



















    }
}
