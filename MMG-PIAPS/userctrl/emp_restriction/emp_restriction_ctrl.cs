using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.classes;
using System.IO;
using System.Reflection;
using MMG_PIAPS.modules;

namespace MMG_PIAPS.userctrl.emp_restriction
{
    public partial class emp_restriction_ctrl : UserControl
    {
        Employee emp = new Employee();
        public emp_restriction_ctrl()
        {
            InitializeComponent();
        }

        private void emp_restriction_ctrl_Load(object sender, EventArgs e)
        {
            emp.LoadEmployee(cboEmp);
        }

        private void cboEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlrestrictions.Controls.Clear();

            if (cboEmp.Text != "")
            {
                String[] c = cboEmp.Text.ToString().Split('-');
                String id = c[1];
                Employee emp1, emp2 = new Employee();
                emp2.empid = id;

                emp1 = emp2.SELECT_BY_ID();
                emp = emp1;

                //emp1.SELECT_BY_ID();                                
                emp1.GET_IMAGE_BY_ID();
            

                String pos = (emp1.GET_CURRENT_POSITION() != "") ? emp1.position.ToString() : "NO_POSITION_INDICATED";
                lblemp.Text = emp1.lname.ToUpper() + ", " + emp1.fname.ToUpper() + " " + emp1.mname.ToUpper() + " - " + pos;
             
                if (emp1.pic != null)
                {
                    MemoryStream ms = new MemoryStream(emp1.pic);
                    pb.Image = Image.FromStream(ms);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pb.Image = Properties.Resources.noimagefound;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }

                //GET THE RESTRICTIONS
                Emp_Restriction er, er2 = new Emp_Restriction();
                er2.empid = emp.empid;
                er = er2.SELECT_BY_ID();
                
                //LOOP THROUGH ALL RESTRICTIONS THEN ADD A CHECKBOX FOR EACH RESTRICTION

                GenereateCheckBoxes(er);


            }
        }//end selected index changed



        //FUNCTION TO GENERATE CHECKBOXES ACCORDING TO 
        //THE NUMBER OF PROPERTIES OF AN OBJECT
        private void GenereateCheckBoxes(object obj) {

            var properties = GetProperties(obj);
           

            //MessageBox.Show(properties.Length.ToString());
            CheckBox[] chk = new CheckBox[properties.Length-1];

            int ctr = 0;

            for (ctr = 0; ctr < properties.Length-1; ctr++ )
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
                chk[ctr].CheckedChanged += new EventHandler(this.chk_checkchanged);


                pnlrestrictions.Controls.Add(chk[ctr]);              

            }
        
        }




       




        protected void chk_checkchanged (object sender, EventArgs e)
        {
            Emp_Restriction er = new Emp_Restriction();
            er.empid = emp.empid;
            // identify which button was clicked and perform necessary actions
            CheckBox chk = sender as CheckBox;           

            if (er.Toggle(emp.empid, chk.Name, chk.Checked))
            {
                chk.Checked = chk.Checked;
            }
            else
            {
                MessageBox.Show("There was a problem updating restriction. : \n" + db.err.Message);
                chk.Checked = chk.Checked;
            }      
        }






        //FUNCTION TO GET THE PROPERTIES OF AN OBJECT
        //DON'T FORGET TO USE System.Reflection;
        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }











    }
}
