using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMG_PIAPS.userctrl.emp;
using MMG_PIAPS.classes;
using MMG_PIAPS.modules;
using MMG_PIAPS.forms;
using System.IO;

namespace MMG_PIAPS.userctrl
{
    public partial class emp_ctrl : UserControl
    {
        public emp_ctrl()
        {
            InitializeComponent();
        }

        public void LoadAllEployees() { 
        
         Employee emp= new Employee();
            DataTable dt = new DataTable();
            dt = emp.SELECT_ALL();
            if (dt != null) { 
                int num=1;
                foreach(DataRow r in dt.Rows){
                    ListViewItem li = new ListViewItem();
                    li.Text = num.ToString();
                    li.SubItems.Add(r["empid"].ToString());
                    li.SubItems.Add(r["lname"].ToString() + ", " + r["fname"].ToString() + " " + r["mname"].ToString());
                    li.SubItems.Add("position");//r["position"].ToString());
                    li.SubItems.Add(r["contactno"].ToString());
                    //li.SubItems.Add(r["gender"].ToString());
                    li.SubItems.Add(r["address"].ToString());
                    lv.Items.Add(li);
                    num++;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlops.Controls.Clear();

            emp_new c = new emp_new();
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;
            pnlops.Controls.Add(c);
        }

        private void emp_ctrl_Load(object sender, EventArgs e)
        {
            LoadAllEployees();           
        }

        private void lv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lv.SelectedItems.Count > 0){

                String id = lv.SelectedItems[0].SubItems[1].Text;
                //MessageBox.Show(id);

                Employee emp1 = new Employee();
                emp1.empid = id;
                Global.SELECTED_EMP = null;
                Global.SELECTED_EMP = emp1.SELECT_BY_ID();              
                Global.SELECTED_EMP.basic_pay = emp1.GET_BASIC_PAY();
                Global.SELECTED_EMP.emp_status = emp1.GET_EMPLOYMENT_STATUS();
                Global.SELECTED_EMP.position = emp1.GET_CURRENT_POSITION();
                Global.SELECTED_EMP.branch = emp1.GET_BRANCH_ASSIGNMENT();
                
                //FIND THE MAIN FORM                                   
                Form f = lv.Parent.Parent.FindForm();
             
                Control[] fname = f.Controls.Find("lblfname", true);
                //fname[0].Text = "";
                fname[0].Text = Global.SELECTED_EMP.fname.ToString();

                Control[] lname = f.Controls.Find("lbllname", true);
                //lname[0].Text = "";
                lname[0].Text = Global.SELECTED_EMP.lname.ToString();

                Control[] mname = f.Controls.Find("lblmname", true);
               // mname[0].Text = "";
                mname[0].Text = Global.SELECTED_EMP.mname.ToString();

                Control[] gender = f.Controls.Find("lblgender", true);
                //gender[0].Text = "";
                gender[0].Text = Global.SELECTED_EMP.gender.ToString();

                Control[] birthday = f.Controls.Find("lblbirthday", true);
                //birthday[0].Text = "";
                birthday[0].Text = Global.SELECTED_EMP.birthdate.ToString();

                Control[] address = f.Controls.Find("lbladdress", true);
                //address[0].Text = "";
                address[0].Text = Global.SELECTED_EMP.address.ToString();

                Control[] contactno = f.Controls.Find("lblcontactno", true);
                //address[0].Text = "";
                contactno[0].Text = Global.SELECTED_EMP.contactno.ToString();

                Control[] position = f.Controls.Find("lblposition", true);
                //position[0].Text = "";
                position[0].Text = Global.SELECTED_EMP.position.ToString();

                Control[] branch = f.Controls.Find("lblbranch", true);
               // branch[0].Text = "";
                branch[0].Text = Global.SELECTED_EMP.branch.ToString();

                Global.SELECTED_EMP.pic = emp1.GET_IMAGE_BY_ID();

                if (Global.SELECTED_EMP.pic != null)
                {

                    Control[] pb = f.Controls.Find("CurrUserPic", true);

                    MemoryStream ms = new MemoryStream(Global.SELECTED_EMP.pic);

                    //FIND THE PICTUREBOX IN THE FORM
                    foreach (Control c in f.Controls[1].Controls)
                    {
                        if (c.GetType() == typeof(PictureBox))
                        {
                            PictureBox p = c as PictureBox;
                            p.Image = Image.FromStream(ms);
                            p.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    //  pb.Image = Image.FromStream(ms);
                    //  pb.SizeMode = PictureBoxSizeMode.Zoom;                                     
                }
                else {
                    foreach (Control c in f.Controls[1].Controls)
                    {
                        if (c.GetType() == typeof(PictureBox))
                        {
                            PictureBox p = c as PictureBox;
                            p.Image = Properties.Resources.noimagefound;
                            p.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }     
                }
                                          
            }
        }

        private void updateInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {
                 String id = lv.SelectedItems[0].SubItems[1].Text;
           //MessageBox.Show(id);

            Employee emp, emp1 = new Employee();
            emp1.empid = id;
            emp = emp1.SELECT_BY_ID();
            emp.GET_BASIC_PAY();
            emp.GET_BRANCH_ASSIGNMENT();
            emp.GET_EMPLOYMENT_STATUS();
            emp.GET_IMAGE_BY_ID();
            emp.GET_CURRENT_POSITION();

            pnlops.Controls.Clear();

            emp_update c = new emp_update();
            c.emp = emp;
            c.Width = pnlops.Width;
            pnlops.Height = c.Height;

            pnlops.Controls.Add(c);

            }
        }

        private void updateBasicSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String id = lv.SelectedItems[0].SubItems[1].Text;

            Employee emp, emp1 = new Employee();
            emp1.empid = id;
            emp = emp1.SELECT_BY_ID();
            emp.GET_BASIC_PAY();
            //emp.GET_BRANCH_ASSIGNMENT();
            //emp.GET_EMPLOYMENT_STATUS();
            emp.GET_IMAGE_BY_ID();
            emp.GET_CURRENT_POSITION();
           
            pnlops.Controls.Clear();

          
        }
    }
}
