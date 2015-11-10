using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;

namespace MMG_PIAPS.userctrl.cutoff
{
    public partial class cutoff_details_ctrl : UserControl
    {

        public Cutoff_Details cd = new Cutoff_Details();

        public cutoff_details_ctrl()
        {
            InitializeComponent();
        }

        private void cutoff_details_ctrl_Load(object sender, EventArgs e)
        {            
                
        }

        private void cutoff_details_ctrl_ControlAdded(object sender, ControlEventArgs e)
        {
           
        }

        private void cutoff_details_ctrl_Paint(object sender, PaintEventArgs e)
        {
            cd.LoadOnListView(lv);      
        }

       
    }
}
