using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.attendance
{
    public partial class attendance_new : UserControl
    {

        int total = 0;
        OpenFileDialog fd = new OpenFileDialog();
        string filename = "";

        public attendance_new()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            
            
            if (btnOpenFile.Text == "Cancel")
            {

             

                if (bgAnalyzer.IsBusy) {
                    if (bgAnalyzer.WorkerSupportsCancellation)
                    {
                        bgAnalyzer.CancelAsync();
                        btnOpenFile.Text = "Open Attendance Log";
                        ENABLE_MAIN_BUTTONS();
                      
                    }
                }
               
            }
            else {
              
                pb.Maximum = 0;
                total = getlinetotal();
                pb.Maximum = total;
                lblstatus.Text = "0/" + total.ToString();
                if (total != 0)
                {
                    bgAnalyzer.RunWorkerAsync();
                    btnOpenFile.Text = "Cancel";
                    DISABLE_MAIN_BUTTONS();
                   
                }
            }
           

        }//END OPEN_FILE


        public void DISABLE_MAIN_BUTTONS() {

            try {
                Form f = btnOpenFile.Parent.Parent.FindForm();

                Control[] btnEmp = f.Controls.Find("btnEmployee", true);
                btnEmp[0].Enabled = false;

                Control[] btnMembershiData = f.Controls.Find("btnMembershipData", true);
                btnMembershiData[0].Enabled = false;

                Control[] btnAttendance = f.Controls.Find("btnAttendance", true);
                btnAttendance[0].Enabled = false;

             Control[] btnNew = this.Parent.Parent.Controls.Find("btnNew", true);
                btnNew[0].Enabled = false;

                btnCancel.Enabled = false;
            }catch(Exception err){
                Logger.WriteErrorLog(err.Message);
            }
           
        }


        public void ENABLE_MAIN_BUTTONS()
        {

            try { 
            Form f = btnOpenFile.Parent.Parent.FindForm();

            Control[] btnEmp = f.Controls.Find("btnEmployee", true);
            btnEmp[0].Enabled = true;

            Control[] btnMembershiData = f.Controls.Find("btnMembershipData", true);
            btnMembershiData[0].Enabled = true;

            Control[] btnAttendance = f.Controls.Find("btnAttendance", true);
            btnAttendance[0].Enabled = true;

          
            Control[] btnNew = this.Parent.Parent.Controls.Find("btnNew", true);
            btnNew[0].Enabled = true;
            
            btnCancel.Enabled = true;
                }catch(Exception err){
                    Logger.WriteErrorLog(err.Message);
                }

        }


        private int getlinetotal() {
            int t = 0;
           
            fd.Filter = "Dat Files (*.dat)|*.dat";
          
            if (fd.ShowDialog() == DialogResult.OK)
            {
                filename = fd.FileName;
                StreamReader r = new StreamReader(filename);

                String line = "";
                int ctr = 0;
                while (r.Peek() != -1)
                {
                    line = r.ReadLine();
                    ctr++;
                }
                t = ctr;                     
            }
            else
            {
                t = 0;
            }
            return t;

        }//END GETLINETOTAL

        private void bgAnalyzer_DoWork(object sender, DoWorkEventArgs e)
        {

                      
            filename = fd.FileName;
            StreamReader r = new StreamReader(filename);            
            int ctr = 0;
            string line="";
            while ((line = r.ReadLine()) != null)
                {
                    if (bgAnalyzer.CancellationPending)
                    {
                        //bgAnalyzer.ReportProgress(100);
                        e.Cancel = true;
                    }
                    else {
                        //line = r.ReadLine();
                        String[] str = line.Split('\t');
                        String empid, date_time, state, work_code;
                        empid = str[0];
                        date_time = str[1];
                        state = str[2];
                        work_code = str[3];

                        Attendance a = new Attendance();
                        a.empid = empid;
                        a.date_time = Convert.ToDateTime(date_time);
                        a.state = Convert.ToInt32(state);
                        a.work_code = Convert.ToInt32(work_code);
                        a.work_code = 1;

                        if (a.save())
                        {
                            ctr++;
                            bgAnalyzer.ReportProgress(ctr);
                            System.Threading.Thread.Sleep(10);
                        }

                    }
                   
                   
                   
                }             
        }

        private void bgAnalyzer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblstatus.Text = e.ProgressPercentage.ToString() + "/" + total.ToString();
            pb.Value = Convert.ToInt32(e.ProgressPercentage);
        }

        private void bgAnalyzer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Finished","Reading Attendance Log");
            pb.Value = 0;
            lblstatus.Text = "0/0";

            ENABLE_MAIN_BUTTONS();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();      
            this.Dispose();
        }
           
      }//END USER CONTROL
}//END NAMESPACE

