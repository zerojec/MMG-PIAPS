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

        public int hour_in { get; set; }
        public int min_in { get; set; }
        public int hour_out { get {
            if (txtEndTime.Text.Equals(""))
            {
                return 0;
            }
            else {
                String[] time = txtEndTime.Text.Split(':');
                int _hour_out = Convert.ToInt32(time[0]);
                int _min_out = Convert.ToInt32(time[1]);
                return _hour_out;
            }   
            }         
        }
        public int min_out { get {
            if (txtEndTime.Text.Equals(""))
            {
                return 0;
            }
            else
            {
                String[] time = txtEndTime.Text.Split(':');
                int _hour_out = Convert.ToInt32(time[0]);
                int _min_out = Convert.ToInt32(time[1]);
                return _min_out;
            }
        } }
        public String ampm { get; set; }
        public Decimal hoursallocated { get { return nm.Value; } }
              
        public mit_time_ctrl()
        {
            InitializeComponent();
        }

     

        private void txtTime_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyValue.ToString());
            if (e.KeyValue == 13) {
                if (IsValidTime(txtStartTime.Text))
                {
                    DateTime start = new DateTime(1, 1, 1, hour_in, min_in, 0);
                    DateTime end = start.AddHours(Convert.ToDouble(nm.Value));
                    txtEndTime.Text = end.ToString("HH:mm");
                    nm.Enabled = true;
                }
                else {
                    nm.Enabled = false;
                }               
            }
        }

        private void nm_ValueChanged(object sender, EventArgs e)
        {    
            //check if valid time
            if (IsValidTime(txtStartTime.Text))
            {
                DateTime start = new DateTime(1, 1, 1, hour_in, min_in, 0);
                DateTime end = start.AddHours(Convert.ToDouble(nm.Value));
                txtEndTime.Text = end.ToString("HH:mm");
            }
            else
            {
                nm.Enabled = false;
            }                         


        }

        private Boolean IsValidTime(String i) {
            try
            {
                String[] time = txtStartTime.Text.Split(':');
                hour_in = Convert.ToInt32(time[0]);
                min_in = Convert.ToInt32(time[1]);                              
                DateTime d = new DateTime(1, 1, 1, hour_in, min_in, 0);
                return true;
            }
            catch (Exception e) {
                Global.error = e;
                return false;
            }
        }

        private void txtEndTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (IsValidTime(txtStartTime.Text))
                {
                    DateTime start = new DateTime(1, 1, 1, hour_in, min_in, 0);
                    DateTime end = start.AddHours(Convert.ToDouble(nm.Value));
                    txtEndTime.Text = end.ToString("HH:mm");
                    nm.Enabled = true;
                }
                else
                {
                    nm.Enabled = false;
                }
            }

        }
    }
}
