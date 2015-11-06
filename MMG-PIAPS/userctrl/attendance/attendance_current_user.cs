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

namespace MMG_PIAPS.userctrl.attendance
{
    public partial class attendance_current_user : UserControl
    {

        Attendance att = new Attendance();

        public attendance_current_user()
        {
            InitializeComponent();
        }

        private void attendance_current_user_Load(object sender, EventArgs e)
        {
            LoadAtt_BY_EMPID_InListView(lv);
        }





        public void LoadAtt_BY_EMPID_InListView(ListView lv)
        {

            Attendance a = new Attendance();
            DataTable dt = new DataTable();
            //get empid from combobox

            a.empid = Global.CURRENT_USER.empid;
            
            dt = a.SELECT_BY_EMPID();

            if (dt != null)
            {
                lv.Items.Clear();
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(Convert.ToDateTime(r["date_"].ToString()).ToShortDateString());
                    li.SubItems.Add(r["attendance"].ToString());
      
                    // li.SubItems.Add(Convert.ToDateTime(r["date_updated"].ToString()).ToLongDateString());
                    lv.Items.Add(li);
                    ctr++;
                }
            }
            else
            {
                MessageBox.Show("Error");
            }

        }// end load between dates
    }
}
