﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using MMG_PIAPS.forms.cutoff;
using MMG_PIAPS.modules;
using MMG_PIAPS.userctrl.payroll_generator;

namespace MMG_PIAPS.userctrl.cutoff
{
    public partial class cutoff_ctrl : UserControl
    {
        public cutoff_ctrl()
        {
            InitializeComponent();
        }

        private void cutoff_ctrl_Load(object sender, EventArgs e)
        {
            Cutoff c = new Cutoff();
            c.LoadOnListView(lv);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            cutoff_new c = new cutoff_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void CutoffDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {

                string cutoff_id = lv.SelectedItems[0].SubItems[1].Text;

                Cutoff_Details cd1 = new Cutoff_Details();

                cd1.cutoff_id = cutoff_id;

                frmCutoffDetails frm = new frmCutoffDetails();
                frm.WindowState = FormWindowState.Normal;
                frm.cd = cd1;

                frm.ShowDialog();
                

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {

                string cutoff_id = lv.SelectedItems[0].SubItems[1].Text;

                Cutoff cd1 = new Cutoff();

                cd1.cutoff_id = cutoff_id;

                if (MessageBox.Show("Are you sure you want to delete this cutoff?.", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                    if (cd1.delete())
                    {
                        MessageBox.Show("Successful","Delete");
                    }
                    else {
                        MessageBox.Show("Tehere was a problem deleting this cutoff.\n\n Message :" + db.err.Message);
                    }
                }
            }
        }

        private void generatePayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lv.SelectedItems.Count > 0)
            {

                string cutoff_id = lv.SelectedItems[0].SubItems[1].Text;
                Cutoff c, c1 = new Cutoff();
                c1.cutoff_id = cutoff_id;
                c= c1.SELECT_BY_ID();


                //PAYROLL GENERATOR USER INTERFACE
                payroll_generator_ctrl pgctrl = new payroll_generator_ctrl();


                //PASS A DATATABLE TO PAYROLL GENERATOR
                Cutoff_Details cd1 = new Cutoff_Details();
                cd1.cutoff_id = c1.cutoff_id;
                DataTable cutoffdetailsdt = cd1.SELECT_BYID();

                pgctrl.cutoffdetailsdt = cutoffdetailsdt;

                pnlops.Controls.Clear();

                pgctrl.cutoff = c;
                pgctrl.Width = pnlops.Width;
                pnlops.Height = pgctrl.Height;
                pnlops.Controls.Add(pgctrl);
                


               
            }

        }

      
    }
}
