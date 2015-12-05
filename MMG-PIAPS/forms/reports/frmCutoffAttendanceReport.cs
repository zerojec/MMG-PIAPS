using Microsoft.Reporting.WinForms;
using MMG_PIAPS.classes;
using MMG_PIAPS.datasets;
using MMG_PIAPS.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.forms.reports
{

    

  

    public partial class frmCutoffAttendanceReport : Form
    {


        public DateTime cutoff_date_from;
        public DateTime cutoff_date_to;

        public DataTable attendancedt;
        public DataTable cutoffdetailsdt;
        public Emp_Sched empsched = new Emp_Sched();

        DataTable cutoffdt;

        public frmCutoffAttendanceReport()
        {
            InitializeComponent();
        }

        private void frmCutoffAttendanceReport_Load(object sender, EventArgs e)
        {

            this.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.rptViewer.LocalReport.DataSources.Clear();


            string path = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            var directory = System.IO.Path.GetDirectoryName(path);
            directory += "\\reports\\atttendance_cutoff.rdlc";


          
            //C:\projects\MMG-PIAPS\MMG-PIAPS\bin\Debug\reports\cutoff_attendance.rdlc
            //C:\projects\MMG-PIAPS\MMG-PIAPS\bin\Debug\reports\atttendance_cutoff.rdlc
            this.rptViewer.LocalReport.ReportPath = directory;

            //MessageBox.Show(directory);

            Employee emp = new Employee();
            emp.branch = "2";

            DataTable dt = emp.SELECT_BY_BRANCH();



            DataSet1 ds = new DataSet1();
            cutoffdt = ds.Tables["cutoffattendance"];


            
            //CREATE AN IMAGE COLUMN
            //SET THE IMAGE VALUE
            //THEN ADD TO DATASET FOR REPORT REFERENCE
            DataColumn colByteArray = new DataColumn("emp_img");
            colByteArray.DataType = System.Type.GetType("System.Byte[]");
            dt.Columns.Add(colByteArray);

            foreach (DataRow item in dt.Rows) {
                                     
                Employee e1 = new Employee();
                e1.empid = item["empid"].ToString();
                item["emp_img"] = e1.GET_IMAGE_BY_ID();  
                
                //=====================================



                int x = 1;
                foreach (DataRow cutoffitem in cutoffdetailsdt.Rows)
                {

                    DataRow c = cutoffdt.NewRow();

                    DateTime d = Convert.ToDateTime(cutoffitem["date_"].ToString());
                    c.BeginEdit();
                    c["empid"] = e1.empid;
                    c["no"] = x;
                    c["date_"] = d.ToString("MM/dd/yyyy");


                    //CRREATE A DYNAMIC CONNECTION TO DB
                    non_static_dbcon cn = new non_static_dbcon();
                        
                    //COMPARE CUTOFF DATE WITH ATTENDANCE HERE
                    //==============================================
                    String attendance;
                    if (cn.CONNECT())
                    {
                        Attendance att = new Attendance();
                        att.empid = e1.empid;

                        attendance = att.SELECT_STR_BY_EMPID_BY_DATE(d, cn);
                    }
                    else {
                        attendance = "";
                    }

                    cn.DISCONNECT();

                    c["attendance_"] = attendance;

                    //===============================================
                    c["day_type"] = cutoffitem["day_type"].ToString();
                    c["status_"] = "GOOD";
                    cutoffdt.Rows.Add(c);

                    x++;
                }

                //=====================================
            }//end foreach item in dt.rows
            ReportDataSource r = new ReportDataSource("DataSet1", dt);







            //SETUP CUTOFF_DETAILS WITH ATTENDANCE
            //WILL PRINTOUT CUTOFF DATES
            //THEN PRINT ATTENDANCE IF THE EMPLOYEE
            //HAS ATTENDANCE ON THAT DATE          
           

          


            this.rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);






            //SET REPORT PARAMETER
            ReportParameter from_date = new ReportParameter("cutoff_date_from", cutoff_date_from.ToString("MM/dd/yyyy"));
            ReportParameter to_date = new ReportParameter("cutoff_date_to", cutoff_date_to.ToString("MM/dd/yyyy"));


            rptViewer.LocalReport.SetParameters(from_date);
            rptViewer.LocalReport.SetParameters(to_date);

            this.rptViewer.LocalReport.DataSources.Add(r);

           // this.rptViewer.SetDisplayMode(DisplayMode.PrintLayout);
            this.rptViewer.RefreshReport();


        }



        void localReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet1", cutoffdt));
        }
    }
}
