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
    class Payment
    {
        public String application_no { get; set; }
        public String orno { get; set; }
        public decimal interest { get; set; }
        public decimal principal { get; set; }
        public decimal penalty { get; set; }
        public decimal total { get; set; }
        public DateTime date_ { get; set; }


        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "PAYMENT_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("_application_no", application_no);
            cmd.Parameters.AddWithValue("orno", orno);
            cmd.Parameters.AddWithValue("interest", interest);
            cmd.Parameters.AddWithValue("principal", principal);
            cmd.Parameters.AddWithValue("penalty", penalty);
            cmd.Parameters.AddWithValue("total", total);
            cmd.Parameters.AddWithValue("_date_", date_);
          

            try
            {
                //db.con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                Logger.WriteErrorLog("Error SAVE_PAYMENT_MODULE : " + e.Message);
                return false;
            }
        }//end save






        public Boolean update()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "PAYMENT_UPDATE";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("_application_no", application_no);
            cmd.Parameters.AddWithValue("orno", orno);
            cmd.Parameters.AddWithValue("interest", interest);
            cmd.Parameters.AddWithValue("principal", principal);
            cmd.Parameters.AddWithValue("penalty", penalty);
            cmd.Parameters.AddWithValue("total", total);
            cmd.Parameters.AddWithValue("_date_", date_);


            try
            {
                //db.con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                Logger.WriteErrorLog("Error SAVE_PAYMENT_MODULE : " + e.Message);
                return false;
            }
        }//end update






        public Boolean delete()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "PAYMENT_DELETE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("_application_no", application_no);
            cmd.Parameters.AddWithValue("orno", orno);
            cmd.Parameters.AddWithValue("_date_", date_);


            try
            {
                //db.con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                Logger.WriteErrorLog("Error SAVE_PAYMENT_MODULE : " + e.Message);
                return false;
            }
        }//end delete






        public DataTable SELECT_BY_APPLICATION_NO()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "PAYMENT_SELECT_BY_APPLICATION_NO");
            cmd.Parameters.AddWithValue("_application_no", application_no);
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
        }//end SELECT






        public void LoadPaymentsInListView(ListView lv)
        {

            Payment e = new Payment();
            DataTable dt = new DataTable();

            dt = e.SELECT_BY_APPLICATION_NO();

            if (dt != null)
            {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["date_"].ToString());
                    li.SubItems.Add(r["principal"].ToString());
                    li.SubItems.Add(r["interest"].ToString());
                    li.SubItems.Add(r["principal"].ToString());
                    li.SubItems.Add(r["total"].ToString());
                    li.SubItems.Add(r["orno"].ToString());
                
                    lv.Items.Add(li);
                    ctr++;

                }
            }

        }//end LoadMembersInListView






    }
}
