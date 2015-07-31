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
    class Person
    {
        private String _empid;
        private String _fname;
        private String _lname;
        private String _mname;
        private DateTime _birthday;
        private String _contactno;
        private String _gender;
        private String _address;
        private Image _pic;

        public String empid { get { return _empid; } set { _empid = value; } }
        public String fname { get { return _fname; } set { _fname = value; } }
        public String lname { get { return _lname; } set {_lname = value; } }
        public String mname { get { return _mname; } set { _mname = value; } }
        public DateTime birthdate { get { return _birthday; } set { _birthday = value; } }
        public String contactno { get { return _contactno; } set { _contactno = value; } }
        public String address { get { return _address; } set { _address = value; } }
        public String gender { get { return _gender; } set { _gender = value; } }
        public Image pic { get { return _pic; } set { _pic = value; } }

        public Boolean save(){
        
            MySqlCommand cmd= new MySqlCommand();
            cmd.Connection= db.con;
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

            try
            {
                //db.con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                db.err = null;
                db.err = e;               
                return false;
            
            }



        }
        
    }
}
