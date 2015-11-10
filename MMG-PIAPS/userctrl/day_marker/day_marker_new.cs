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
    public partial class day_marker_new : UserControl
    {
        public day_marker_new()
        {
            InitializeComponent();
        }

        private void cboleavetype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtdescription.Text != "" && cbotype.Text != "") {

                Day_Marker dm = new Day_Marker();
                dm.dateoftheyear = dtdateoftheyear.Value;
                dm.type_ = cbotype.Text;
                dm.name_of_holiday = txtdescription.Text;

                if (dm.save())
                {
                    MessageBox.Show("Successful", "Save");
                }
                else {
                    MessageBox.Show("There was a problem saving this holiday.");

                }

            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Parent.Height = 0;
            this.Parent.Controls.Clear();
            this.Dispose();
        }
    }
}
