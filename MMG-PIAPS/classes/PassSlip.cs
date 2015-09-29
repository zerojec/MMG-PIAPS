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
    public class PassSlip
    {
        public String empid { get; set; }
        public string passtype { get; set; }
        public DateTime datetime_in { get; set; }
        public DateTime datetime_out { get; set; }
        public string destination { get; set; }
        public string purpose { get; set; }
        public decimal allowance { get; set; }










        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "PASSSLIP_INSERT");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_passtype", passtype);
            cmd.Parameters.AddWithValue("_datetime_in", datetime_in);
            cmd.Parameters.AddWithValue("_datetime_out", datetime_out);
            cmd.Parameters.AddWithValue("_destination", destination);
            cmd.Parameters.AddWithValue("_allowance", allowance);
        
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



        public Boolean apply_new()
        {

            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "PASSSLIP_APPLY_NEW");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_passtype", passtype);
            cmd.Parameters.AddWithValue("_destination", destination);
            cmd.Parameters.AddWithValue("_purpose", purpose);
            cmd.Parameters.AddWithValue("_allowance", allowance);

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
            db.SET_COMMAND_PARAMS(cmd, "PASSSLIP_SELECT_ALL");
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
            PassSlip s = new PassSlip();
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
                    li.SubItems.Add(r["passtype"].ToString());
                    li.SubItems.Add(r["destination"].ToString());
                    li.SubItems.Add(r["purpose"].ToString());
                    li.SubItems.Add(r["datetime_in"].ToString());
                    li.SubItems.Add(r["datetime_out"].ToString());
                    li.SubItems.Add(r["allowance"].ToString());
                    li.SubItems.Add(r["status_"].ToString());

                    lv.Items.Add(li);

                    ctr++;
                }
            }

        }//end load ins listview








    }
}
