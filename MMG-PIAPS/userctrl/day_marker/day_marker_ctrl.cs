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
    public partial class day_marker_ctrl : UserControl
    {

       




        public day_marker_ctrl()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            day_marker_new c = new day_marker_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);

        }

        private void day_marker_ctrl_Load(object sender, EventArgs e)
        {
            Day_Marker dm = new Day_Marker();
            dm.LoadInListView(lv);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (lv.SelectedItems.Count > 0)
            {
                pnlops.Controls.Clear();

                String dateoftheyear = lv.SelectedItems[0].SubItems[1].Text;                

                Day_Marker dm = new Day_Marker();

                day_marker_update c = new day_marker_update();


               // MessageBox.Show(dateoftheyear);

                c.dm = dm.SELECT_BY_DATE(dateoftheyear);

                c.Width = pnlops.Width;
                pnlops.Height = c.Height;

                pnlops.Controls.Add(c);
            }
            else {
                MessageBox.Show("Nothing Selected");
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {
               
                Day_Marker dm = new Day_Marker();
                String dateoftheyear = lv.SelectedItems[0].SubItems[1].Text;    
              if(MessageBox.Show("Please confirm delete of this item. ","Delete?", MessageBoxButtons.YesNo)== DialogResult.Yes)
              {
                if(dm.delete(dateoftheyear)){
                        MessageBox.Show("Successful","Delete");
                 }else{
                 MessageBox.Show("There was a problem deleting this item.");
                }
              }

            }
            else
            {
                MessageBox.Show("Nothing Selected");
            }
        }
    }
}
