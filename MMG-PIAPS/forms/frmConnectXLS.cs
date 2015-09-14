using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.modules;
using System.Data.OleDb;
using MMG_PIAPS.classes;
namespace MMG_PIAPS.forms
{
    public partial class frmConnectXLS : Form
    {

        DataTable dTable = new DataTable();
        DataTable dtmigrated = new DataTable();
        BindingSource bs = new BindingSource();

        
        public frmConnectXLS()
        {
            InitializeComponent();
        }

      
        private void btnLoadExcel_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            
            // image filters

            open.Filter = "Microsoft Excel Files|*.xlsx";
            if (open.ShowDialog() == DialogResult.OK) {
                

                if (db.CONNECTEXCEL(open.FileName))
                {
                    string strSQL = "SELECT * FROM [sheet$A1:F10000]";

                    OleDbCommand dbCommand = new OleDbCommand(strSQL, db.excelcon);
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);

                    // create data table                   

                    dataAdapter.Fill(dTable);

                    // bind the datasource
                    bindingSource.DataSource = dTable;
                    // assign the dataBindingSrc to the DataGridView
                    dgvExcelList.DataSource = bindingSource;
                    dgvExcelList.Refresh();

                }
                else
                {
                    MessageBox.Show("Error : " + db.err.Message);
                }
            
            }
            
              



           
        }

        private void btnMigrate_Click(object sender, EventArgs e)
        {
            
            DataTable dt = dTable;
            dtmigrated = dt.Clone();
            dtmigrated.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                Member m = new Member();
                //STATUS 2==WITHDRAWN
                if (Convert.ToInt16(row["status"].ToString()) == 2)
                {
                    m.status = "WITHDRAWN";
                }
                else if (Convert.ToInt16(row["status"].ToString()) == 1)
                {
                    m.status = "STAFF";
                }
                else {
                    m.status = "REGULAR";
                }

                String[] names = row["name"].ToString().Split(',');

                m.lname = names[0];

                String[] fmname = names[1].Split(' ');
                
                String fname = "";
                for (int x = 0; x < fmname.Length-1; x++) {
                    fname += fmname[x].Trim() + " ";
                }

                m.mname = fmname[fmname.Length-1];

                m.fname = fname;
                m.memid = row["name"].ToString().Substring(0, 3) + "-" + row["No"].ToString();

                if (m.save())
                {
                    dtmigrated.ImportRow(row);     
                }
               
                 
            }
          
            bs.DataSource = dtmigrated;
            dgvimport.DataSource = bs;

            dgvimport.Refresh();

        }

        private void frmConnectXLS_Load(object sender, EventArgs e)
        {

        }
    }
}
