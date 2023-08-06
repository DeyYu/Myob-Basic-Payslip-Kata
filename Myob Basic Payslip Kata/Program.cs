using System;

namespace Myob_Basic_Payslip_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration 

            DateTime StartDate;
            DateTime EndDate;
            decimal Salary;
            decimal Super;
            decimal Tax;
            int Days;
            double Months = 30.4167;
            double TaxRatio;

            //Taking user inputs with error handling
            Console.WriteLine("Welcome to the payslip generator!\n");
                Console.WriteLine("Please input your first name:");
                string Fn = Console.ReadLine();
                Console.WriteLine("Please input your surname:");
                string Sn = Console.ReadLine();

            try
            {
                Console.WriteLine("Please input your annual salary:");
                Salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Please input your super rate:");
                Super = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Please input your payment start date (e.g. DD/MM/YYYY):");
                StartDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Please input your payment end date (e.g. DD/MM/YYYY):");
                EndDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input, please double check and try again.");
                return;
            }


            //Finding tax bracket
            Days = (EndDate - StartDate).Days;
            if (Salary >= 18201 & Salary <= 37000)
            {
                TaxRatio = 0.19;
                Tax = (Salary - 18200) * Convert.ToDecimal(TaxRatio);
            }
            else if (Salary >= 37001 & Salary <= 87000)
            {
                TaxRatio = 0.325;
                Tax = ((Salary - 37000) * Convert.ToDecimal(TaxRatio)) + 3572;
            }
            else if (Salary >= 87001 & Salary <= 180000)
            {
                TaxRatio = 0.37;
                Tax = ((Salary - 87000) * Convert.ToDecimal(TaxRatio)) + 19822;
            }
            else if (Salary >= 180001)
            {
                TaxRatio = 0.45;
                Tax = ((Salary - 180000) * Convert.ToDecimal(TaxRatio)) + 54232;
            }
            else
            {
                Tax = 0;
            }

            //Calculations and Rounding

            decimal RGross = Math.Round((((Salary / 12) / Convert.ToDecimal(Months)) * Days), MidpointRounding.AwayFromZero);
            decimal RTax = Math.Round((((Tax / 12) / Convert.ToDecimal(Months)) * Days), MidpointRounding.AwayFromZero);
            decimal Rsuper = Math.Round((((((Super / 100) * RGross) / 12) / Convert.ToDecimal(Months)) * Days), MidpointRounding.AwayFromZero);

            //Present Data
            Console.WriteLine("Your payslip has been generated:\n");
            Console.WriteLine("Name: " + Fn + " " + Sn);
            Console.WriteLine("Pay Period: " + StartDate + " - " + EndDate);
            Console.WriteLine("Gross Income: " + RGross);
            Console.WriteLine("Income Tax: " + RTax);
            Console.WriteLine("Net Income: " + (RGross - RTax));
            Console.WriteLine("Super: " + Rsuper + "\n");
            Console.WriteLine("Thank you for using MYOB!");
            Console.ReadKey();
        
        }
    }
}

