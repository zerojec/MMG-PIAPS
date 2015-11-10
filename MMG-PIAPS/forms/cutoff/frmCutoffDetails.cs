using MMG_PIAPS.classes;
using MMG_PIAPS.userctrl.cutoff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.forms.cutoff
{
    public partial class frmCutoffDetails : Form
    {

        public Cutoff_Details cd = new Cutoff_Details();

        public frmCutoffDetails()
        {
            InitializeComponent();
        }

        private void frmCutoffDetails_Load(object sender, EventArgs e)
        {
            cutoff_details_ctrl cdctrl = new cutoff_details_ctrl();
            cdctrl.cd = cd;

            cdctrl.Dock = DockStyle.Fill;
            this.Controls.Add(cdctrl);
            this.Text = "Cutoff-Details : " + cd.cutoff_id;

        }
    }
}
