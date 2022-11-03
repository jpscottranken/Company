
using EmployeeLibrary;
using System;
using System.Collections.Generic;
using static System.Console;

namespace EmployeeConsole
{
    class Program
    {
        //  Global variables
        static List<Hourly> hourly           = new List<Hourly>();
        static List<Pieceworker> pieceworker = new List<Pieceworker>();
        static List<Salaried> salaried       = new List<Salaried>();
        static List<Commission> commission   = new List<Commission>();

        static void Main(string[] args)
        {
           //  Fill Hourly employee list with 2 initial employees
            //  One utilizing fully parameterized constructor and
            //  one utilizing the empty constructor
            var jeffH = new Hourly("Jeffrey", "P", "Scott", false, 12345, 50, 20);
            var johnH = new Hourly();
            jeffH.CalculateEarnings();
            hourly.Add(jeffH);
            hourly.Add(johnH);

            //  Fill Pieceworker employee list with 2 initial employees
            //  One utilizing fully parameterized constructor and
            //  one utilizing the empty constructor
            var sandyP = new Pieceworker("Sandra", "K", "Scott", true, 23456, 50, 0.75);
            sandyP.CalculateEarnings();
            var kathyP = new Pieceworker();
            pieceworker.Add(sandyP);
            pieceworker.Add(kathyP);

            //  Fill Salaried employee list with 2 initial employees
            //  One utilizing fully parameterized constructor and
            //  one utilizing the empty constructor
            var chloeS = new Salaried("Chloe", "J", "Scott", false, 34567, 1000);
            chloeS.CalculateEarnings();
            var mackS  = new Salaried();
            salaried.Add(chloeS);
            salaried.Add(mackS);

            //  Fill Commission employee list with 2 initial employees
            //  One utilizing fully parameterized constructor and
            //  one utilizing the empty constructor
            var taylorC = new Commission("Taylor", "F", "Scott", false, 45678, .15, 1000);
            taylorC.CalculateEarnings();
            var oliviaC = new Commission();
            commission.Add(taylorC);
            commission.Add(oliviaC);

            //  Call presentMenu() to show associated action menu
            presentMenu();
        }

        static void presentMenu()
        {

            Write("Please hit the <enter> key to continue: ");
            ReadLine();
            Console.Clear();
            string menuChoice;

            WriteLine("\nEnter a  1 to create a new hourly employee");
            WriteLine("\nEnter a  2 to create a new pieceWorker employee");
            WriteLine("\nEnter a  3 to create a new salaried employee");
            WriteLine("\nEnter a  4 to create a new commission employee");
            WriteLine("\nEnter a  5 to print out the hourly employee list");
            WriteLine("\nEnter a  6 to print out the pieceworker employee list");
            WriteLine("\nEnter a  7 to print out the salaried employee list");
            WriteLine("\nEnter an 8 to print out the commission employee list");
            WriteLine("\nEnter a  9 to quit the program");
            Write("\nPlease enter a 1, 2, 3, 4, 5, 6, 7, 8, or 9 now: ");
            menuChoice = ReadLine();

            while ((menuChoice != "1") && (menuChoice != "2") && (menuChoice != "3") && 
                   (menuChoice != "4") && (menuChoice != "5") && (menuChoice != "6") && 
                   (menuChoice != "7") && (menuChoice != "8") && (menuChoice != "9"))
            {
                WriteLine("Please enter a number 1-9. Press enter now.");
                ReadLine();
                Console.Clear();
                presentMenu();
            }

            switch (menuChoice)
            {
                case "1":
                    //WriteLine("Called routine to create new Hourly Employee");
                    //ReadLine();
                    createNewHourlyEmployee();
                    break;

                case "2":
                    //WriteLine("Called routine to create new Pieceworker Employee");
                    //ReadLine();
                    createNewPieceWorkerEmployee();
                    break;

                case "3":
                    //WriteLine("Called routine to create new Salaried Employee");
                    //ReadLine();
                    createNewSalariedEmployee();
                    break;

                case "4":
                    //WriteLine("Called routine to create new Commission Employee");
                    //ReadLine();
                    createNewCommissionEmployee();
                    break;

                case "5":
                    //WriteLine("Called routine to show all Hourly Employees");
                    //ReadLine();
                    iteratehourlyEmployee();
                    break;

                case "6":
                    //WriteLine("Called routine to show all Pieceworker Employees");
                    //ReadLine();
                    iteratePieceWorkerEmployee();
                    break;

                case "7":
                    //WriteLine("Called routine to show all Salaried Employees");
                    //ReadLine();
                    iterateSalariedEmployee();
                    break;

                case "8":
                    //WriteLine("Called routine to show all Commission Employees");
                    //ReadLine();
                    iterateCommissionEmployee();
                    break;

                case "9":
                    WriteLine("Called routine to exit the program normally now");
                    ReadLine();
                    Environment.Exit(0);
                    break;

                default:
                    WriteLine("Illegal Menu Action.  Try Again");
                    ReadLine();
                    Console.Clear();
                    presentMenu();
                    break;
            }
        }

        public static void createNewHourlyEmployee()
        {
            Console.Clear();
            buildGenericObject(1);
            presentMenu();
        }

        static void createNewPieceWorkerEmployee()
        {
            Console.Clear();
            buildGenericObject(2);
            presentMenu();
        }

        static void createNewSalariedEmployee()
        {
            Console.Clear();
            buildGenericObject(3);
            presentMenu();
        }

        static void createNewCommissionEmployee()
        {
            Console.Clear();
            buildGenericObject(4);
            presentMenu();
        }

        public static void buildGenericObject(int code)
        {
            string first = "";
            string mid = "";
            char mi = ' ';
            string last = "";
            string unionStr = "";
            bool union = false;
            int enumb = 0;
            string thenum = "";
            string total = "";

            switch (code)
            {
                case 1:
                    WriteLine("Entering New Hourly Employee Info:");
                    break;

                case 2:
                    WriteLine("Entering New Pieceworker Employee Info:");
                    break;

                case 3:
                    WriteLine("Entering New Salaried Employee Info:");
                    break;

                case 4:
                    WriteLine("Entering New Commission Employee Info:");
                    break;

                default:
                    return;
            }

            //  Input generic (i.e. any/all) employee info
            Write("Enter a first name: ");
            first = ReadLine().ToUpper();
            total += first + "\n";

            Write("Enter a middle initial: ");
            mid = ReadLine().ToUpper();
            //mi = mid[0];
            total += mi + "\n";

            Write("Enter a last name: ");
            last = ReadLine().ToUpper();
            total += last + "\n";

            Write("Enter union status (true or false): ");

            unionStr = ReadLine();
            if ((unionStr != "true") && (unionStr != "false"))
            {
                union = false;
            }
            else
            {
                union = Convert.ToBoolean(unionStr);
            }
            total += union + "\n";

            Write("Enter employee number: ");
            thenum = ReadLine();
            bool flag = false;

            flag = int.TryParse(thenum, out enumb);
            if (!flag)
            {
                enumb = -999;
            }
            total += enumb.ToString() + "\n";

            switch (code)
            {
                case 1:
                    inputHoursWorkedAndHourlyRate(total);
                    break;
                case 2:
                    inputPieceWorkerEmployee(total);
                    break;
                case 3:
                    inputSalariedEmployee(total);
                    break;
                case 4:
                    inputCommissionEmployee(total);
                    break;
                default:
                    break;
            }
        }

        //hourly
        public static void inputHoursWorkedAndHourlyRate(string t)
        {
            string hwstr = "";
            string hrstr = "";
            double hw = 0.0;
            double hr = 0.0;

            Write("Enter hours worked (0-84): ");
            hwstr = ReadLine();
            bool flag = false;

            flag = double.TryParse(hwstr, out hw);
            if (!flag)
            {
                hw = -999;
            }
            else
            {
                hw = Convert.ToDouble(hwstr);
            }

            Write("Enter hourly rate (0-100): ");
            hrstr = ReadLine();
            flag = false;

            flag = double.TryParse(hrstr, out hr);
            if (!flag)
            {
                hr = -999;
            }
            else
            {
                hr = Convert.ToDouble(hrstr);
            }

            t += hw.ToString("f2") + "\n" +
                 hr.ToString("f2") + "\n";

            instantiateHourlyEmployee(t);
        }

        public static void instantiateHourlyEmployee(string t)
        {
            string[] values = t.Split('\n');
            Hourly h = null;

            h = new Hourly(values[0], values[1], values[2],
                           Convert.ToBoolean(values[3]),
                           Convert.ToInt32(values[4]),
                           Convert.ToDouble(values[5]),
                           Convert.ToDouble(values[6]));

            fillUpHourlyArrayList(h);
        }

        public static void fillUpHourlyArrayList(Hourly h)
        {
            try
            {
                hourly.Add(h);
            }
            catch (OutOfRangeHourlyRateException e)
            {
                WriteLine(e.Message);
                WriteLine(e.StackTrace);
                ReadLine();
            }

            h.CalculateEarnings();
        }

        public static void inputPieceWorkerEmployee(string t)
        {
            string phstr = "";
            string ppstr = "";
            string gpstr = "";
            double ph = 0.0;
            double pp = 0.0;
            double gp = 0.0;

            Write("Enter Pieces Per Hour (0-100): ");
            phstr = ReadLine();
            bool flag = false;

            flag = double.TryParse(phstr, out ph);
            if (!flag)
            {
                ph = -999;
            }
            else
            {
                ph = Convert.ToDouble(phstr);
            }

            Write("Enter Price Per Piece (0.0-1.0): ");
            ppstr = ReadLine();
            flag = false;

            flag = double.TryParse(ppstr, out pp);
            if (!flag)
            {
                pp = -999;
            }
            else
            {
                pp = Convert.ToDouble(ppstr);
            }

            gpstr = Convert.ToString(ph * pp);
            flag = false;

            flag = double.TryParse(gpstr, out gp);
            if (!flag)
            {
                gp = -999;
            }
            else
            {
                gp = Convert.ToDouble(gpstr);
            }

            t += ph.ToString() + "\n" +
                 pp.ToString("f2") + "\n" +
                 gp.ToString("f2") + "\n";

            instantiatePieceWorkerEmployee(t);
        }

        public static void instantiatePieceWorkerEmployee(string t)
        {
            string[] values = t.Split('\n');
            Pieceworker p = null;

            p = new Pieceworker(values[0], values[1], values[2],
                           Convert.ToBoolean(values[3]),
                           Convert.ToInt32(values[4]),
                           Convert.ToInt32(values[5]),
                           Convert.ToDouble(values[6]));

            fillUpPieceWorkerArrayList(p);
        }

        public static void fillUpPieceWorkerArrayList(Pieceworker p)
        {
            p.CalculateEarnings();
            pieceworker.Add(p);
        }

        public static void inputSalariedEmployee(string t)
        {
            string wsstr = "";
            string ysstr = "";
            double ws = 0.0;
            double ys = 0.0;

            Write("Enter weekly salary (1000-20000): ");
            wsstr = ReadLine();
            bool flag = false;

            flag = double.TryParse(wsstr, out ws);
            if (!flag)
            {
                ws = -999;
            }
            else
            {
                ws = Convert.ToDouble(wsstr);
            }


            ysstr = Convert.ToString(ws * 52);  // WEEKSINYEAR);
            flag = false;

            flag = double.TryParse(ysstr, out ys);
            if (!flag)
            {
                ys = -999;
            }
            else
            {
                ys = Convert.ToDouble(ysstr);
            }

            t += ws.ToString("f2") + "\n" +
                 ys.ToString("f2") + "\n";

            instantiateSalariedEmployee(t);
        }

        public static void instantiateSalariedEmployee(string t)
        {
            string[] values = t.Split('\n');
            Salaried s = null;

            s = new Salaried(values[0], values[1], values[2],
                           Convert.ToBoolean(values[3]),
                           Convert.ToInt32(values[4]),
                           Convert.ToDouble(values[5]));

            fillUpSalariedArrayList(s);
        }

        public static void fillUpSalariedArrayList(Salaried s)
        {
            s.CalculateEarnings();
            salaried.Add(s);
        }


        //Commission
        public static void inputCommissionEmployee(string t)
        {
            string crstr = "";
            string wsstr = "";
            string gpstr = "";
            double cr = 0.0;
            double ws = 0.0;
            double gp = 0.0;

            Write("Enter Commission Rate(0.10-0.33): ");
            crstr = ReadLine();
            bool flag = false;

            flag = double.TryParse(crstr, out cr);
            if (!flag)
            {
                cr = -999;
            }
            else
            {
                cr = Convert.ToDouble(crstr);
            }

            Write("Enter weekly sales (0-10000): ");
            wsstr = ReadLine();
            flag = false;

            flag = double.TryParse(wsstr, out ws);
            if (!flag)
            {
                ws = -999;
            }
            else
            {
                ws = Convert.ToDouble(wsstr);
            }

            gpstr = Convert.ToString(cr * ws);
            flag = false;

            flag = double.TryParse(gpstr, out gp);
            if (!flag)
            {
                gp = -999;
            }
            else
            {
                gp = Convert.ToDouble(gpstr);
            }

            t += cr.ToString("f2") + "\n" +
                 ws.ToString("f2") + "\n" +
                 gp.ToString("f2") + "\n";

            instantiateCommissionEmployee(t);
        }

        public static void instantiateCommissionEmployee(string t)
        {
            string[] values = t.Split('\n');
            Commission c = null;

            c = new Commission(values[0], values[1], values[2],
                           Convert.ToBoolean(values[3]),
                           Convert.ToInt32(values[4]),
                           Convert.ToDouble(values[5]),
                           Convert.ToDouble(values[6]));

            fillUpCommissionArrayList(c);
        }

        public static void fillUpCommissionArrayList(Commission c)
        {
            c.CalculateEarnings();
           
            
            commission.Add(c);
        }

        public static void iteratehourlyEmployee()
        {
            int lcv = 0;
            Console.Clear();

            for (lcv = 0; lcv < hourly.Count; ++lcv)
            {
                WriteLine("Employee " + lcv + ":\n" + hourly[lcv].ToString());
            }
            WriteLine("Press enter");
            ReadLine();
            Console.Clear();
            presentMenu();
        }

        public static void iteratePieceWorkerEmployee()
        {
            int lcv = 0;
            Console.Clear();

            for (lcv = 0; lcv < pieceworker.Count; ++lcv)
            {
                WriteLine("Employee " + lcv + ":\n" + pieceworker[lcv].ToString());
            }
            WriteLine("Press enter");
            ReadLine();
            Console.Clear();
            presentMenu();
        }

        public static void iterateSalariedEmployee()
        {
            int lcv = 0;
            Console.Clear();

            for (lcv = 0; lcv < salaried.Count; ++lcv)
            {
                WriteLine("Employee " + lcv + ":\n" + salaried[lcv].ToString());
            }
            WriteLine("Press enter");
            ReadLine();
            Console.Clear();
            presentMenu();
        }

        public static void iterateCommissionEmployee()
        {
            int lcv = 0;
            Console.Clear();

            for (lcv = 0; lcv < commission.Count; ++lcv)
            {
                WriteLine("Employee " + lcv + ":\n" + commission[lcv].ToString());
            }
            WriteLine("Press enter");
            ReadLine();
            Console.Clear();
            presentMenu();
        }
    }
}
