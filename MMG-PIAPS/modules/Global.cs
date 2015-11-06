using MMG_PIAPS.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MMG_PIAPS.modules
{
   public static class Global
    {
       public static Employee CURRENT_USER = new Employee();
       public static Employee SELECTED_EMP = new Employee();
       public static Exception error = null;
       

       public static int GetMonths(DateTime startDate, DateTime endDate)
       {
           if (startDate > endDate)
           {
               return 0;//throw new Exception("Start Date is greater than the End Date");
           }
           else {
               int months = ((endDate.Year * 12) + endDate.Month) - ((startDate.Year * 12) + startDate.Month);

               if (endDate.Day >= startDate.Day)
               {
                   months++;
               }

               return months;
           }          
       }//end getmonths





       public static string GetMd5Hash(MD5 md5Hash, string input)
       {

           // Convert the input string to a byte array and compute the hash.
           byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

           // Create a new Stringbuilder to collect the bytes
           // and create a string.
           StringBuilder sBuilder = new StringBuilder();

           // Loop through each byte of the hashed data 
           // and format each one as a hexadecimal string.
           for (int i = 0; i < data.Length; i++)
           {
               sBuilder.Append(data[i].ToString("x2"));
           }

           // Return the hexadecimal string.
           return sBuilder.ToString();
       }







       // Verify a hash against a string.
       public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
       {
           // Hash the input.
           string hashOfInput = GetMd5Hash(md5Hash, input);

           // Create a StringComparer an compare the hashes.
           StringComparer comparer = StringComparer.OrdinalIgnoreCase;

           if (0 == comparer.Compare(hashOfInput, hash))
           {
               return true;
           }
           else
           {
               return false;
           }
       }







       public static void CREATE_JECBASCO() {

           Employee emps = new Employee();

           emps.empid = "0039";
           emps.fname = "Jose Jericho";
           emps.lname = "Basco";
           emps.mname = "Astillero";
           emps.gender = "Male";
           emps.birthdate = DateTime.Now;

           emps.contactno = "09064418634";
           emps.address = "Basud, Tabaco City";
           emps.position = "IT-Programmer";
           emps.basic_pay = Convert.ToDecimal("10826.00");
           emps.date_hired = DateTime.Now;
           emps.emp_status = "Regular";
           emps.branch = "1";
           emps.tinno = "";


           //if (pbEmpPic.Image != null)
           //{
           //    long filesize;
           //    MemoryStream mstream = new MemoryStream();
           //    pbEmpPic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
           //    Byte[] arrImage = mstream.GetBuffer();
           //    filesize = mstream.Length;
           //    emps.pic = arrImage;
           //}

           emps.password = "asdf";

           if (emps.save())
           {
               MessageBox.Show("Okey");
           }
           else
           {
               MessageBox.Show("Error :" + db.err.Message);
           }
       }




      



    }//end class


  


  

}
