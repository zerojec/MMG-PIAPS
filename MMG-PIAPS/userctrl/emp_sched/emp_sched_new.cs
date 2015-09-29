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
            s.LoadSchedules(this.mon.combobox);
            s.LoadSchedules(this.tue.combobox);
            s.LoadSchedules(this.wed.combobox);
            s.LoadSchedules(this.thu.combobox);
            s.LoadSchedules(this.fri.combobox);
            s.LoadSchedules(this.sat.combobox);
            s.LoadSchedules(this.sun.combobox);
            s.LoadSchedules(this.sched_adjustment.combobox);
     
        }









        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan total = mon.hours_allocated + tue.hours_allocated + wed.hours_allocated + thu.hours_allocated + fri.hours_allocated + sat.hours_allocated + sun.hours_allocated;
            lblTotalHours.Text = "TOTAL HOURS FOR 1 WEEK : " + total.TotalHours.ToString();

            if (sched_adjustment.ischecked)
            {
                lblTotalHours.Text += " + " + sched_adjustment.hours_allocated.TotalHours.ToString() + " EVERY " + cbofirst.Text + " " + cboday.Text + " OF THE MONTH.";
            }
        }


       






        private void cboEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmp.Text != "") 
            { 
                String[] c = cboEmp.Text.ToString().Split('-');
                String id = c[1] + "-" + c[2];
                Employee emp1, emp2 = new Employee();
                emp2.empid =id;

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

            //validate
            bool proceed = (cboEmp.Text == "") ? proceed = false : proceed = true;
            
            //TO COUNT THE NUMBER OF DAYS CHECKED
            int days_selected = 0;

            if (proceed)
            {

                //CHECK IF COMBOBOXES HAVE VALUE
                if (mon.combobox.Text == "") { mon.ischecked = false; } else { days_selected++; }
                if (tue.combobox.Text == "") { tue.ischecked = false; } else { days_selected++; }
                if (wed.combobox.Text == "") { wed.ischecked = false; } else { days_selected++; }
                if (thu.combobox.Text == "") { thu.ischecked = false; } else { days_selected++; }
                if (fri.combobox.Text == "") { fri.ischecked = false; } else { days_selected++; }
                if (sat.combobox.Text == "") { sat.ischecked = false; } else { days_selected++; }
                if (sun.combobox.Text == "") { sun.ischecked = false; } else { days_selected++; }
                if (sched_adjustment.combobox.Text == "") { sched_adjustment.ischecked = false; } else { days_selected++; }

                Emp_Sched es = new Emp_Sched();
                es.empid = emp.empid;

                es.mon = (mon.ischecked) ? mon.combobox.Text : "";
                es.tue = (tue.ischecked) ? tue.combobox.Text : "";
                es.wed = (wed.ischecked) ? wed.combobox.Text : "";
                es.thu = (thu.ischecked) ? thu.combobox.Text : "";
                es.fri = (fri.ischecked) ? fri.combobox.Text : "";
                es.sat = (sat.ischecked) ? sat.combobox.Text : "";
                es.sun = (sun.ischecked) ? sun.combobox.Text : "";

                if (days_selected > 0)
                {
                    if (es.save())
                    {
                        if (sched_adjustment.ischecked)
                        {
                            Emp_Sched_Adjustment esa = new Emp_Sched_Adjustment();

                            esa.empid = es.empid;
                            esa.schedule_template_id = sched_adjustment.combobox.Text;
                            esa.when_applicable = "ALWAYS";
                            esa.adjustment_day = cbofirst.Text + "_" + cboday.Text;


                            if (esa.save())
                            {
                                MessageBox.Show("Successful \n\n Including Schedule Adjustments", "Save");
                            }
                            else
                            {
                                MessageBox.Show("There was a problem saving SCHEDULE_ADJUSTMENT :\n" + db.err.Message);
                            }
                        }
                        else {
                            MessageBox.Show("Successful\n\nSchedule Adjustments not detected.", "Save");
                        }
                    }
                    else
                    {
                        MessageBox.Show("There was a problem saving new Employee Schedule : \n\n" + db.err.Message, "Failed");
                    }

                }
                else
                {
                    MessageBox.Show("Please fill select from schedule templates.");
                }
            }
            else {
                MessageBox.Show("Please select Employee");
            }// END IF PROCEED
        }








        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }









        public void EnableDisableComboxes(Boolean val) {

            if (val)
            {
                cbofirst.Enabled = true;
                cboday.Enabled = true;
            }
            else {
                cbofirst.Enabled = false;
                cboday.Enabled = false;
            }
        }








        private void cboday_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cboday.Text);

            String day_val = "";
            switch (cboday.Text)
            {
                case "MONDAY": { day_val = (!mon.ischecked) ? "MONDAY" : ""; break; }
                case "TUESDAY": { day_val = (!tue.ischecked) ? "TUESDAY" : ""; break; }
                case "WEDNESDAY": { day_val = !(wed.ischecked) ? "WEDNESDAY" : ""; break; }
                case "THURSDAY": { day_val = (!thu.ischecked) ? "THURSDAY" : ""; break; }
                case "FRIDAY": { day_val = (!fri.ischecked) ? "FRIDAY" : ""; break; }
                case "SATURDAY": { day_val = (!sat.ischecked) ? "SATURDAY" : ""; break; }
                case "SUNDAY": { day_val = (!sun.ischecked) ? "SUNDAY" : ""; break; }
                default: { break; }
            }

            if (day_val == "") { cboday.Text = ""; }
        }








        private void cbofirst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




      
              
    }
}
