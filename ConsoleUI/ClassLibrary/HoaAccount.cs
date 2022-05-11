using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class HoaAccount : ILoanAccount
    {
        private BaseAccount _account;
        private decimal _annualFee;
        private decimal _monthlyFee;
        private const decimal MONTHS_IN_YEAR = 12;

        public decimal MonthlyFee { get { return _annualFee / MONTHS_IN_YEAR; } }
        public decimal AnnualFee { set { _annualFee = value; } } 

        public HoaAccount(BaseAccount account)
        {
            _account = account;
            _annualFee = 0;
        }

        public void CalculateMonthlyPayment()
        {
            _monthlyFee = _annualFee / 12;
        }

        public decimal GetMonthlyPayment()
        {
            return MonthlyFee;
        }

        public void DisplayMonthlyPayment()
        {
            Console.WriteLine($"HOA Fees:\t\t { MonthlyFee.ToString("C2") }");
        }
    }
}
