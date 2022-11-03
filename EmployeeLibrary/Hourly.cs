using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class Hourly : Employee
    {
        const double MINHOURS   =   0.0;    //	Min hours employee works
        const double MAXHOURS   =  84.0;    //	Max hours employee works
        const double DEFHOURS   =  40.0;    //	Default hours employee works
        const double MINRATE    =   0.0;    //	Min hourly rate
        const double MAXRATE    = 100.0;    //	Max hourly rate
        const double DEFRATE    =  25.0;    //	Default hourly rate
        const double MAXNONOT   =  40.0;    //	Max straight time hours
        const double OTRATE     =   1.5;    //	Overtime rate

        //  Declare Hourly class instance variables
        double hoursWorked;
        double hourlyRate;

        //************************************************
        //	No-arg constructor
        //************************************************
        public Hourly()
        {   //  Begin public Hourly() No-arg constructor
            hoursWorked =  DEFHOURS;
            hourlyRate  = DEFRATE;
            CalculateEarnings();
        }   //  End   public Hourly() No-arg constructor 

        //************************************************
        //	Full-arg constructor
        //************************************************
        public Hourly(string fn, string mi, string ln,
                      bool iu, int en,
                      double hw, double hr) : base(fn, mi, ln,
                                                   iu, en)
        {   //  Begin public Hourly() Full-arg constructor
            validateHoursWorked(hw);
            validateHourlyRate(hr);
        }   //  End   public Hourly() Full-arg constructor

        //************************************************
        //	hoursWorked getter/setter
        //************************************************
        public double HoursWorked
        {   //  Begin public double HoursWorked
            get
            {
                return hoursWorked;
            }
            set
            {
                validateHoursWorked(value);
            }
        }   //  End   public double HoursWorked

        //************************************************
        //	hourlyRate getter/setter
        //************************************************
        public double HourlyRate
        {   //  Begin public double HourlyRate
            get
            {
                return hourlyRate;
            }
            set
            {
                validateHourlyRate(value);
            }
        }   //  End   public double HourlyRate

        //************************************************
        //	validateHoursWorked
        //************************************************
        public void validateHoursWorked(double value)
        {
            bool result = Double.TryParse(value.ToString(), out hoursWorked);

            //  Handle non-numeric input
            if (!result)            //  if (result == false)
            {
                OutOfRangeHoursException oorhe = new OutOfRangeHoursException();
                hoursWorked = DEFHOURS;
                throw (oorhe);
            }
            else if ((value < MINHOURS) || (value > MAXHOURS))
            {
                OutOfRangeHoursException oorhe = new OutOfRangeHoursException();
                hoursWorked = DEFHOURS;
                throw (oorhe);
            }
            else
            {
                hoursWorked = value;
            }
        }

        //************************************************
        //	validateHourlyRate()
        //************************************************
        public void validateHourlyRate(double value)
        {
            bool result = Double.TryParse(value.ToString(), out hourlyRate);

            //  Handle non-numeric input
            if (!result)            //  if (result == false)
            {
                OutOfRangeHourlyRateException oorhre = new OutOfRangeHourlyRateException();
                hourlyRate = DEFRATE;
                throw (oorhre);
            }
            else if ((value < MINRATE) || (value > MAXRATE))
            {
                OutOfRangeHourlyRateException oorhre = new OutOfRangeHourlyRateException();
                hourlyRate = DEFRATE;
                throw (oorhre);
            }
            else
            {
                hourlyRate = value;
            }
        }

        //************************************************
        //	overridden CalculateEarnings()
        //************************************************
        public override double CalculateEarnings()
        {   //  Begin public override double CalculateEarnings()
            if (hoursWorked <= MAXNONOT)
            {   //  Begin if (hoursWorked <= MAXNONOT)  for straight time only
                grossPay = hoursWorked * hourlyRate;
            }   //  End   if (hoursWorked <= MAXNONOT)  for straight time only
            else
            {   //  Begin else on if (hoursWorked <= MAXNONOT)
                grossPay = ((MAXNONOT * hourlyRate) +               //	Straight time pay
                           ((hoursWorked - MAXNONOT) * hourlyRate * OTRATE));
            }   //  End   else on if (hoursWorked <= MAXNONOT)

            return grossPay;
        }   //  End   public override double CalculateEarnings()

        //************************************************
        //	Overridden ToString()
        //************************************************
        public override string ToString()
        {   //  Begin public override string ToString()
            string outputStr = "";

            outputStr += "Employee Name: "   + FirstName  + " "   +
                                               MiddleInit + " "   +
                                               LastName   + "\n";
            outputStr += "Union Status:  "   + IsUnion.ToString() + "\n";
            outputStr += "Employee Number: " + EmpNum.ToString()  + "\n";
            outputStr += "Hours Worked: "    + HoursWorked.ToString("f2") + "\n";
            outputStr += "Hourly Rate: "     + HourlyRate.ToString("c")   + "\n";
            outputStr += "Gross Pay: "       + grossPay.ToString("c") + "\n";

            return outputStr;
        }   //  End   public override string ToString()
    }
}
