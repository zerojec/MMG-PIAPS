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
    class Emp_Benefit
    {
        public String empid { get; set; }
        public string benefit_code { get; set; }
        public string emp_benefit_code { get; set; }//IDENTIFICATION SUPPLIED BY INSTITUTIONS

        public Boolean save()
        {

            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_BENEFIT_INSERT");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_benefit_code", benefit_code);          
            cmd.Parameters.AddWithValue("_emp_benefit_code", emp_benefit_code);

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
        }// end save



        public DataTable SELECT_ALL()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_BENEFIT_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("EMP_BENEFIT_SELECT_ALL MODULE : " + e.Message);
                return null;
            }

        }//end select all




        public void LoadOnListView(ListView lv)
        {
            Emp_Benefit s = new Emp_Benefit();
            DataTable dt = new DataTable();

            dt = s.SELECT_ALL();
            if (dt != null)
            {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["empid"].ToString());
                    li.SubItems.Add(r["fullname"].ToString());
                    li.SubItems.Add(r["position_"].ToString());
                    li.SubItems.Add(r["benefits"].ToString());

                    lv.Items.Add(li);

                    ctr++;
                }
            }

        }//end load benefits
    }
}
