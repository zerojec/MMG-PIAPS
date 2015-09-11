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
namespace MMG_PIAPS.forms
{
    public partial class frmConnectXLS : Form
    {

        public frmConnectXLS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            if (db.CONNECTEXCEL())
            {
                //MessageBox.Show("Connected");
                MessageBox.Show(db.directory);

                string strSQL = "SELECT * FROM [sheet$A1:F13]";

                OleDbCommand dbCommand = new OleDbCommand(strSQL,db.excelcon);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);

                // create data table
                DataTable dTable = new DataTable();

                dataAdapter.Fill(dTable);

                // bind the datasource
                bindingSource.DataSource = dTable;
                // assign the dataBindingSrc to the DataGridView
                dgvExcelList.DataSource = bindingSource;

                dgvExcelList.Refresh();

            }
            else {
                MessageBox.Show("Error : " + db.err.Message);
            }

        }
    }
}
