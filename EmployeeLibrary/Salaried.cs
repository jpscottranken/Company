using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class Salaried : Employee
    {
        const double MINSALARY       = 1000.0;  //  Minimum weekly salary
        const double MAXSALARY       = 20000.0; //	Maximum weekly salary
        const double DEFSALARY       = 5000.0;  //	Default weekly salary
        const double WEEKSINYEAR     = 52.1429;
        const double DEFYEARLYSALARY = 50000;

        //  Declare Salaried class instance variables
        double weeklySalary;
        double salary;

        //************************************************
        //	No-arg constructor
        //************************************************
        public Salaried()
        {   //  Begin public Salaried() No-arg constructor
            weeklySalary = DEFSALARY;
            CalculateEarnings();
        }   //  End   public Salaried() No-arg constructor 

        //************************************************
        //	Full-arg constructor
        //************************************************
        public Salaried(string fn, string mi, string ln,
                       bool iu, int en,
                       double ws) : base(fn, mi, ln,
                                         iu, en)
        {   //  Begin public Hourly() Full-arg constructor
            validateSalary(ws);
        }   //  End   public Hourly() Full-arg constructor

        //************************************************
        //	weeklySalary getter/setter
        //************************************************
        public double WeeklySalary
        {   //  Begin public double weeklySalary
            get
            {
                return weeklySalary;
            }
            set
            {
                validateSalary(value);
            }
        }   //  End   public double weeklySalary


        public void validateSalary(double value)
        {
            bool result = Double.TryParse(value.ToString(), out weeklySalary);

            //  Handle non-numeric input
            if (!result)            //  if (result == false)
            {
                OutOfRangeWeeklySalaryException oorhe = new OutOfRangeWeeklySalaryException();
                weeklySalary = DEFSALARY;
                throw (oorhe);
            }
            else if ((value < MINSALARY) || (value > MAXSALARY))
            {
                OutOfRangeWeeklySalaryException oorhe = new OutOfRangeWeeklySalaryException();
                weeklySalary = DEFSALARY;
                throw (oorhe);
            }
            else
            {
                weeklySalary = value;
            }
        }

        //************************************************
        //	overridden CalculateEarnings()
        //************************************************
        public override double CalculateEarnings()
        {   //  Begin public override double CalculateEarnings()
            if ((weeklySalary <= MAXSALARY) && (weeklySalary >= MINSALARY))
            {
                salary = weeklySalary * WEEKSINYEAR;
            }
            else
            {
                salary = DEFYEARLYSALARY;
            }

            return salary;
        }   //  End   public override double CalculateEarnings()

        //************************************************
        //	Overridden ToString()
        //************************************************

        public override string ToString()
        {   //  Begin public override string ToString()
            string outputStr = "";

            outputStr += "Employee Name: " + FirstName + " "      +
                                             MiddleInit           + " "     +
                                             LastName             + "\n";
            outputStr += "Union Status:  " + IsUnion.ToString()   + "\n";
            outputStr += "Employee Number: " + EmpNum.ToString()  + "\n";
            outputStr += "Weekly Salary: " + WeeklySalary.ToString("c")     + "\n";
            outputStr += "Yearly Salary: " + salary.ToString("c") + "\n";

            return outputStr;
        }   //  End   public override string ToString()
    }
}
