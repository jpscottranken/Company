using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class OutOfRangeWeeklySalesException : Exception
    {
        private static string msg = "Weekly Sales Must Be Between 1000 and 20000";

        public OutOfRangeWeeklySalesException() : base(msg)
        { }
    }
}
