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
    public class Member : Person
    {
      

        public String memid { get;set ;  }
        public String typeofmembership { get; set; }
        public String standing { get; set; }
        public DateTime dateofmembership { get; set; }





        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "MEM_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("_empid", empid);
            cmd.Parameters.AddWithValue("_fname", fname);
            cmd.Parameters.AddWithValue("_lname", lname);
            cmd.Parameters.AddWithValue("_mname", mname);
            cmd.Parameters.AddWithValue("_birthday", birthdate);
            cmd.Parameters.AddWithValue("_contactno", contactno);
            cmd.Parameters.AddWithValue("_gender", gender);
            cmd.Parameters.AddWithValue("_address", address);
            cmd.Parameters.AddWithValue("_dateofmembership", typeofmembership);
            cmd.Parameters.AddWithValue("_imagearr", pic);
            cmd.Parameters.AddWithValue("_imagesize", pic.Length);
             

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
            cmd.Parameters.AddWithValue("_birthday", birthdate);
            cmd.Parameters.AddWithValue("_contactno", contactno);
            cmd.Parameters.AddWithValue("_gender", gender);
            cmd.Parameters.AddWithValue("_address", address);
            cmd.Parameters.AddWithValue("_dateofmembership", typeofmembership);
            cmd.Parameters.AddWithValue("_imagearr", pic);
            cmd.Parameters.AddWithValue("_imagesize", pic.Length);
           

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
            db.SET_COMMAND_PARAMS(cmd, "MEM_SELECT_ALL");
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
            db.SET_COMMAND_PARAMS(cmd, "MEM_SELECT_REGULAR");
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












        public Member SELECT_BY_ID()
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            db.SET_COMMAND_PARAMS(cmd, "MEM_SELECT_BY_ID");
            cmd.Parameters.AddWithValue("_memid", memid);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Member e = new Member();
                    foreach (DataRow r in dt.Rows)
                    {
                        e.empid = r["memid"].ToString();
                        e.fname = r["fname"].ToString();
                        e.lname = r["lname"].ToString();
                        e.mname = r["mname"].ToString();
                        e.address = r["address"].ToString();
                        e.birthdate = Convert.ToDateTime(r["birthday"].ToString());
                        e.contactno = r["contactno"].ToString();
                        e.gender = r["gender"].ToString();
              

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
                db.SET_COMMAND_PARAMS(cmd, "MEM_PIC_SELECT_BY_ID");
                cmd.Parameters.AddWithValue("_memid", memid);

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






            public String GET_MEMBERSHIP_STANDING() {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "MEM_STANDING_SELECT_LATEST_BY_ID");
                cmd.Parameters.AddWithValue("_memid", memid);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt != null){
                    if (dt.Rows.Count > 0){
                       String stand = dt.Rows[0].Field<String>("mem_standing");
                       standing = stand;
                       return stand;
                    }
                    else{
                        return null;
                    }
                }
                else{
                    return null;
                }                

            }//end GET_MEMBERSHIP_STANDING




            public Boolean SET_MEMBERSHIP_STANDING()
            {


                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "MEM_STANDING_INSERT");
                cmd.Parameters.AddWithValue("_memid", memid);
                cmd.Parameters.AddWithValue("_memstanding", standing);

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

           


         




            public void LoadMembers(ComboBox cbo) {

                Member e = new Member();
                DataTable dt = new DataTable();

                dt = e.SELECT_ALL();
                if (dt != null) {
                    foreach (DataRow r in dt.Rows) {
                        cbo.Items.Add(r["lname"] + ", " + r["fname"] + " " + r["mname"] + "-" + r["memid"]);
                    }
                }

            }








            public void LoadRegularMembers(ComboBox cbo)
            {

                Member e = new Member();
                DataTable dt = new DataTable();

                dt = e.SELECT_REGULAR();
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        cbo.Items.Add(r["lname"] + ", " + r["fname"] + " " + r["mname"] + "-" + r["memid"]);
                    }
                }

            }//end Load Regular Members





        









        }
    
    }
   
     

   

