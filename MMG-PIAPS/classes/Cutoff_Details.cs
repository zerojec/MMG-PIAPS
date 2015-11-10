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
    public class Cutoff_Details
    {
        public string cutoff_id { get; set; }
        public DateTime date_ { get; set; }
        public string day_type { get; set; }//regular_day, regular_holiday, special_non_working_holiday,rest_day
        public string holiday_name { get; set; }




        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "CUTOFF_DETAILS_INSERT");
            cmd.Parameters.AddWithValue("_cutoff_id", cutoff_id);
            cmd.Parameters.AddWithValue("_date_", date_);
            cmd.Parameters.AddWithValue("_day_type", day_type);
            cmd.Parameters.AddWithValue("_holiday_name", holiday_name);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                Logger.WriteErrorLog("CUTOFF_DETAILS_INSERT MODULE : " + e.Message);               
                return false;
            }
        }









      




        public DataTable SELECT_BYID()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "CUTOFF_DETAILS_SELECT_BYID");
            cmd.Parameters.AddWithValue("_cutoff_id", cutoff_id);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("CUTOFF_DETAILS_SELECT_BYID MODULE : " + e.Message);
                return null;
            }

        }//end SELECT_BYID









        public void LoadOnListView(ListView lv)
        {
            DataTable dt = new DataTable();

            dt = SELECT_BYID();

            if (dt != null)
            {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(Convert.ToDateTime(r["date_"].ToString()).ToLongDateString());
                    li.SubItems.Add(r["day_type"].ToString());
                    li.SubItems.Add(r["holiday_name"].ToString());


                    lv.Items.Add(li);

                    ctr++;
                }
            }
            else {
                Logger.WriteErrorLog("NO DATA RETURNED FROM Cutoff_Details.SELECT_BYID");
            }
          
        }//end load cutoff





    }
}
