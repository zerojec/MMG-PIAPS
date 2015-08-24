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
    class Schedule
    {
        public String template_name { get; set; }
        public DateTime first_half_in { get; set; }
        public DateTime first_half_out { get; set; }
        public DateTime second_half_in { get; set; }
        public DateTime second_half_out{ get; set; }
        public int hours_allocated { get; set; }
        
        public Boolean save() {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "SCHEDULE_INSERT");
            cmd.Parameters.AddWithValue("_template_name", template_name);
            cmd.Parameters.AddWithValue("_first_half_in", first_half_in);
            cmd.Parameters.AddWithValue("_first_half_out", first_half_out);          
            cmd.Parameters.AddWithValue("_second_half_in", second_half_in);
            cmd.Parameters.AddWithValue("_second_half_out", second_half_out);
            cmd.Parameters.AddWithValue("_hours_allocated", hours_allocated);   
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



        public DataTable SELECT_ALL()
        {

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "SCHEDULE_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }catch (Exception e) {
                Logger.WriteErrorLog(e.Message);
                return null;            
            }
            
        }


        public void LoadSchedules(ComboBox cbo)
        {
            Schedule s= new Schedule();
            DataTable dt = new DataTable();
            dt = s.SELECT_ALL();

            foreach (DataRow r in dt.Rows)
            {
                cbo.Items.Add(r["template_name"].ToString());
            }
        }

        public Schedule SELECT_BY_TEMPLATE_NAME()
        {
            Schedule s = new Schedule();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "SCHEDULE_SELECT_BY_TEMPLATE");
            cmd.Parameters.AddWithValue("_template_name", template_name);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow r =dt.Rows[0];

                    s.first_half_in = Convert.ToDateTime(r["first_half_in"].ToString());
                    s.first_half_out = Convert.ToDateTime(r["first_half_out"].ToString());
                    s.second_half_in = Convert.ToDateTime(r["second_half_in"].ToString());
                    s.second_half_out = Convert.ToDateTime(r["second_half_out"].ToString());
                    s.hours_allocated = Convert.ToInt32(r["hours_allocated"].ToString());
                    return s;
                }
                else {
                    return null;
                }
            }
            else {
                return s;
            }
           
            
          
        }


           public void LoadScheduleOnListView(ListView lv)
        {
            Schedule s = new Schedule();
            DataTable dt = new DataTable();

            dt = s.SELECT_ALL();
            if (dt != null) {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["template_name"].ToString());
                    li.SubItems.Add(r["first_half_in"].ToString());
                    li.SubItems.Add(r["first_half_out"].ToString());
                    li.SubItems.Add(r["second_half_in"].ToString());
                    li.SubItems.Add(r["second_half_out"].ToString());
                    li.SubItems.Add(r["hours_allocated"].ToString() + " Hours");

                    lv.Items.Add(li);

                    ctr++;
                }
            }
           
        }

    }
}
