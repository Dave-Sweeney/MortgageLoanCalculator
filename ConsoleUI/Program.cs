using ConsoleUI.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoanApplication app = new LoanApplication();
            
            app = GetLoanInformation();
            app.CalculateMonthlyPayment();           
            app.DisplayMonthlyPayment();

            decimal income = GetValidDecimal("Please enter the applicant's monthly income: ");
            LoanDecision.GetLoanDecision(app, income);

            Console.ReadKey();
        }


        private static LoanApplication GetLoanInformation()
        {
            LoanApplication application = new LoanApplication();

            application.BaseAccount.HomePrice = GetValidDecimal("Enter the home price in dollars: ");
            application.BaseAccount.MarketValue = GetValidDecimal("Enter the market value in dollars: ");
            application.BaseAccount.DownPayment = GetValidDecimal("Enter the down payment in dollars: ");
            application.BaseAccount.InterestRate = GetValidFloat("Enter the interest rate (e.g. for 6% enter 6): ");
            application.BaseAccount.TermInYears = GetValidInt("Enter the loan term in years: ");
            application.HoaAccount.AnnualFee = GetValidDecimal("Enter the annual HOA fees: ");

            return application;
        }

        private static decimal GetValidDecimal(string inputMessage)
        {
            decimal result = 0;
            bool invalidInput = true;

            while (invalidInput)
            {
                try
                {
                    Console.Write(inputMessage);
                    result = decimal.Parse(Console.ReadLine());
                    if (result >= 0)
                    {
                        invalidInput = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("You entered invalid input.  Please enter a decimal");
                }
            }

            return result;
        }

        private static float GetValidFloat(string inputMessage)
        {
            float result = 0;
            bool invalidInput = true;

            while (invalidInput)
            {
                try
                {
                    Console.Write(inputMessage);
                    result = float.Parse(Console.ReadLine());
                    if (result > 0)
                    {
                        invalidInput = false;
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("You entered invalid input.  Please enter a decimal");
                }
            }

            return result;
        }

        private static int GetValidInt(string inputMessage)
        {
            int result = 0;
            bool invalidInput = true;

            while (invalidInput)
            {
                try
                {
                    Console.Write(inputMessage);
                    result = Int32.Parse(Console.ReadLine());
                    if (result >= 0)
                    {
                        invalidInput = false;
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("You entered invalid input.  Please enter a decimal");
                }
            }

            return result;
        }
        
    }
}
