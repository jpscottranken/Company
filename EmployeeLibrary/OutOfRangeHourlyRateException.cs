using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class OutOfRangeHourlyRateException : Exception
    {
        private static string msg = "Hourly Rate Must Be Between 0 - 100";

        public OutOfRangeHourlyRateException() : base(msg)
        { }
    }
}
