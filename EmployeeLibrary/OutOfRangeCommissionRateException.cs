using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class OutOfRangeCommissionRateException : Exception
    {
        private static string msg = "Commission Rate Must Be Between 0.10 - 0.33";

        public OutOfRangeCommissionRateException() : base(msg)
        { }
    }
}
