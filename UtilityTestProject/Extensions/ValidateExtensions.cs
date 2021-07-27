using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UtilityTestProject.Extensions
{
    public static class ValidateExtensions
    {
        public static bool IsLastDayOfMonth(this DateTime sender, int day) 
            => LastDayOfMonth() == day;

        public static int LastDayOfMonth() 
            => DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);


    }
}
