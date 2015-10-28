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
using MMG_PIAPS.modules;
using MMG_PIAPS.forms;
using System.IO;

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
                    li.SubItems.Add(r["position_"].ToString());//r["position"].ToString());
                    li.SubItems.Add(r["contactno"].ToString());
                    //li.SubItems.Add(r["gender"].ToString());
                    li.SubItems.Add(r["address"].ToString());
                    lv.Items.Add(li);
                    num++;
                }
            }
        }

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

        private void lv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void updateInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {
                 String id = lv.SelectedItems[0].SubItems[1].Text;
           //MessageBox.Show(id);

            Employee emp, emp1 = new Employee();
            emp1.empid = id;

            emp = emp1.SELECT_BY_ID();

            emp.GET_BASIC_PAY();
            emp.GET_BRANCH_ASSIGNMENT();
            emp.GET_EMPLOYMENT_STATUS();
            emp.GET_IMAGE_BY_ID();
            emp.GET_CURRENT_POSITION();

            pnlops.Controls.Clear();

            emp_update c = new emp_update();
            c.emp = emp;
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;

            pnlops.Controls.Add(c);

            
            }
        }

        private void updateBasicSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String id = lv.SelectedItems[0].SubItems[1].Text;

            Employee emp, emp1 = new Employee();
            emp1.empid = id;
            emp = emp1.SELECT_BY_ID();
            emp.GET_BASIC_PAY();
            //emp.GET_BRANCH_ASSIGNMENT();
            //emp.GET_EMPLOYMENT_STATUS();
            emp.GET_IMAGE_BY_ID();
            emp.GET_CURRENT_POSITION();
           
            pnlops.Controls.Clear();

          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pnlops_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewBenefitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {
                String id = lv.SelectedItems[0].SubItems[1].Text;
                //MessageBox.Show(id);

                Employee emp, emp1 = new Employee();
                emp1.empid = id;
                emp = emp1.SELECT_BY_ID();
                emp.GET_BASIC_PAY();
                emp.GET_BRANCH_ASSIGNMENT();
                emp.GET_EMPLOYMENT_STATUS();
                emp.GET_IMAGE_BY_ID();
                emp.GET_CURRENT_POSITION();
                emp.LIST_BENEFITS();
                pnlops.Controls.Clear();

                emp_view_benefit c = new emp_view_benefit();
                c.emp = emp;
                c.Width = pnlops.Width;
                pnlops.Height = c.Height;

                pnlops.Controls.Add(c);


            }
        }

        private void viewScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String id = lv.SelectedItems[0].SubItems[1].Text;
            //MessageBox.Show(id);

            Employee emp, emp1 = new Employee();
            emp1.empid = id;
            emp = emp1.SELECT_BY_ID();
            emp.GET_BASIC_PAY();
            emp.GET_BRANCH_ASSIGNMENT();
            emp.GET_EMPLOYMENT_STATUS();
            emp.GET_IMAGE_BY_ID();
            emp.GET_CURRENT_POSITION();
            emp.LIST_BENEFITS();
            pnlops.Controls.Clear();

            Emp_Sched es = new Emp_Sched();
            es.empid = emp.empid;
            emp.schedule= es.SELECT_BY_EMPID();


            emp_view_sched c = new emp_view_sched();
            c.emp = emp;
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;

            pnlops.Controls.Add(c);
        }
    }
}
