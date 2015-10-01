using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.userctrl.custom
{
    public partial class mit_decimal_textbox : UserControl
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else {
                e.Handled = true;
            }
        }

        
        public mit_decimal_textbox()
        {
            InitializeComponent();
        }
    }
}
