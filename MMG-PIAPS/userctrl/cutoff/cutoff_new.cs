using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using MMG_PIAPS.modules;

namespace MMG_PIAPS.userctrl.cutoff
{
    public partial class cutoff_new : UserControl
    {
        public cutoff_new()
        {
            InitializeComponent();
        }

        private void dtfrom_date_ValueChanged(object sender, EventArgs e)
        {

            txtcutoff_id.Text = dtfrom_date.Value.ToString("MMddyyyy") + dtto_date.Value.ToString("MMddyyyy");

        }

        private void dtto_date_ValueChanged(object sender, EventArgs e)
        {
            txtcutoff_id.Text = dtfrom_date.Value.ToString("MMddyyyy") + dtto_date.Value.ToString("MMddyyyy");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Cutoff c = new Cutoff();
            txtcutoff_id.Text = dtfrom_date.Value.ToString("MMddyyyy") + dtto_date.Value.ToString("MMddyyyy");
            c.cutoff_id = txtcutoff_id.Text;
            c.from_date = dtfrom_date.Value;
            c.to_date = dtto_date.Value;

            TimeSpan numofdays = c.to_date.Subtract(c.from_date);

            

            if (c.save())
            {

                for (int x = 0; x <= numofdays.Days; x++) {
                   
                    
                    Cutoff_Details cd = new Cutoff_Details();
                    Day_Marker dm, dm1 = new Day_Marker();


                    DateTime thisdate = c.from_date.AddDays(x);
                    
                    
                    //MessageBox.Show(thisdate.ToString("MMMM-d"));
                    //CHECK FOR HOLIDAYS IN THE DAY MARKER TABLE
                    dm= dm1.SELECT_BY_DATE(thisdate.ToString("MMMM-d"));


                     String day_type="";
                     String holiday_name="";
                    

                     if (thisdate.ToString("dddd") == "Sunday")
                    {
                        day_type = "REST_DAY";
                       
                    }
                    else {
                        day_type = (dm != null) ? dm.type_ : "REGULAR_DAY";
                        holiday_name = (dm != null) ? dm.name_of_holiday : "";
                    }
                    

                    cd.cutoff_id = c.cutoff_id;
                    cd.date_ = thisdate;
                    cd.day_type = day_type;
                    cd.holiday_name = holiday_name;

                    cd.save();

                    //MessageBox.Show(day_type + "-" + holiday_name);

                }

                MessageBox.Show("Successful.", "Saving Cutoff");
            }
            else
            {
                MessageBox.Show("There was a problem saving this cutoff.\n\n Message :" + db.err.Message, "Saving Cutoff");
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
