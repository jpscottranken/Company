using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public abstract class Employee
    {
        //  Employee Class Constants
        const int MINEMPNUM = 1000;      //  Min employee number
        const int MAXEMPNUM = 100000;    //  Max employee number
        const int DEFEMPNUM = 9999;      //  Default employee number

        //	Declare program instance variables
        private string      firstName;
        private string      middleInit;
        private string      lastName;
        private bool        isUnion;
        private int         empNum;
        protected double    grossPay;

        //************************************************
        //	No-arg constructor
        //************************************************
        public Employee()
        {   //  Begin public Employee() No-arg constructor
            firstName   = "UFN";
            middleInit  = "*";
            lastName    = "ULN";
            isUnion     = false;        //	Unnecessary
            empNum      = DEFEMPNUM;
        }   //  End   public Employee() No-arg constructor 

        //************************************************
        //	Full-arg constructor
        //************************************************
        public Employee(string fn, string mi, string ln,
                        bool iu, int en)
        {   //  Begin public Employee() Full-arg constructor
            this.firstName = fn;
            this.middleInit = mi;
            this.lastName = ln;
            this.isUnion = iu;
            this.empNum = en;
        }   //  End   public Employee() Full-arg constructor

        //************************************************
        //	firstName getter/setter
        //************************************************
        public string FirstName
        {   //  Begin public string FirstName
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }   //  End   public string FirstName

        //************************************************
        //	middleInit getter/setter
        //************************************************
        public string MiddleInit
        {   //  Begin public string MiddleInit
            get
            {
                return middleInit;
            }
            set
            {
                if (value == null)
                {
                    middleInit = "*";
                }
                else
                {
                    middleInit = value;
                }            
            }
        }   //  End   public string MiddleInit

        //************************************************
        //	lastName getter/setter
        //************************************************
        public string LastName
        {   //  Begin public string LastName
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }   //  End   public string LastName

        //************************************************
        //	isUnion getter/setter
        //************************************************
        public bool IsUnion
        {   //  Begin public bool IsUnion
            get
            {
                return isUnion;
            }
            set
            {
                isUnion = value;
            }
        }   //  End   public bool IsUnion

        //************************************************
        //	empNum getter/setter
        //************************************************
        public int EmpNum
        {   //  Begin public int EmpNum
            get
            {
                return empNum;
            }
            set
            {
                if ((empNum < MINEMPNUM) || (empNum > MAXEMPNUM))
                {
                    empNum = DEFEMPNUM;
                }
                else
                {
                    empNum = value;
                }
            }
        }   //  End   public int EmpNum

        //  Declare abstract method:
        public abstract double CalculateEarnings();
    }
}
