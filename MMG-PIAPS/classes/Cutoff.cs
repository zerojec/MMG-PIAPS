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
    public class Cutoff
    {
        public string cutoff_id { get; set; }
        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }


        public Boolean save()
        {

            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "CUTOFF_INSERT");
            cmd.Parameters.AddWithValue("_cutoff_id", cutoff_id);
            cmd.Parameters.AddWithValue("_from_date", from_date);
            cmd.Parameters.AddWithValue("_to_date", to_date);
            
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                Logger.WriteErrorLog("CUTOFF_INSERT MODULE :" + e.Message);
                return false;
            }
        }//end save






        public Boolean delete()
        {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "CUTOFF_DELETE");
            cmd.Parameters.AddWithValue("_cutoff_id", cutoff_id);
       
           
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








        public DataTable SELECT_ALL()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "CUTOFF_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("CUTOFF_SELECT ALL MODULE : " + e.Message);
                return null;
            }

        }//end select all






        public Cutoff SELECT_BY_ID()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "CUTOFF_SELECT_BYID");
            cmd.Parameters.AddWithValue("_cutoff_id", cutoff_id);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                if (dt != null)
                {

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        Cutoff c = new Cutoff();
                        c.from_date = Convert.ToDateTime(dr["from_date"].ToString());
                        c.to_date = Convert.ToDateTime(dr["to_date"].ToString());
                        c.cutoff_id = dr["cutoff_id"].ToString();

                        return c;

                    }
                    else {
                        return null;
                    }
                }
                else {
                    return null;
                
                }
               
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("CUTOFF_SELECT ALL MODULE : " + e.Message);
                return null;
            }

        }//end select all





        public void LoadOnListView(ListView lv)
        {
            Cutoff s = new Cutoff();
            DataTable dt = new DataTable();

            dt = s.SELECT_ALL();
            if (dt != null)
            {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["cutoff_id"].ToString());
                    li.SubItems.Add(Convert.ToDateTime(r["from_date"].ToString()).ToShortDateString());
                    li.SubItems.Add(Convert.ToDateTime(r["to_date"].ToString()).ToShortDateString());
                    

                    lv.Items.Add(li);

                    ctr++;
                }
            }

        }//end load cutoff

    }
}
