using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MySql.Data.MySqlClient;
using MMG_PIAPS.modules;
using System.Data;
using System.Windows.Forms;

namespace MMG_PIAPS.classes
{
    public class Employee : Person
    {
      
        private String _position;
        private DateTime _date_hired;
        private String _emp_status;
        private Decimal _basic_pay;
        private String _branch;
        public  List<Benefit> benefits = new List<Benefit> { };
        public Emp_Sched schedule = new Emp_Sched();

        public String position { get { return _position; } set { _position = value; } }
        public String branch { get { return _branch; } set { _branch = value; } }
        public String emp_status { get { return _emp_status; } set { _emp_status = value; } }
        public Decimal basic_pay { get { return _basic_pay; } set { _basic_pay = value; } }
        public DateTime date_hired { get { return _date_hired; } set { _date_hired = value; } }

       
      






        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "EMP_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_fname", fname);
            cmd.Parameters.AddWithValue("_lname", lname);
            cmd.Parameters.AddWithValue("_mname", mname);
            cmd.Parameters.AddWithValue("_birthday", birthdate);
            cmd.Parameters.AddWithValue("_contactno", contactno);
            cmd.Parameters.AddWithValue("_gender", gender);
            cmd.Parameters.AddWithValue("_address", address);
            cmd.Parameters.AddWithValue("_emp_status", emp_status);
            cmd.Parameters.AddWithValue("_imagearr", pic);
            cmd.Parameters.AddWithValue("_imagesize", pic.Length);
            cmd.Parameters.AddWithValue("_emp_position", position); 
            cmd.Parameters.AddWithValue("_branchid", branch);
            

            try
            {
                //db.con.Open();
                cmd.ExecuteNonQuery();
                
                BasicPay p = new BasicPay();
                p.empid = empid;
                p.basic_pay = basic_pay;
                p.date_updated = DateTime.Now;
                
                if (p.save()){
                    return true;
                }
                else {
                    return false;
                }                               
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                return false;
            }
        }//end save


        public Boolean update()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "EMP_UPDATE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_fname", fname);
            cmd.Parameters.AddWithValue("_lname", lname);
            cmd.Parameters.AddWithValue("_mname", mname);
            cmd.Parameters.AddWithValue("_bdate", birthdate);
            cmd.Parameters.AddWithValue("_contactno", contactno);
            cmd.Parameters.AddWithValue("_gender", gender);
            cmd.Parameters.AddWithValue("_address", address);
            cmd.Parameters.AddWithValue("_emp_status", emp_status);
            cmd.Parameters.AddWithValue("_imagearr", pic);
            cmd.Parameters.AddWithValue("_imagesize", pic.Length);
            cmd.Parameters.AddWithValue("_emp_position", position);
            //cmd.Parameters.AddWithValue("_branchid", branch);


            try
            {
                //db.con.Open();
                cmd.ExecuteNonQuery();            
                return true;              
            }
            catch (Exception e)
            {
                db.err = null;
                db.err = e;
                return false;
            }
        }


        public DataTable SELECT_ALL() {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e.Message);
                return null;
            }
        }



        public Employee SELECT_BY_ID()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_SELECT_BY_ID");
            cmd.Parameters.AddWithValue("_empid", empid);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Employee e = new Employee();
                    foreach (DataRow r in dt.Rows)
                    {
                        e.empid = Convert.ToInt32(r["empid"].ToString());
                        e.fname = r["fname"].ToString();
                        e.lname = r["lname"].ToString();
                        e.mname = r["mname"].ToString();
                        e.address = r["address"].ToString();
                        e.birthdate = Convert.ToDateTime(r["birthday"].ToString());
                        e.contactno = r["contactno"].ToString();
                        e.gender = r["gender"].ToString();
                       // e.date_hired = Convert.ToDateTime(r["mname"].ToString());
                       // e.position = r["position"].ToString();
                       // e.branch = r["branch"].ToString();

                    }
                    return e;
                }
                else { return null; }

            }
            else
            {
                return null;
            }

        }
            public Byte[] GET_IMAGE_BY_ID(){
                
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "EMP_PIC_SELECT_BY_ID");
                cmd.Parameters.AddWithValue("_empid", empid);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);           
                
                if(dt != null){
                    if(dt.Rows.Count > 0){
                     Byte[] image=dt.Rows[0].Field<Byte[]>("imagebyte");
                     pic = image;
                     return image;
                       
                    }else{
                        return null;
                    }                   
                }else{
                    return null;
                }                              
            }

            public String GET_EMPLOYMENT_STATUS() {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "EMP_STATUS_SELECT_LATEST_BY_ID");
                cmd.Parameters.AddWithValue("_empid", empid);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt != null){
                    if (dt.Rows.Count > 0){
                       String stats = dt.Rows[0].Field<String>("emp_status");
                       emp_status = stats;
                        return stats;
                    }
                    else{
                        return null;
                    }
                }
                else{
                    return null;
                }                

            }//end GET_EMPLOYMENT_STATUS

            public Boolean SET_EMPLOYMENT_STATUS()
            {


                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "EMP_STATUS_INSERT");
                cmd.Parameters.AddWithValue("_empid", empid);
                cmd.Parameters.AddWithValue("_emp_status", emp_status);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    db.err = null;
                    db.err = e;
                    return false;
                }


            }

            public Decimal GET_BASIC_PAY(){

                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "EMP_BASIC_PAY_SELECT_LATEST_BY_ID");
                cmd.Parameters.AddWithValue("_empid", empid);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt != null){
                    if (dt.Rows.Count > 0){
                        Decimal bp = dt.Rows[0].Field<Decimal>("basic_pay");
                        basic_pay = bp;
                        return bp;
                    }
                    else{
                        return 0;
                    }
                }
                else{
                    return 0;
                }                
            }


            public String GET_CURRENT_POSITION()
            {

                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "EMP_POSITION_SELECT_LATEST_BY_ID");
                cmd.Parameters.AddWithValue("_empid", empid);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        String pos = "";
                        pos = (dt.Rows[0].Field<String>("position_") != null) ? dt.Rows[0].Field<String>("position_") : "";                        
                        position = pos;
                        return pos;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }

            public Boolean SET_CURRENT_POSITION() {


                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "EMP_POSITION_INSERT");
                cmd.Parameters.AddWithValue("_empid", empid);
                cmd.Parameters.AddWithValue("_emp_position", position);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e) {
                    db.err = null;
                    db.err = e;
                    return false;
                }
              

            }

            public String GET_BRANCH_ASSIGNMENT()
            {

                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "EMP_BRANCH_ASS_SELECT_BY_ID");
                cmd.Parameters.AddWithValue("_empid", empid);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        String ba = dt.Rows[0].Field<UInt32>("branchid") + "-" + dt.Rows[0].Field<String>("branchname");
                        //ba = (ba != "") ? ba : "";
                        //ba!=null ? branch=ba : branch="";
                        branch = ba;
                        return ba;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }// end GET_BRANCH_ASSIGNMENT


            public Boolean SET_BRANCH_ASSIGNMENT()
            {


                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "EMP_BRANCH_ASSIGNMENT_INSERT");
                cmd.Parameters.AddWithValue("_empid", empid);
                cmd.Parameters.AddWithValue("_branchid", branch);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    db.err = null;
                    db.err = e;
                    return false;
                }


            }




            public void LIST_BENEFITS() {

                MySqlCommand cmd = new MySqlCommand();
                DataTable dt = new DataTable();
                db.SET_COMMAND_PARAMS(cmd, "BENEFIT_SELECT_BY_EMPID");
                cmd.Parameters.AddWithValue("_empid", empid);                
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach(DataRow r in dt.Rows){
                         Benefit b = new Benefit();
                         b.code = r["benefit_code"].ToString();
                         b.name_ = r["emp_benefit_code"].ToString();
                         benefits.Add(b);
                        }
                    }                 
                }                
            }





            public void LoadEmployee(ComboBox cbo) {

                Employee e = new Employee();
                DataTable dt = new DataTable();

                dt = e.SELECT_ALL();
                if (dt != null) {
                    foreach (DataRow r in dt.Rows) {
                        cbo.Items.Add(r["lname"] + ", " + r["fname"] + " " + r["mname"] + "-" + r["empid"]);
                    }
                }

            }



        }
    
    }
   
     

   

