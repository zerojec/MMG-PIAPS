using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.modules;

namespace MMG_PIAPS.userctrl.custom
{
    public partial class mit_time_ctrl : UserControl
    {
        public int hour_in { get{ return dtin.Value.Hour;} }
        public int min_in { get{ return dtin.Value.Minute;} }
        public int hour_out { get { return dtout.Value.Hour; }  }
        public int min_out { get{ return dtout.Value.Minute;}  }
        public String ampm { get; set; }
        
        public TimeSpan hoursallocated { get {
            string startTime = dtin.Value.ToShortTimeString();
            string endTime = dtout.Value.ToShortTimeString();

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            return duration;
        } }
              
        public mit_time_ctrl()
        {
            InitializeComponent();
        }

     

      


        private void nm_ValueChanged(object sender, EventArgs e)
        {    
            //check if valid time
                              
        }

        private void mit_time_ctrl_Load(object sender, EventArgs e)
        {
            dtin.Value = Convert.ToDateTime("7:00:00 AM");
            dtout.Value = Convert.ToDateTime("12:00:00 PM");
        }

     

       



    }
}
