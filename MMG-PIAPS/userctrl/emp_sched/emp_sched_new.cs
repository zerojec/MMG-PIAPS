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
using System.IO;

namespace MMG_PIAPS.userctrl.emp_sched
{
    public partial class emp_sched_new : UserControl
    {
        Employee emp = new Employee();

        public emp_sched_new()
        {
            InitializeComponent();
        }

        private void emp_sched_new_Load(object sender, EventArgs e)
        {            
            emp.LoadEmployee(cboEmp);
            Schedule s = new Schedule();
            s.LoadSchedules(this.monday.combobox);
            s.LoadSchedules(this.tuesday.combobox);
            s.LoadSchedules(this.wednesday.combobox);
            s.LoadSchedules(this.thursday.combobox);
            s.LoadSchedules(this.friday.combobox);
            s.LoadSchedules(this.saturday.combobox);
            s.LoadSchedules(this.sunday.combobox);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int total= monday.hours_allocated + tuesday.hours_allocated+ wednesday.hours_allocated+ thursday.hours_allocated + friday.hours_allocated + saturday.hours_allocated +sunday.hours_allocated;
            lblTotalHours.Text = "Total Hours for 1 WEEK :" + total.ToString();
        }

        private void cboEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmp.Text != "") 
            { 
                String[] c = cboEmp.Text.ToString().Split('-');
                String id = c[1];
                Employee emp1, emp2 = new Employee();
                emp2.empid = Convert.ToInt32(id);

                emp1=emp2.SELECT_BY_ID();
                emp = emp1;
                //emp1.SELECT_BY_ID();
                emp1.GET_IMAGE_BY_ID();
            
                String pos = (emp1.GET_CURRENT_POSITION() != "") ? emp1.position.ToString() : "NO_POSITION_INDICATED";
                lblemp.Text = emp1.lname.ToUpper() + ", " + emp1.fname.ToUpper() + " " + emp1.mname.ToUpper() + " - " + pos;                   

                if (emp1.pic != null)
                    {
                        MemoryStream ms = new MemoryStream(emp1.pic);
                        pb.Image = Image.FromStream(ms);
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pb.Image = Properties.Resources.noimagefound;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                    }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Emp_Sched es = new Emp_Sched();
            es.empid = emp.empid;

            es.mon = (monday.ischecked) ? monday.combobox.Text : "";
            es.tue = (tuesday.ischecked) ? tuesday.combobox.Text : "";
            es.wed = (wednesday.ischecked) ? wednesday.combobox.Text : "";
            es.thu = (thursday.ischecked) ? thursday.combobox.Text : "";
            es.fri = (friday.ischecked) ? friday.combobox.Text : "";
            es.sat = (saturday.ischecked) ? saturday.combobox.Text : "";
            es.sun = (sunday.ischecked) ? sunday.combobox.Text : "";

            if (es.save())
            {
                MessageBox.Show("Successful", "Save");
            }
            else {
                MessageBox.Show("There was a problem saving new Employee Schedule : \n\n" + db.err.Message , "Failed");
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
