using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MMG_PIAPS.modules;
using System.Data;
using System.Windows.Forms;

namespace MMG_PIAPS.classes
{
    class Attendance
    {
        public String empid{get;set;}
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
        }//end save



        public DataTable SELECT_ALL()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "ATTENDANCE_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ATTENDANCE SELECT_ALL MODULE :" + e.Message);
                return null;
            }

        }//end select all


        public DataTable SELECT_BETWEEN_DATES(DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "ATTENDANCE_BW_DATES");
            cmd.Parameters.AddWithValue("_from", from);
            cmd.Parameters.AddWithValue("_to", to);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ATTENDANCE SELECT_BW_DATES MODULE :" + e.Message);
                return null;
            }

        }//end select bween dates




        public DataTable SELECT_BY_EMPID()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "ATTENDANCE_BY_EMPID");
            cmd.Parameters.AddWithValue("_empid", empid);
         
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ATTENDANCE SELECT_BY_EMPID MODULE :" + e.Message);
                return null;
            }

        }//end select bween dates



        public DataTable SELECT_BY_EMPID_BW_DATES(DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "ATTENDANCE_BY_EMPID_BW_DATES");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_from", from);
            cmd.Parameters.AddWithValue("_to", to);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("ATTENDANCE_BY_EMPID_BW_DATES MODULE:" +e.Message);
                return null;
            }

        }//end select bween dates


        public void LoadInListView(ListView lv)
        {

            Attendance a = new Attendance();
            DataTable dt = new DataTable();

            dt = a.SELECT_ALL();
            if (dt != null)
            {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["fullname"].ToString());                  
                    li.SubItems.Add(r["position_"].ToString());
                    li.SubItems.Add(Convert.ToDateTime(r["date_"].ToString()).ToString("MMMM dd, yyyy"));
                    li.SubItems.Add(r["attendance"].ToString());
                // li.SubItems.Add(Convert.ToDateTime(r["date_updated"].ToString()).ToLongDateString());
                    lv.Items.Add(li);
                    ctr++;
                }
            }

        }

    }
}
