using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMG_PIAPS.classes
{
    class Payroll_Generator
    {

        private Employee emp = new Employee();
        private List<Attendance> attendance = new List<Attendance> { };
        private List<Cutoff_Details> cutoff = new List<Cutoff_Details> { };
        
        private decimal MONTHLY_RATE = 0;
        private decimal DAILY_RATE = 0;//AKA RATE_PER_DAY
        private decimal HOURLY_RATE = 0;//AKA RATE_PER_HOUR
        //private decimal MINUTELY_RATE = 0;//AKA RATE_PER_MINUTE


        public Payroll_Generator(Employee empparam, List<Attendance> attendanceparam, List<Cutoff_Details> cutoffparam) {

            this.emp = empparam;
            this.attendance = attendanceparam;
            this.cutoff = cutoffparam;

            MONTHLY_RATE = emp.GET_BASIC_PAY();
            DAILY_RATE = MONTHLY_RATE / 26;

            string EMP_STATUS = emp.GET_EMPLOYMENT_STATUS();

            HOURLY_RATE = (EMP_STATUS == "Regular") ? DAILY_RATE / 7 : DAILY_RATE / 8;

       }
        
    }
}
