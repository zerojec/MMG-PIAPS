using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.userctrl.emp;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl
{
    public partial class emp_ctrl : UserControl
    {
        public emp_ctrl()
        {
            InitializeComponent();
        }

        public void LoadAllEployees() { 
        
         Employee emp= new Employee();

            DataTable dt = new DataTable();
            dt = emp.SELECT_ALL();

            if (dt != null) { 
                int num=1;
                foreach(DataRow r in dt.Rows){
                    ListViewItem li = new ListViewItem();
                    li.Text = num.ToString();
                    li.SubItems.Add(r["empid"].ToString());
                    li.SubItems.Add(r["lname"].ToString() + ", " + r["fname"].ToString() + " " + r["mname"].ToString());
                    li.SubItems.Add("position");//r["position"].ToString());
                    li.SubItems.Add(r["contactno"].ToString());
                    //li.SubItems.Add(r["gender"].ToString());
                    li.SubItems.Add(r["address"].ToString());


                    lv.Items.Add(li);
                    num++;
                }
            }}

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            emp_new c = new emp_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;

            pnlops.Controls.Add(c);
        }

        private void emp_ctrl_Load(object sender, EventArgs e)
        {
            LoadAllEployees();           
        }
    }
}
