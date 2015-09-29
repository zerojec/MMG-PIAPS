using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.modules;
using MMG_PIAPS.classes;
using System.Reflection;

namespace MMG_PIAPS.userctrl.emp_restriction
{
    public partial class emp_restriction_current_user : UserControl
    {
        public emp_restriction_current_user()
        {
            InitializeComponent();
        }

        private void cboEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void GenereateCheckBoxes(object obj)
        {

            var properties = GetProperties(obj);


            //MessageBox.Show(properties.Length.ToString());
            CheckBox[] chk = new CheckBox[properties.Length - 1];

            int ctr = 0;

            for (ctr = 0; ctr < properties.Length - 2; ctr++)
            {


                var p = properties[ctr];

                string name = p.Name;
                var value = p.GetValue(obj, null);

                if (name == "empid")
                    continue;

                chk[ctr] = new CheckBox();
                chk[ctr].Name = name;
                chk[ctr].Text = name;

                //MessageBox.Show(value.ToString());
                if (value.ToString() == "True")
                {
                    chk[ctr].Checked = true;
                }
                else
                {
                    chk[ctr].Checked = false;
                }

                chk[ctr].Dock = DockStyle.Top;


                //ADD EVENT
                if (Global.CURRENT_USER.restriction.CAN_UPDATE_RESTRICTION)
                {
                    chk[ctr].Enabled = true;
                    chk[ctr].CheckedChanged += new EventHandler(this.chk_checkchanged);
                }
                else {
                    chk[ctr].Enabled = false;
                }
               
                pnlrestrictions.Controls.Add(chk[ctr]);

            }

        }// end GENERATE CHECK BOXES






        protected void chk_checkchanged(object sender, EventArgs e)
        {
            Emp_Restriction er = new Emp_Restriction();
            er.empid = Global.CURRENT_USER.empid;
            // identify which button was clicked and perform necessary actions
            CheckBox chk = sender as CheckBox;

            if (er.Toggle(er.empid, chk.Name, chk.Checked))
            {
                chk.Checked = chk.Checked;
            }
            else
            {
                MessageBox.Show("There was a problem updating restriction. : \n" + db.err.Message);
                chk.Checked = chk.Checked;
            }
        }



        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        private void emp_restriction_current_user_Load(object sender, EventArgs e)
        {
            Emp_Restriction er, er2 = new Emp_Restriction();
            er2.empid = Global.CURRENT_USER.empid;
            er = er2.SELECT_BY_ID();

            //LOOP THROUGH ALL RESTRICTIONS THEN ADD A CHECKBOX FOR EACH RESTRICTION

            GenereateCheckBoxes(er);
        }


    }
}
