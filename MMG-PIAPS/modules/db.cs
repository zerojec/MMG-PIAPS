using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MMG_PIAPS.Properties;
using MMG_PIAPS.classes;
using System.Data.OleDb;

namespace MMG_PIAPS.modules
{   
    public static class db
    {
        public static  Exception err;
        private static String _constr;
        public static MySqlConnection con = new MySqlConnection();
        public static String constr { get { return _constr; } set { _constr = value; } }





        public static OleDbConnection excelcon;
        public static String ExcelFilePath="";
        public static String ExcelConnectionString = "";
        public static String directory = "";
        


         public static Boolean CONNECTEXCEL() {


             ExcelFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
             directory = System.IO.Path.GetDirectoryName(ExcelFilePath);
             directory += "\\Membership.xlsx";
            

             
             //String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + directory +"';" + "Extended Properties=Excel 8.0;";
             //String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + directory + "';" + "Extended Properties='Excel 8.0;HDR=YES;';";
             //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Docs\\Book2.xlsx;Extended Properties='Excel 12.0 xml;HDR=YES;'"
             String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + directory + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            // String OledbProviderString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\OlsonWindows.xls;Extended Properties='Excel 8.0;HDR=YES;';";                          
            
                       
             try
            {
                excelcon = new OleDbConnection(connectionString);
                excelcon.Open();              
                return true;
            }
            catch (Exception e) {
                db.err = e;
                Logger.WriteErrorLog(e.Message.ToString());
                return false;
            }
        }












        public static void GETCONSTR() {
            constr = Properties.Settings.Default.CONSTR.ToString();
        }

      
        public static Boolean CONNECT() {
            try
            {
                GETCONSTR();
                con.ConnectionString = constr;
                con.Open();
                return true;
            }
            catch (Exception e) {
                db.err = e;
                Logger.WriteErrorLog(e.Message.ToString());
                return false;
            }
        }
        public static void SET_COMMAND_PARAMS(MySqlCommand cmd, String sql) {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = sql;
        }

        
    }
}
