using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public interface ILoanAccount
    {
        void CalculateMonthlyPayment();
        decimal GetMonthlyPayment();

        void DisplayMonthlyPayment();
    }
}
