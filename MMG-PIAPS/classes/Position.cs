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
    class Position
    {
        public String positionname { get; set; }

        public Boolean save() {
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "POSITION_INSERT");
            cmd.Parameters.AddWithValue("_position_name", positionname);                    
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
            db.SET_COMMAND_PARAMS(cmd, "POSITION_SELECT_ALL");
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


        public void LoadPositions(ComboBox cbo)
        {
            Position p = new Position();
            DataTable dt = new DataTable();
            dt = p.SELECT_ALL();
            if (dt != null) {
                foreach (DataRow r in dt.Rows)
                {
                    cbo.Items.Add(r["positionname"].ToString());
                }
            }
            
        }
    }
}
