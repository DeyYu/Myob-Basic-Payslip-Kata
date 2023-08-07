using System;

namespace Myob_Basic_Payslip_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration 
            DateTime StartD;
            DateTime EndD;
            double Salary;
            double Tax;
            double Super;
            double Days;
            int HW = 2080;

            //Finding Business within a week
            static double GetBusinessDays(DateTime StartD, DateTime EndD)
            {
                double calcBusinessDays =
                    1 + ((EndD - StartD).TotalDays * 5 -
                    (StartD.DayOfWeek - EndD.DayOfWeek) * 2) / 7;

                if (EndD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
                if (StartD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

                return calcBusinessDays;
            }

            //Finding tax bracket
            static double GetTax(double Salary)
            {
                if (Salary >= 18201 & Salary <= 37000)
                {
                    return (Salary - 18200) * 0.19;
                }
                else if (Salary >= 37001 & Salary <= 87000)
                {
                    return ((Salary - 37000) * 0.325 + 3572);
                }
                else if (Salary >= 87001 & Salary <= 180000)
                {
                    return ((Salary - 87000) * 0.37 + 19822);
                }
                else if (Salary >= 180001)
                {
                    return ((Salary - 180000) * 0.45 + 54232);
                }
                else
                {
                    return 0;
                }
            }

            //Taking user inputs with error handling
            Console.WriteLine("Welcome to the payslip generator!\n");
                Console.WriteLine("Please input your first name:");
                string Fn = Console.ReadLine();
                Console.WriteLine("Please input your surname:");
                string Sn = Console.ReadLine();
            try
            {
                Console.WriteLine("Please input your annual salary:");
                Salary = Double.Parse(Console.ReadLine());
                Console.WriteLine("Please input your super rate:");
                Super = Double.Parse(Console.ReadLine());
                Console.WriteLine("Please input your payment start date (e.g. DD/MM/YYYY):");
                StartD = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Please input your payment end date (e.g. DD/MM/YYYY):");
                EndD = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input, please double check and try again.");
                return;
            }

            //Calculations and rounding
            Days = GetBusinessDays(StartD, EndD);
            Tax = GetTax(Salary);
            double RGross = Math.Round((((Salary / HW)*8)*Days), 0);
            double RTax = Math.Round((((Tax/HW)*8)* Days), 0);
            double Rsuper = Math.Round(((Super / 100) * RGross), 0);

            //Present data
            Console.WriteLine("Your payslip has been generated:\n");
            Console.WriteLine("Name: " + Fn + " " + Sn);
            Console.WriteLine("Pay Period: " + StartD + " - " + EndD);
            Console.WriteLine("Gross Income: " + RGross);
            Console.WriteLine("Income Tax: " + RTax);
            Console.WriteLine("Net Income: " + (RGross - RTax));
            Console.WriteLine("Super: " + Rsuper + "\n");
            Console.WriteLine("Thank you for using MYOB!");
            Console.ReadKey();
        }
    }
}

