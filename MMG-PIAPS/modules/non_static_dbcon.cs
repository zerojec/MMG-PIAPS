using MMG_PIAPS.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.modules
{
    public class non_static_dbcon
    {


        public Exception err;
        private String _constr;
        public MySqlConnection con = new MySqlConnection();
        public String constr { get { return _constr; } set { _constr = value; } }


        public OleDbConnection excelcon;
        public String ExcelFilePath = "";
        public String ExcelConnectionString = "";
        public String directory = "";


        public Boolean CONNECTEXCEL(String directory)
        {

            String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + directory + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";


            try
            {
                excelcon = new OleDbConnection(connectionString);
                excelcon.Open();
                return true;
            }
            catch (Exception e)
            {
                db.err = e;
                Logger.WriteErrorLog(e.Message.ToString());
                return false;
            }
        }












        public void GETCONSTR()
        {
            constr = Properties.Settings.Default.CONSTR.ToString();
        }


        public Boolean CONNECT()
        {
            try
            {
                GETCONSTR();
                con.ConnectionString = constr;
                con.Open();
                return true;
            }
            catch (Exception e)
            {
                db.err = e;
                Logger.WriteErrorLog(e.Message.ToString());
                return false;
            }
        }




        public Boolean DISCONNECT()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Open) {
                   
                    
                    con.Close();
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        return true;
                    }
                    else {
                        return false;
                    }
                }else{
                    return true;
                }
               
            }
            catch (Exception e)
            {
                db.err = e;
                Logger.WriteErrorLog(e.Message.ToString());
                return false;
            }
        }



        public void SET_COMMAND_PARAMS(MySqlCommand cmd, String sql)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = sql;
        }
    }
}
