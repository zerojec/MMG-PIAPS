using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.emp_sched
{
    public partial class emp_sched_new : UserControl
    {
        public emp_sched_new()
        {
            InitializeComponent();

        }

        private void emp_sched_new_Load(object sender, EventArgs e)
        {
            Employee emp = new Employee();
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

        }
    }
}
