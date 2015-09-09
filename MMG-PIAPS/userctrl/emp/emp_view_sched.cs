using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.emp
{
    public partial class emp_view_sched : UserControl
    {
        public Employee emp = new Employee();

        public emp_view_sched()
        {
            InitializeComponent();
        }

        private void emp_view_sched_Load(object sender, EventArgs e)
        {
            String pos = (emp.GET_CURRENT_POSITION() != "") ? emp.position.ToString() : "NO_POSITION_INDICATED";
            lblemp.Text = emp.lname.ToUpper() + ", " + emp.fname.ToUpper() + " " + emp.mname.ToUpper() + " - " + pos;

            if (emp.pic != null)
            {
                MemoryStream ms = new MemoryStream(emp.pic);
                pbEmpPic.Image = Image.FromStream(ms);
                pbEmpPic.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pbEmpPic.Image = Properties.Resources.noimagefound;
                pbEmpPic.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if (emp.schedule !=null)
            {
                lstsched.Items.Add("MONDAY    \t: " + emp.schedule.mon);
                lstsched.Items.Add("TUESDAY   \t: " + emp.schedule.tue);
                lstsched.Items.Add("WEDNESDAY \t: " + emp.schedule.wed);
                lstsched.Items.Add("THURSDAY  \t: " + emp.schedule.thu);
                lstsched.Items.Add("FRIDAY    \t: " + emp.schedule.fri);
                lstsched.Items.Add("SATURDAY  \t: " + emp.schedule.sat);
                lstsched.Items.Add("SUNDAY    \t: " + emp.schedule.sun);   
            }
            else
            {
                lstsched.Items.Add("Nothing found...");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }
    }
}
