using MMG_PIAPS.classes;
using MMG_PIAPS.modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MMG_PIAPS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
           
        static void Main()
        {                               
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                      
            if (db.CONNECT()){                            
                Application.Run(new frmLogin());
            }else{
                MessageBox.Show("There is a problem with database connection : \n\n" + db.err.Message.ToString(), "Error");
            }
            
        }
    }
}
