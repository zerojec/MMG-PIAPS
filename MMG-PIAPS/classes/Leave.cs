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
    public class Leave
    {

        public String empid { get; set; }
        public string leavetype { get; set; }
        public string reason { get; set; }
        public DateTime leavedate { get; set; }
        public DateTime datefiled { get; set; }
        public string status_ { get; set; }
        public string approvedby { get; set; }
        public decimal noofdays { get; set; }











        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LEAVE_INSERT");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_leavetype", leavetype);
            cmd.Parameters.AddWithValue("_reason", reason);
            cmd.Parameters.AddWithValue("_noofdays", noofdays);
            cmd.Parameters.AddWithValue("_leavedate", leavedate);
            cmd.Parameters.AddWithValue("_datefiled", datefiled);
            cmd.Parameters.AddWithValue("_status_", status_);
            cmd.Parameters.AddWithValue("_approvedby", approvedby);
            

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








        public DataTable SELECT_ALL()
        {

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "LEAVE_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e.Message);
                return null;
            }

        }






        public void LoadOnListView(ListView lv)
        {
            Leave s = new Leave();
            DataTable dt = new DataTable();

            dt = s.SELECT_ALL();
            if (dt != null)
            {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["fullname"].ToString());
                    li.SubItems.Add(r["leavetype"].ToString());
                    li.SubItems.Add(r["leavedate"].ToString());
                    li.SubItems.Add(r["noofdays"].ToString());
                    li.SubItems.Add(r["datefiled"].ToString());
                  
                    lv.Items.Add(li);

                    ctr++;
                }
            }

        }//end load ins listview







    }
}
