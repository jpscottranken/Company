using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class Pieceworker : Employee
    {
        //  Declare and initialize class constants
        const int MINPIECES = 0;        //	Minimum pieces made per hour
        const int MAXPIECES = 100;      //	Maximum pieces made per hour
        const int DEFPIECES = 25;       //	Default pieces made per hour
        const double MINPPP = 0.0;      //	Minimum price per piece
        const double MAXPPP = 1.0;      //  Maximum price per piece
        const double DEFPPP = 0.5;      //	Default price per piece

        //  Declare PieceWorker class instance variables
        int piecesPerHour;
        double pricePerPiece;

        //************************************************
        //	No-arg constructor
        //************************************************
        public Pieceworker()
        {
            piecesPerHour = DEFPIECES;
            pricePerPiece = DEFPPP;
            CalculateEarnings();
        }
        //************************************************
        //	Full-arg constructor
        //************************************************
        public Pieceworker(string fn, string mi, string ln,
                           bool iu, int en,
                           int ph, double pp) : base(fn, mi, ln,
                                                     iu, en)
        {
            validatePiecesPerHour(ph);
            validatePricePerPiece(pp);
        }
        //************************************************
        //	pieces getter/setter
        //************************************************
        public int PiecesPerHour
        {   //  Begin public double HoursWorked
            get
            {
                return piecesPerHour;
            }
            set
            {
                validatePiecesPerHour(value);
            }
        }
        //************************************************
        //	pricePerPiece getter/setter
        //************************************************
        public double PricePerPiece
        {   //  Begin public double HoursWorked
            get
            {
                return pricePerPiece;
            }
            set
            {
                validatePricePerPiece(value);
            }
        }

        //validation
        public void validatePiecesPerHour(int value)
        {
            bool result = int.TryParse(value.ToString(), out piecesPerHour);

            //  Handle non-numeric input
            if (!result)            //  if (result == false)
            {
                OutOfRangePiecesPerHourException oorhe = new OutOfRangePiecesPerHourException();
                piecesPerHour = DEFPIECES;
                throw (oorhe);
            }
            else if ((value < MINPIECES) || (value > MAXPIECES))
            {
                OutOfRangePiecesPerHourException oorhe = new OutOfRangePiecesPerHourException();
                piecesPerHour = DEFPIECES;
                throw (oorhe);
            }
            else
            {
                piecesPerHour = value;
            }
        }

        public void validatePricePerPiece(double value)
        {
            bool result = Double.TryParse(value.ToString(), out pricePerPiece);

            //  Handle non-numeric input
            if (!result)            //  if (result == false)
            {
                OutOfRangePricePerPieceException oorhe = new OutOfRangePricePerPieceException();
                pricePerPiece = DEFPPP;
                throw (oorhe);
            }
            else if ((value < MINPPP) || (value > MAXPPP))
            {
                OutOfRangePricePerPieceException oorhe = new OutOfRangePricePerPieceException();
                pricePerPiece = DEFPPP;
                throw (oorhe);
            }
            else
            {
                pricePerPiece = value;
            }
        }

        //************************************************
        //	overridden CalculateEarnings()
        //************************************************
        public override double CalculateEarnings()
        {   //  Begin public override double CalculateEarnings()
            if ((piecesPerHour > MAXPIECES) && (piecesPerHour < MINPIECES))
            {
                piecesPerHour = DEFPIECES;
            }

            if ((pricePerPiece > MAXPPP) && (pricePerPiece < MINPPP))
            {
                pricePerPiece = DEFPPP;
            }

            grossPay = piecesPerHour * pricePerPiece;
            return grossPay;
        }   //  End   public override double CalculateEarnings()

        //************************************************
        //	Overridden ToString()
        //************************************************
        public override string ToString()
        {   //  Begin public override string ToString()
            string outputStr = "";

            outputStr += "Employee Name: "   + FirstName    + " " +
                                             MiddleInit     + " " +
                                             LastName       + "\n";
            outputStr += "Union Status:  "   + IsUnion.ToString()       + "\n";
            outputStr += "Employee Number: " + EmpNum.ToString()        + "\n";
            outputStr += "Pieces Per Hour: " + PiecesPerHour.ToString() + "\n";
            outputStr += "Price Per Piece: " + PricePerPiece.ToString("c") + "\n";
            outputStr += "Gross Pay: "       + grossPay.ToString("c")      + "\n";

            return outputStr;
        }   //  End   public override string ToString()
    }
}
