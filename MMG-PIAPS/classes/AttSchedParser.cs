using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.classes
{
    public class AttSchedParser
    {
        public DateTime date_ { get; set; }
        public string timeattendance { get; set; }
        public string schedule { get; set; }
        public string dayname { get; set; }






        public  Boolean tryparse(out TimeSpan a, out TimeSpan b)
        {
            if ((timeattendance != "") && (schedule != ""))
            {
                string[] att = timeattendance.Split(',');
                string[] sch = schedule.Split(',');
                foreach (String x in att)
                {
                    DateTime dt = Convert.ToDateTime(x);
                }
                

                //using the emp_schedule for this day
                //compare with 
                a = new TimeSpan(0, 5, 22);
                b = new TimeSpan(0, 5, 22);

                return (att.Length != sch.Length) ? false : true;
            }
            else {

                a = new TimeSpan(0, 0, 0);
                b = new TimeSpan(0, 0, 0);
                return false;
            }
          




           


        }
    }
}
