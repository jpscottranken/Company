using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class Commission : Employee
    {
        const double MINCOMMRATE = 0.10;        //  Minimum commission rate
        const double MAXCOMMRATE = 0.33;        //	Maximum commission rate
        const double DEFCOMMRATE = 0.20;        //	Default commission rate
        const double MINWSALES   = 0.0;         //  Minimum weekly sales
        const double MAXWSALES   = 10000.0;     //	Maximum weekly sales
        const double DEFWSALES   = 1000.0;      //	Default weekly sales

        //  Declare Commission class instance variables
        double commissionRate;
        double weeklySales;

        //************************************************
        //	No-arg constructor
        //************************************************
        public Commission()
        {
            commissionRate  = DEFCOMMRATE;
            weeklySales     = DEFWSALES;
            CalculateEarnings();
        }

        //************************************************
        //	Full-arg constructor
        //************************************************
        public Commission(string fn, string mi, string ln,
                       bool iu, int en,
                       double cr, double ws) : base(fn, mi, ln,
                                                     iu, en)
        {
            validateCommissionRate(cr);
            validateWeeklySales(ws);
        }
        //************************************************
        //	commRate getter/setter
        //************************************************
        public double CommissionRate
        {   //  Begin public double HoursWorked
            get
            {
                return commissionRate;
            }
            set
            {
                validateCommissionRate(value);
            }
        }   //  End   public double HoursWorked

        //************************************************
        //	weeklySales getter/setter
        //************************************************
        public double WeeklySales
        {   //  Begin public double HoursWorked
            get
            {
                return weeklySales;
            }
            set
            {
                validateWeeklySales(value);
            }
        }   //  End   public double HoursWorked

        //validate commissionRate
        public void validateCommissionRate(double value)
        {
            bool result = Double.TryParse(value.ToString(), out commissionRate);

            //  Handle non-numeric input
            if (!result)            //  if (result == false)
            {
                OutOfRangeCommissionRateException oorhe = new OutOfRangeCommissionRateException();
                commissionRate = DEFCOMMRATE;
                throw (oorhe);
            }
            else if ((value < MINCOMMRATE) || (value > MAXCOMMRATE))
            {
                OutOfRangeCommissionRateException oorhe = new OutOfRangeCommissionRateException();
                commissionRate = DEFCOMMRATE;
                throw (oorhe);
            }
            else
            {
                commissionRate = value;
            }
        }

        //validate weeklySales

        public void validateWeeklySales(double value)
        {
            bool result = Double.TryParse(value.ToString(), out weeklySales);

            //  Handle non-numeric input
            if (!result)            //  if (result == false)
            {
                OutOfRangeWeeklySalesException oorhe = new OutOfRangeWeeklySalesException();
                weeklySales = DEFWSALES;
                throw (oorhe);
            }
            else if ((value < MINWSALES) || (value > MAXWSALES))
            {
                OutOfRangeWeeklySalesException oorhe = new OutOfRangeWeeklySalesException();
                weeklySales = DEFWSALES;
                throw (oorhe);
            }
            else
            {
                weeklySales = value;
            }
        }


        //************************************************
        //	overridden CalculateEarnings()
        //************************************************

        public override double CalculateEarnings()
        {   //  Begin public override double CalculateEarnings()
            if ((commissionRate > MAXCOMMRATE) && (commissionRate < MINCOMMRATE))
            {
                commissionRate = DEFCOMMRATE;
            }

            if ((weeklySales > MAXWSALES) && (weeklySales < MINWSALES))
            {
                weeklySales = DEFWSALES;
            }

            grossPay = commissionRate * weeklySales;
            return grossPay;
        }   //  End   public override double CalculateEarnings()

        //************************************************
        //	Overridden ToString()
        //************************************************
        public override string ToString()
        {   //  Begin public override string ToString()
            string outputStr = "";

            outputStr += "Employee Name: " + FirstName + " " +
                                             MiddleInit + " " +
                                             LastName + "\n";
            outputStr += "Union Status:  " + IsUnion.ToString() + "\n";
            outputStr += "Employee Number: " + EmpNum.ToString() + "\n";
            outputStr += "Commission Rate: " + CommissionRate.ToString("f2") + "\n";
            outputStr += "Weekly Sales: " + WeeklySales.ToString("c") + "\n";
            outputStr += "Gross Pay: " + grossPay.ToString("c") + "\n";

            return outputStr;
        }   //  End   public override string ToString()
    }
}
