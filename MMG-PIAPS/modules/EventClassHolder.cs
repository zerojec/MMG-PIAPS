using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.modules
{
    public class EventClassHolder
    {

        public void onKeyDownToUpper(object sender, KeyPressEventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.Text = e.KeyChar.ToString().ToUpper();
           
        }
    }
}
