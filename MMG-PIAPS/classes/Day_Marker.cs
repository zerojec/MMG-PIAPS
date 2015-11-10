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

   public class Day_Marker
    {





        public DateTime dateoftheyear { get; set; }
        public String type_{get;set;}
        public String name_of_holiday{get;set;}

        public Boolean save(){
          MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "DAY_MARKER_INSERT");
            cmd.Parameters.AddWithValue("_dateoftheyear", dateoftheyear);
            cmd.Parameters.AddWithValue("_type_", type_);
            cmd.Parameters.AddWithValue("_name_of_holiday", name_of_holiday);
            
           
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






        
        public Boolean update(){
          MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "DAY_MARKER_UPDATE");
            cmd.Parameters.AddWithValue("_dateoftheyear", dateoftheyear);
            cmd.Parameters.AddWithValue("_type_", type_);
            cmd.Parameters.AddWithValue("_name_of_holiday", name_of_holiday);
            
           
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
        }//end update







          public Boolean delete(string thisdate){
          MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "DAY_MARKER_DELETE");
            cmd.Parameters.AddWithValue("_dateoftheyear", thisdate);
            
           
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
        }//end update













          public DataTable SELECT_ALL()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "DAY_MARKER_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("DAY MARKER SELECT_ALL MODULE :" + e.Message);
                return null;
            }

        }//end select all







          public Day_Marker SELECT_BY_DATE(string thisdate)
          {
              DataTable dt = new DataTable();
              MySqlCommand cmd = new MySqlCommand();
              db.SET_COMMAND_PARAMS(cmd, "DAY_MARKER_SELECT_BYDATE");            
              cmd.Parameters.AddWithValue("_dateoftheyear", thisdate);
              
              
              MySqlDataAdapter da = new MySqlDataAdapter(cmd);

              try
              {
                  Day_Marker dm = new Day_Marker();
                  da.Fill(dt);

                  if (dt.Rows.Count > 0)
                  {
                      DataRow r = dt.Rows[0];

                      dm.dateoftheyear = Convert.ToDateTime(r["dateoftheyear"].ToString());
                      dm.name_of_holiday = r["name_of_holiday"].ToString();
                      dm.type_ = r["type_"].ToString();

                      return dm;
                  }
                  else {
                      return null;
                  }
                 
              }
              catch (Exception e)
              {
                  Logger.WriteErrorLog("DAY MARKER SELECT_ALL MODULE :" + e.Message);
                  return null;
              }

          }//end select all










          public void LoadInListView(ListView lv)
          {

              Day_Marker a = new Day_Marker();
              DataTable dt = new DataTable();

              dt = a.SELECT_ALL();
              if (dt != null)
              {
                  int ctr = 1;
                  foreach (DataRow r in dt.Rows)
                  {
                      ListViewItem li = new ListViewItem();
                      li.Text = ctr.ToString();
                      li.SubItems.Add(Convert.ToDateTime(r["dateoftheyear"].ToString()).ToString("MMMM-d"));
                      li.SubItems.Add(r["name_of_holiday"].ToString());                      
                      li.SubItems.Add(r["type_"].ToString());
                      
                      lv.Items.Add(li);
                      ctr++;
                  }
              }

          }//end load in listview









    }
}
