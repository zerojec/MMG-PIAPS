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
        public String fullname { get; set; }
        public String typeofmembership { get; set; }
        public String standing { get; set; }
        public DateTime acceptance_date { get; set; }
        public String status { get; set; } //withdrawns or deceased etc..
        public String occupation { get; set; }
        public String email { get; set; }

        public Boolean save()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "MEMBER_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("_memid", memid);
            cmd.Parameters.AddWithValue("_fullname", fullname);
            cmd.Parameters.AddWithValue("_status", status);
            cmd.Parameters.AddWithValue("_contactno", contactno);
            cmd.Parameters.AddWithValue("_email", email);
            cmd.Parameters.AddWithValue("_address", address);
            cmd.Parameters.AddWithValue("_acceptance_date", acceptance_date);
            cmd.Parameters.AddWithValue("_occupation", occupation);
            cmd.Parameters.AddWithValue("_typeofmembership", typeofmembership);
            cmd.Parameters.AddWithValue("_standing", standing);
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
                Logger.WriteErrorLog("Error MEMBER_CLASS_SAVE: " + e.Message);
                return false;
            }
        }//end save


        public Boolean update()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "MEMBER_UPDATE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("_memid", memid);
            cmd.Parameters.AddWithValue("_fullname", fullname);
            cmd.Parameters.AddWithValue("_status", status);
            cmd.Parameters.AddWithValue("_contactno", contactno);
            cmd.Parameters.AddWithValue("_email", email);
            cmd.Parameters.AddWithValue("_address", address);
            cmd.Parameters.AddWithValue("_acceptance_date", acceptance_date);
            cmd.Parameters.AddWithValue("_occupation", occupation);
            cmd.Parameters.AddWithValue("_typeofmembership", typeofmembership);
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












        public Boolean delete()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = db.con;
            cmd.CommandText = "MEMBER_DELETE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("_memid", memid);
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
            db.SET_COMMAND_PARAMS(cmd, "MEMBER_SELECT_ALL");
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
            db.SET_COMMAND_PARAMS(cmd, "MEMBER_SELECT_REGULAR");
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
            db.SET_COMMAND_PARAMS(cmd, "MEMBER_SELECT_BY_ID");
            cmd.Parameters.AddWithValue("_memid", memid);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);


            try
            {

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        Member e = new Member();
                        
                        foreach (DataRow r in dt.Rows)
                        {
                            e.memid = r["memid"].ToString();
                            e.fullname = r["fullname"].ToString();
                            e.address = r["address"].ToString();
                            e.contactno = r["contactno"].ToString();
                            e.status = r["status_"].ToString();
                            e.standing = r["standing"].ToString();
                            e.typeofmembership = r["typeofmembership"].ToString();
                            e.occupation = r["occupation"].ToString();
                            e.email = r["email"].ToString();
                            e.acceptance_date = Convert.ToDateTime(r["acceptance_date"].ToString());
                            e.address = r["address"].ToString();
                        }
                        return e;

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
            catch (Exception err) {
                Logger.WriteErrorLog("ERROR ON MEMBERS_SELECT_BY_ID MODULE :" + err.Message);
                return null;
            }           
        }




        public Byte[] GET_IMAGE_BY_ID(){
                
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                db.SET_COMMAND_PARAMS(cmd, "MEMBER_PIC_SELECT_BY_ID");
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
                db.SET_COMMAND_PARAMS(cmd, "MEMMBER_STANDING_SELECT_LATEST_BY_ID");
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
                        cbo.Items.Add(r["fullname"] + "-" + r["memid"]);
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
                        cbo.Items.Add(r["fullname"] + "-" + r["memid"]);
                    }
                }

            }//end Load Regular Members


            public void LoadMembersInListView(ListView lv)
            {

                Member e = new Member();
                DataTable dt = new DataTable();

                dt = e.SELECT_ALL();
                if (dt != null)
                {
                    int ctr=1;
                    foreach (DataRow r in dt.Rows)
                    {
                        ListViewItem li = new ListViewItem();
                        li.Text = ctr.ToString();
                        li.SubItems.Add(r["memid"].ToString());
                        li.SubItems.Add(r["fullname"].ToString());
                        li.SubItems.Add(r["address"].ToString());
                        li.SubItems.Add(r["contactno"].ToString());
                        li.SubItems.Add(r["status_"].ToString());

                        lv.Items.Add(li);
                        ctr++;
                        
                    }
                }

            }//end LoadMembersInListView









            public Decimal GET_TOTAL_PAIDUP_CAPITAL() {
                return 0;
            }











        }
    
    }
   
     

   

