using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Helper
{
    public static class Helper
    {
        public static string DisplayDateTime()
        {
            return string.Format("{0} - {1} - {2} - {3}",
                DateTime.Now.DayOfWeek,
                DateTime.Now.Day ,
                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month),
                DateTime.Now.Year);
        }
    }
}
