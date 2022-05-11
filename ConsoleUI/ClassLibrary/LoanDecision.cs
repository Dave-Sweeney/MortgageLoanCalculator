using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ClassLibrary
{
    public static class LoanDecision
    {
        public static void GetLoanDecision(LoanApplication application, decimal monthlyIncome)
        {
            decimal monthlyPayment = application.GetMonthlyPayment();
            Console.WriteLine();
            if (monthlyIncome / 4 >= monthlyPayment)
            {
                Console.WriteLine("Recommendation:  APPROVE");
            }
            else Console.WriteLine("Recommendation:  DENY");
        }
    }
}
