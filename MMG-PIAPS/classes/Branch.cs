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
    class Branch
    {
        public String branchname { get; set; }

        public Boolean save() {

            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd,"BRANCH_INSERT");
            cmd.Parameters.AddWithValue("_branch", branchname);
            try {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                db.err = null;
                db.err = e;
                return false;
            }
        }

        public DataTable SELECT_ALL() {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "BRANCH_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog("BRANCH SELECT_ALL MODULE :" + e.Message);
                return null;
            }

        }

        public void LoadBranches(ComboBox cbo)
        {
            Branch b = new Branch();
            DataTable dt = new DataTable();
            dt = b.SELECT_ALL();

            if (dt != null) {
                foreach (DataRow r in dt.Rows)
                {
                    cbo.Items.Add(r["id"].ToString() + "-" + r["branch"].ToString());
                }
            }
            
        }
    }
}
