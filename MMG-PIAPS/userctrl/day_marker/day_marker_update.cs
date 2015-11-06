using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.day_marker
{
    public partial class day_marker_update : UserControl
    {
        public Day_Marker dm = new Day_Marker();

        public day_marker_update()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }

        private void day_marker_update_Load(object sender, EventArgs e)
        {

          
                dtdateoftheyear.Value = dm.dateoftheyear;
                txtdescription.Text = dm.name_of_holiday;
                cbotype.Text = dm.type_;
          
               
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtdescription.Text != "" && cbotype.Text != "")
            {                              
                dm.type_ = cbotype.Text;
                dm.name_of_holiday = txtdescription.Text;

                if (dm.update())
                {
                    MessageBox.Show("Successful", "Update");
                }
                else
                {
                    MessageBox.Show("There was a problem updating this holiday.");

                }

            }
        }
    

    
    
    
    
    
    
    
    
    
    
    }
}
