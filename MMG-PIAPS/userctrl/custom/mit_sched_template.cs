using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using MySql.Data.MySqlClient;

namespace MMG_PIAPS.userctrl.custom
{
    public partial class mit_sched_template : UserControl
    {
        public int hours_allocated { get; set; }
        public String day { get; set; }
        public int empid { get; set; }
        public Boolean ischecked { get { return chk.Checked; } }
        public ComboBox combobox { get { return cbo; } }
        public mit_sched_template()
        {
            InitializeComponent();
        }

        private void mit_sched_template_Load(object sender, EventArgs e)
        {
            hours_allocated = 0;
        }

        private void cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblamin.Text = "AM_IN :";
            lblamout.Text = "AM_OUT :";
            lblpmin.Text = "PM_IN :";
            lblpmout.Text = "PM_OUT :";
            lblhour.Text = "HOUR :";

            if (cbo.Text != "")
            {
                Schedule s, s1 = new Schedule();
                s1.template_name = cbo.Text;
                s = s1.SELECT_BY_TEMPLATE_NAME();
                hours_allocated = s.hours_allocated;

                lblamin.Text += s.first_half_in.ToString("HH:mm");
                lblamout.Text += s.first_half_out.ToString("HH:mm");
                lblpmin.Text += s.second_half_in.ToString("HH:mm");
                lblpmout.Text += s.second_half_out.ToString("HH:mm");
                lblhour.Text = "HOURS :" + hours_allocated.ToString();
               
            }
            else {
                lblamin.Text = "AM_IN :";
                lblamout.Text = "AM_OUT :";
                lblpmin.Text = "PM_IN :";
                lblpmout.Text = "PM_OUT :";
                lblhour.Text = "HOUR :";
                hours_allocated = 0;
            }

        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked)
            {
                cbo.Enabled = true;
            }
            else {
                cbo.Text = "";
                cbo.Enabled = false;
            }
        }

        private void cbo_TextChanged(object sender, EventArgs e)
        {
            if (cbo.Text == "")
            {
                hours_allocated = 0;
                lblamin.Text = "AM_IN :";
                lblamout.Text = "AM_OUT :";
                lblpmin.Text = "PM_IN :";
                lblpmout.Text = "PM_OUT :";
                lblhour.Text = "HOURS :" + hours_allocated.ToString();
                
            }
        }


    }
}
