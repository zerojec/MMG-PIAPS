using MMG_PIAPS.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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




    }//end class


    


  

}
