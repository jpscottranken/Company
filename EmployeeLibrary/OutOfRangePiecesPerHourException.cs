using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class OutOfRangePiecesPerHourException : Exception
    {
        private static string msg = "Pieces Per Hour Must Be Between 0 - 100";

        public OutOfRangePiecesPerHourException() : base(msg)
        { }
    }
}
