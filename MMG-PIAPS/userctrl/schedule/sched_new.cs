using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using MMG_PIAPS.modules;

namespace MMG_PIAPS.userctrl.schedule
{
    public partial class sched_new : UserControl
    {

        //int hours_allocated = 0;
        public sched_new()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Schedule s = new Schedule();
            s.first_half_in = new System.DateTime(1, 1, 1, this.first_half.hour_in, this.first_half.min_in, 0);
            s.first_half_out = new System.DateTime(1, 1, 1, this.first_half.hour_out, this.first_half.min_out, 0);

            s.second_half_in = new System.DateTime(1, 1, 1, this.second_half.hour_in, this.second_half.min_in, 0);
            s.second_half_out = new System.DateTime(1, 1, 1, this.second_half.hour_out, this.second_half.min_out, 0);

            s.template_name = txttemplate_name.Text;

            s.hours_allocated = Convert.ToInt32(this.first_half.hoursallocated) + Convert.ToInt32(this.second_half.hoursallocated);
            //MessageBox.Show(s.am_in.ToLongTimeString());
            if (s.save())
            {
                MessageBox.Show("Successful", "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.Parent.Height = 0;
                this.Parent.Controls.Clear();
                this.Dispose();
            }
            else {
                MessageBox.Show("There was a problem saving this template :" + db.err.Message);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String template = first_half.hour_in.ToString() + "-" + first_half.min_in.ToString();
            template += "-" + first_half.hour_out.ToString() + "-" + first_half.min_out.ToString();
            template += "-" + second_half.hour_in.ToString() + "-" + second_half.min_in.ToString();
            template += "-" + second_half.hour_out.ToString() + "-" + second_half.min_out.ToString();
            txttemplate_name.Text = template;
        }

        private void sched_new_Load(object sender, EventArgs e)
        {
            

        }

       
    }
}
