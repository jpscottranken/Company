using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class OutOfRangeWeeklySalaryException : Exception
    {
        private static string msg = "Weekly salary must be between 1000-20000";

        public OutOfRangeWeeklySalaryException() : base(msg)
        { }
    }
}
