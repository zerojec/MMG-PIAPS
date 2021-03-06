﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using MMG_PIAPS.forms.attendance;

namespace MMG_PIAPS.userctrl.attendance
{
    public partial class attendance_ctrl : UserControl
    {
        public attendance_ctrl()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            attendance_new c = new attendance_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void attendance_ctrl_Load(object sender, EventArgs e)
        {

            Employee emp = new Employee();
            emp.LoadEmployee(cboEmp);

            Attendance a = new Attendance();
            a.LoadInListView(lv);

            chkDate.Checked = true;
            chkEmp.Checked = true;
          
        }

        private void chkEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmp.Checked) {
                cboEmp.Enabled = true;
            }
            else
            {
                cboEmp.Enabled = false;
                cboEmp.Text = "";
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (chkEmp.Checked==true && chkDate.Checked==true) { 
                //FILTER ATTENDANCE BY EMP AND BY DATE
                LoadAtt_BY_EMPID_BW_DATES_InListView(this.lv);
            }
            else if (chkEmp.Checked==true && chkDate.Checked==false)
            {                
                //FILTER BY ATTENDANCE BY EMP                             
                LoadAtt_BY_EMPID_InListView(this.lv);
            }
            else if(chkDate.Checked==true && chkEmp.Checked==false) { 
               //FILTER ALL ATTENDANCE BY DATE
                LoadAtt_BW_DATES_InListView(this.lv);
            }
        }//end btnfilter



        public void LoadAtt_BY_EMPID_InListView(ListView lv)
        {

            Attendance a = new Attendance();
            DataTable dt = new DataTable();
            //get empid from combobox
            String[] eid = cboEmp.Text.Split('-');
            a.empid = eid[1];

            dt = a.SELECT_BY_EMPID();

            if (dt != null)
            {
                lv.Items.Clear();
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["fullname"].ToString());
                    li.SubItems.Add(r["position_"].ToString());
                    li.SubItems.Add(Convert.ToDateTime(r["date_"].ToString()).ToShortDateString());
                    li.SubItems.Add(r["attendance"].ToString());
                    li.Tag = r["empid"].ToString();

                    // li.SubItems.Add(Convert.ToDateTime(r["date_updated"].ToString()).ToLongDateString());
                    lv.Items.Add(li);
                    ctr++;
                }
            }
            else {
                MessageBox.Show("Error");
            }

        }// end load between dates




        public void LoadAtt_BW_DATES_InListView(ListView lv)
        {

            Attendance a = new Attendance();
            DataTable dt = new DataTable();

            dt = a.SELECT_BETWEEN_DATES(dtpFrom.Value, dtpTo.Value);
            if (dt != null)
            {
                lv.Items.Clear();
                int ctr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = ctr.ToString();
                    li.SubItems.Add(r["fullname"].ToString());
                    li.SubItems.Add(r["position_"].ToString());
                    li.SubItems.Add(Convert.ToDateTime(r["date_"].ToString()).ToString("MMMM dd, yyyy"));
                    li.SubItems.Add(Convert.ToDateTime(r["attendance"].ToString()).ToString("hh:mm:ss tt"));
                 
                    li.Tag = r["empid"].ToString();
                    // li.SubItems.Add(Convert.ToDateTime(r["date_updated"].ToString()).ToLongDateString());
                    lv.Items.Add(li);
                    ctr++;
                }
            }

        }// end load between dates



        public void LoadAtt_BY_EMPID_BW_DATES_InListView(ListView lv)
        {

            Attendance a = new Attendance();
            DataTable dt = new DataTable();
            //get empid from combobox
            if (cboEmp.Text != "") { 

                String[] eid = cboEmp.Text.Split('-');
                a.empid = eid[1];

                dt = a.SELECT_BY_EMPID_BW_DATES(dtpFrom.Value, dtpTo.Value);

                if (dt != null)
                {
                    lv.Items.Clear();
                    int ctr = 1;
                    foreach (DataRow r in dt.Rows)
                    {
                        ListViewItem li = new ListViewItem();
                        li.Text = ctr.ToString();
                        li.SubItems.Add(r["fullname"].ToString());
                        li.SubItems.Add(r["position_"].ToString());
                        li.SubItems.Add(Convert.ToDateTime(r["date_"].ToString()).ToLongDateString());
                        li.SubItems.Add(r["attendance"].ToString());
                        li.Tag = r["empid"].ToString();
                        // li.SubItems.Add(Convert.ToDateTime(r["date_updated"].ToString()).ToLongDateString());
                        lv.Items.Add(li);
                        ctr++;
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }

        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (lv.SelectedItems.Count > 0)
            {
                String id = lv.SelectedItems[0].Tag.ToString();

                DateTime dtime = Convert.ToDateTime(lv.SelectedItems[0].SubItems[3].Text);

                Employee emp, emp1 = new Employee();
                emp1.empid = id;

                emp = emp1.SELECT_BY_ID();

                emp.GET_CURRENT_POSITION();
                emp.GET_IMAGE_BY_ID();

                pnlops.Controls.Clear();

                frmAttendance_Fixer c = new frmAttendance_Fixer();
                c.emp = emp;
                c.thisdate = dtime;
                c.ShowDialog();

            }

        }

    }
}
