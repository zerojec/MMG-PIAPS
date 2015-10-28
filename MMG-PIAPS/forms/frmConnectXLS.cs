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

                dTable = null;
                dtmigrated = null;
                bindingSource = null;
                bs = null;
                dgvExcelList.DataSource = null;
                dgvimport.DataSource = null;

                if (db.CONNECTEXCEL(open.FileName))
                {
                    dTable = new DataTable();
                    bindingSource = new BindingSource();

                    //WRITE TO OUTPUT WINDOw
                    System.Diagnostics.Debug.Write(open.FileName);

                    //CREATE DATAtable to retrieve the excel sheet schema
                    DataTable schemadt = db.excelcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    
                    //GET THE FIRST SHEET OF EXCEL FILE
                    DataRow r = schemadt.Rows[0];

                    //GET THE NAME OF THE FIRST SHEET
                    String sheetname = r["TABLE_NAME"].ToString();


                    //QUERY THE FIRST SHEET FROM CELL RANGE "A1 To H1000"
                    string strSQL = "SELECT * FROM [" + sheetname + "A1:H1000]";

                    OleDbCommand dbCommand = new OleDbCommand(strSQL, db.excelcon);
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);


                    // create data table                   

                    dataAdapter.Fill(dTable);

                    System.Diagnostics.Debug.Write(dTable.TableName.ToString());
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
                m.memid = row["Membership_Registry_Number"].ToString();              
                m.fullname = row["Name of Member"].ToString();
                m.address = row["Address"].ToString();
                m.email = row["Email"].ToString();
                m.acceptance_date = Convert.ToDateTime(row["Acceptance_Date"].ToString());
                m.contactno = row["Contact_No"].ToString();
                m.occupation = row["Occupation"].ToString();
                m.status = "ACTIVE"; //STATUS = ACTIVE, STAFF, WITHDRAWN
                m.standing = "IN_GOOD_STANDING"; // STANDING = IN_GOO_STANDING, NOT_IN_GOOD_STANDING
                m.typeofmembership = "REGULAR"; // REGULAR, ASSOCIATE

                if (m.save())
                {
                    System.Diagnostics.Debug.WriteLine(m.memid + "-" + m.fullname + " -->Record Saved");
                }
                else {
                    System.Diagnostics.Debug.WriteLine("Error :" + db.err.Message);
                }
            }
            bs = new BindingSource();

            bs.DataSource = dtmigrated;
          

        }

        private void frmConnectXLS_Load(object sender, EventArgs e)
        {

        }
    }
}
