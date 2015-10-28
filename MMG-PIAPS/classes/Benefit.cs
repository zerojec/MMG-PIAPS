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
    public class Benefit
    {
        public String code { get; set; }
        public String name_ { get; set; }
        public String amount_lookup { get; set; }
        public decimal amount { get; set; }
        public string type_ { get; set; }

        public Boolean save()
        {

            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "BENEFIT_INSERT");
            cmd.Parameters.AddWithValue("_code", code);
            cmd.Parameters.AddWithValue("_name", name_);
            cmd.Parameters.AddWithValue("_amount_lookup", amount_lookup);
            cmd.Parameters.AddWithValue("_amount", amount);
            cmd.Parameters.AddWithValue("_type", type_);
            
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
            db.SET_COMMAND_PARAMS(cmd, "BENEFIT_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("BENEFIT SELEC_ALL MODULE : " + e.Message);
                return null;
            }

        }//end select all






        public void LoadOnListView(ListView lv)
        {
            Benefit s = new Benefit();
            DataTable dt = new DataTable();

            dt = s.SELECT_ALL();
            if (dt != null)
            {
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["code"].ToString());
                    li.SubItems.Add(r["name_"].ToString());
                    li.SubItems.Add(r["type_"].ToString());
                    //li.SubItems.Add(r["amount_lookup"].ToString());
                    //li.SubItems.Add(r["amount"].ToString());           
                    lv.Items.Add(li);
                    ctr++;
                }
            }

        }//end load benefits


        public void LoadInComboBox(ComboBox cbo)
        {
            Benefit s = new Benefit();
            DataTable dt = new DataTable();

            dt = s.SELECT_ALL();
            if (dt != null)
            {              
                foreach (DataRow r in dt.Rows)
                {                   
                    cbo.Items.Add(r["code"].ToString());                                      
                }
            }

        }//end load benefits



        public Decimal GET_AMOUNT(Decimal _basic_salary) {
            decimal d = 0;
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "BENEFIT_SELECT_AMOUNT_BYID");
            cmd.Parameters.AddWithValue("_code", code);
            cmd.Parameters.AddWithValue("_basic_salary", _basic_salary);

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    d = Convert.ToDecimal(r["amount"].ToString());
                    return d;
                }
                else
                {
                    return 0;
                }
            }
            else {
                return 0;
            }
        }

    }
}
