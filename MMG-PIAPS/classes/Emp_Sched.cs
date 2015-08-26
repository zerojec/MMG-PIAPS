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
    public class Emp_Sched
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




        public Emp_Sched SELECT_BY_EMPID()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_SCHED_SELECT_BY_EMPID");
            cmd.Parameters.AddWithValue("_empid", empid);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];

                    Emp_Sched es = new Emp_Sched();
                 
                    es.empid = Convert.ToInt32(r["empid"].ToString());
                    es.mon = r["mon"].ToString();
                    es.tue = r["tue"].ToString();
                    es.wed = r["wed"].ToString();
                    es.thu = r["thu"].ToString();
                    es.fri = r["fri"].ToString();
                    es.sat = r["sat"].ToString();
                    es.sun = r["sun"].ToString();
                  
                      
                   
                    return es;
                }
                else { return null; }

            }
            else
            {
                return null;
            }

        }












        public DataTable SELECT_ALL()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_SCHED_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("EMP_SCHED_SELECT_ALL MODULE :" + e.Message);
                return null;
            }

        }


        public void LoadEmpSched(ComboBox cbo)
        {

            Emp_Sched es = new Emp_Sched();
            DataTable dt = new DataTable();

            dt = es.SELECT_ALL();
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    cbo.Items.Add(r["lname"] + ", " + r["fname"] + " " + r["mname"] + "-" + r["empid"]);
                }
            }

        }



        public void LoadEmpSchedInListView(ListView lv)
        {

            Emp_Sched es = new Emp_Sched();
            DataTable dt = new DataTable();

            dt = es.SELECT_ALL();
            if (dt != null)
            {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["fullname"].ToString());
                    li.SubItems.Add(r["mon"].ToString());
                    li.SubItems.Add(r["tue"].ToString());
                    li.SubItems.Add(r["wed"].ToString());
                    li.SubItems.Add(r["thu"].ToString());
                    li.SubItems.Add(r["fri"].ToString());
                    li.SubItems.Add(r["sat"].ToString());
                    li.SubItems.Add(r["sun"].ToString());
                    li.SubItems.Add(Convert.ToDateTime(r["date_updated"].ToString()).ToLongDateString());
                    lv.Items.Add(li);
                    ctr++;
                }
            }

        }


        }

    }

