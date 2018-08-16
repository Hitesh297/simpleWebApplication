using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Helper
{
    public static class Helper
    {
        public static string DisplayDateTime()
        {
            return string.Format("{0} - {1} - {2}", 
                Convert.ToString(DateTime.Now.Day) ,
                DateTime.Now.DayOfWeek ,
                DateTime.Now.Year);
        }
    }
}
