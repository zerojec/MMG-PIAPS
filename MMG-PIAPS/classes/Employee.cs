using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MySql.Data.MySqlClient;
using MMG_PIAPS.modules;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MMG_PIAPS.classes
{
    public class Employee : Person
    {


        //public non_static_dbcon usethisconnection= new non_static_dbcon();

        private String _position;
        private DateTime _date_hired;
        private String _emp_status;
        private Decimal _basic_pay;
        private String _branch;
        
        public  List<Benefit> benefits = new List<Benefit> { };
        public Emp_Sched schedule = new Emp_Sched();
        public Emp_Restriction restriction = new Emp_Restriction();

        public String position { get { return _position; } set { _position = value; } }
        public String branch { get { return _branch; } set { _branch = value; } }
        public String emp_status { get { return _emp_status; } set { _emp_status = value; } }
        public Decimal basic_pay { get { return _basic_pay; } set { _basic_pay = value; } }
        public DateTime date_hired { get { return _date_hired; } set { _date_hired = value; } }
        public String COOP_MEMBERSHIP_ID { get; set; }
        public String tinno { get; set; }

        public string password { get; set; }
        public Boolean ISLOGGEDIN { get; set; }


        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "EMP_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;
          

          

            cmd.Parameters.AddWithValue("_empid", Convert.ToInt32(empid).ToString("0000"));
            cmd.Parameters.AddWithValue("_fname", fname);
            cmd.Parameters.AddWithValue("_lname", lname);
            cmd.Parameters.AddWithValue("_mname", mname);
            cmd.Parameters.AddWithValue("_birthday", birthdate);
            cmd.Parameters.AddWithValue("_contactno", contactno);
            cmd.Parameters.AddWithValue("_gender", gender);
            cmd.Parameters.AddWithValue("_address", address);
            cmd.Parameters.AddWithValue("_emp_status", emp_status);
            cmd.Parameters.AddWithValue("_imagearr", pic);
            int length = (pic != null) ? pic.Length : 0;
            cmd.Parameters.AddWithValue("_imagesize", length);
            cmd.Parameters.AddWithValue("_emp_position", position); 
            cmd.Parameters.AddWithValue("_branchid", branch);
            cmd.Parameters.AddWithValue("_tinno", tinno);
          
            
            //encrypt password
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = Global.GetMd5Hash(md5Hash, password);
                cmd.Parameters.AddWithValue("_pword", hash);
            }
                       

              
            try
            {
                //db.con.Open();
                cmd.ExecuteNonQuery();
                
                BasicPay p = new BasicPay();
                p.empid = Convert.ToInt32(this.empid).ToString("0000");
                p.basic_pay = this.basic_pay;
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

                Logger.WriteErrorLog("ERROR : EMPLOYEE SAVE MODULE :" + e.Message);
                return false;
            }
        }//end save







        public Boolean delete()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "EMP_DELETE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("_empid", Convert.ToInt32(empid).ToString("0000"));
      
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

                Logger.WriteErrorLog("ERROR : EMPLOYEE SAVE MODULE :" + e.Message);
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
            cmd.Parameters.AddWithValue("_tinno", tinno);
           // cmd.Parameters.AddWithValue("_COOP_MEMBERSHIP_ID", COOP_MEMBERSHIP_ID);
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








        public Boolean update_password()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "EMP_UPDATE_PASSWORD";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("_empid", empid);
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = Global.GetMd5Hash(md5Hash, password);
                cmd.Parameters.AddWithValue("_pword", hash);
            }


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
                Logger.WriteErrorLog("ERROR EMPLOYEE_UPDATE_PASSWORD :" + e.Message);
                return false;
            }
        }









        public Boolean UPDATE_MEMBERSHIP()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "EMP_UPDATE_MEMBERSHIP";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_COOP_MEMBERSHIP_ID", COOP_MEMBERSHIP_ID);
     
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
                Logger.WriteErrorLog("COOP_MEMBERSHIP_UPDATE MODULE " + e.Message);
                return false;
            }
        }//END LINK ACCOUNT An EMPLOYEE BECOMES A MEMBER






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






        public DataTable SELECT_REGULAR()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_SELECT_REGULAR");
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
                        e.empid = r["empid"].ToString();
                        e.fname = r["fname"].ToString();
                        e.lname = r["lname"].ToString();
                        e.mname = r["mname"].ToString();
                        e.address = r["address"].ToString();
                        e.birthdate = Convert.ToDateTime(r["birthday"].ToString());
                        e.contactno = r["contactno"].ToString();
                        e.gender = r["gender"].ToString();
                        e.COOP_MEMBERSHIP_ID = r["COOP_MEMBERSHIP_ID"].ToString();
                        e.tinno = r["tinno"].ToString();

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










        public Employee SELECT_BY_ID(non_static_dbcon usethisconnection)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            usethisconnection.SET_COMMAND_PARAMS(cmd, "EMP_SELECT_BY_ID");
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
                        e.empid = r["empid"].ToString();
                        e.fname = r["fname"].ToString();
                        e.lname = r["lname"].ToString();
                        e.mname = r["mname"].ToString();
                        e.address = r["address"].ToString();
                        e.birthdate = Convert.ToDateTime(r["birthday"].ToString());
                        e.contactno = r["contactno"].ToString();
                        e.gender = r["gender"].ToString();
                        e.COOP_MEMBERSHIP_ID = r["COOP_MEMBERSHIP_ID"].ToString();
                        e.tinno = r["tinno"].ToString();

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







        public Employee SELECT_BY_IDPASS()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_SELECT_BY_IDPASS");
            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_pword", password);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Employee e = new Employee();
                    foreach (DataRow r in dt.Rows)
                    {
                        e.empid = r["empid"].ToString();
                        e.fname = r["fname"].ToString();
                        e.lname = r["lname"].ToString();
                        e.mname = r["mname"].ToString();
                        e.address = r["address"].ToString();
                        e.birthdate = Convert.ToDateTime(r["birthday"].ToString());
                        e.contactno = r["contactno"].ToString();
                        e.gender = r["gender"].ToString();
                        e.COOP_MEMBERSHIP_ID = r["COOP_MEMBERSHIP_ID"].ToString();
                        e.tinno = r["tinno"].ToString();
                        e.password = r["pword"].ToString();

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









        public Byte[] GET_IMAGE_BY_ID(non_static_dbcon usethisconnection)
        {

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            usethisconnection.SET_COMMAND_PARAMS(cmd, "EMP_PIC_SELECT_BY_ID");
            cmd.Parameters.AddWithValue("_empid", empid);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Byte[] image = dt.Rows[0].Field<Byte[]>("imagebyte");
                    pic = image;
                    return image;

                }
                else
                {
                    return null;
                }
            }
            else
            {
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













            public String GET_CURRENT_POSITION(non_static_dbcon usethisconnection)
            {

                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                usethisconnection.SET_COMMAND_PARAMS(cmd, "EMP_POSITION_SELECT_LATEST_BY_ID");
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








            public void LoadRegularEmployee(ComboBox cbo)
            {

                Employee e = new Employee();
                DataTable dt = new DataTable();

                dt = e.SELECT_REGULAR();
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        cbo.Items.Add(r["lname"] + ", " + r["fname"] + " " + r["mname"] + "-" + r["empid"]);
                    }
                }

            }//end Load Regular Employees






            public DateTime GET_REGULAR_STATUS_DATE() {

                DateTime d = new DateTime(1521,3,17);
                
                MySqlCommand cmd = new MySqlCommand();
                DataTable dt = new DataTable();

                //GET THE DATE THE EMPLOYEE BECOMES A "REGULAR" EMPLOYEE
                db.SET_COMMAND_PARAMS(cmd, "EMP_GET_REGULAR_STATUS_DATE");
                cmd.Parameters.AddWithValue("_empid", empid);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
              
                try
                {
                    da.Fill(dt);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            DataRow r = dt.Rows[0];
                            return Convert.ToDateTime(r["date_updated"].ToString());
                        }
                        else
                        {
                            return d;
                        }
                    }
                    else {
                        return d;
                    }        
                }
                catch (Exception e) {
                   
                    db.err = null;
                    db.err = e;
                    return d;                
                }                                                    
            }






            public bool Logout()
            {
                this.ISLOGGEDIN = false;
                if (ISLOGGEDIN == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }






        }
    
    }
   
     

   

