using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MMG_PIAPS.modules;
using System.Data;

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
            da.Fill(dt);
            return dt;

        }
    }
}
