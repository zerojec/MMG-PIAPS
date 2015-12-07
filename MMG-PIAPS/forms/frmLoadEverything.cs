using MMG_PIAPS.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.forms
{
    public partial class frmLoadEverything : Form
    {
        public frmLoadEverything()
        {
            InitializeComponent();
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Employee emp = new Employee();
            DataTable dt = emp.SELECT_IDS();
           
            if (dt != null)
            {
                int ctr = dt.Rows.Count;               
                for (int x = 0; x < ctr - 1; x++)
                {
                    bgw.ReportProgress(x);
                }
            }
            else{ 
                
            }
            
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb.Value = e.ProgressPercentage;
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();            
            this.Hide();
        }
    }
}
