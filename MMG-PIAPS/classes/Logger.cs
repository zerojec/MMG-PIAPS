using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace MMG_PIAPS.classes
{
    public static class Logger
    {

        public static Exception err = null;

        public static void WriteErrorLog(String error) {

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            var directory = System.IO.Path.GetDirectoryName(path);
            directory += "\\error_log\\errors.txt";
            
            if (!File.Exists(directory))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(directory))
                {
                    sw.WriteLine(DateTime.Now.ToShortDateString() + ":" + error);                  
                }
            }

         
        }

    }
}
