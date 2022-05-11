using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class PrivateMortgageInsurance : ILoanAccount
    {
        private BaseAccount _account;
        private decimal _PMI = 0;
        private decimal _equity = 0;
        
        private const decimal PMI_RATE = (decimal)0.01;
        private const decimal MONTHS_PER_YEAR = (decimal)12;
        

        public decimal PMI { get { return _PMI / MONTHS_PER_YEAR; } }
        public decimal Equity { get { return _equity; } }   

        public PrivateMortgageInsurance(BaseAccount account)
        {
            _account = account;
            
        }

        public void CalculateEquity()
        {
            _equity = 1 - ((_account.TotalLoanValue - _account.DownPayment) / _account.MarketValue);
        }
        public void CalculatePMI()
        {

            if (_equity < (decimal)0.1)
            {
                _PMI = PMI_RATE * (_account.HomePrice - _account.DownPayment);
            }
            else _PMI = 0;
        }

        
        public void CalculateMonthlyPayment()
        {
            CalculateEquity();
            CalculatePMI();
        }

        public decimal GetMonthlyPayment()
        {
            return _PMI / MONTHS_PER_YEAR;
        }

        public void DisplayMonthlyPayment()
        {
            Console.WriteLine($"Equity: { Equity.ToString("P") }");
            Console.WriteLine($"The PMI each month is: \t { PMI.ToString("C2") }");
        }
    }
}
