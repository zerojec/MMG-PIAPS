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
          
        }

        private void cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Schedule s,s1 = new Schedule();
            s1.template_name = cbo.Text;
            s = s1.SELECT_BY_TEMPLATE_NAME();

            lblamin.Text = s.first_half_in.ToString("HH:mm");
            lblamout.Text = s.first_half_out.ToString("HH:mm");
        }


    }
}
