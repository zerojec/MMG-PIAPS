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
    }
}
