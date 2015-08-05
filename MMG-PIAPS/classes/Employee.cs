using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MySql.Data.MySqlClient;
using MMG_PIAPS.modules;
using System.Data;

namespace MMG_PIAPS.classes
{
    public class Employee : Person
    {
      
        private String _position;
        private DateTime _date_hired;
        private String _emp_status;
        private Decimal _basic_pay;
        private String _branch;
        
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
        }


        public DataTable SELECT_ALL() {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "EMP_SELECT_ALL");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);           
            return dt;

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
                        return image;
                    }else{
                        return null;
                    }                   
                }else{
                    return null;
                }
                
               
            }
        }
    
    }
   
     

   

