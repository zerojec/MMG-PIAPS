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
            pb.Maximum = 0;
            total = getlinetotal();
            pb.Maximum = total;
            lblstatus.Text = "0/" + total.ToString();
            if(total!=0){            
                bgAnalyzer.RunWorkerAsync();
            }

        }//END OPEN_FILE


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
                    //line = r.ReadLine();
                    String[] str= line.Split('\t');
                    String empid, date_time, state,work_code;
                    empid = str[0];
                    date_time = str[1];
                    state = str[2];
                    work_code= str[3];

                    Attendance a = new Attendance();
                    a.empid = Convert.ToInt32(empid);
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

        private void bgAnalyzer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblstatus.Text = e.ProgressPercentage.ToString() + "/" + total.ToString();
            pb.Value = Convert.ToInt32(e.ProgressPercentage);
        }

        private void bgAnalyzer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Finished","Reading Attendance Log");
        }
           
      }//END USER CONTROL
}//END NAMESPACE

