using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class OutOfRangePricePerPieceException : Exception
    {
        private static string msg = "Price per piece must be between 0.0 - 1.0";

        public OutOfRangePricePerPieceException() : base(msg)
        { }
    }
}
