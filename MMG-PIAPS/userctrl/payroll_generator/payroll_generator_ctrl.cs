﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.payroll_generator
{
    public partial class payroll_generator_ctrl : UserControl
    {

        List<Employee> lstemp = new List<Employee> { };
        public Cutoff cutoff = new Cutoff();
        public DataTable cutoffdetailsdt= new DataTable();

        public payroll_generator_ctrl()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            pnlops.Controls.Clear();
           
            Employee emp= new Employee();
           
            DataTable empdt = emp.SELECT_ALL();


            label1.Text = "Payroll Generator : FROM :" + cutoff.from_date.ToShortDateString() + " - " + cutoff.to_date.ToShortDateString() + " Total Employee [" + empdt.Rows.Count.ToString() + "]"; 

            foreach (DataRow dr in empdt.Rows)
            {

                String empid = dr["empid"].ToString();       
            
                emp_payroll_new ep = new emp_payroll_new();
                ep.cutoff = cutoff;
                ep.cutoffdetailsdt = cutoffdetailsdt;
                ep.empid = empid; ;
                ep.Dock = DockStyle.Top;
                ep.Width = pnlops.Width - 40;

                pnlops.Controls.Add(ep);

            }

            



        }


        public void employeeadded(Employee e) {

           


        }

        private void payroll_generator_ctrl_Load(object sender, EventArgs e)
        {
            label1.Text = "Payroll Generator : FROM :" + cutoff.from_date.ToShortDateString() + " - " + cutoff.to_date.ToShortDateString();

        }
    }
}
