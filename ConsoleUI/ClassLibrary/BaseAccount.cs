using System;

namespace ConsoleUI
{
    public class BaseAccount : ILoanAccount
    {
        private decimal _homePrice;
        private decimal _marketValue;
        private decimal _downPayment;
        private decimal _monthlyPayment;
        private decimal _totalLoanValue;
        private float _interestRate;
        private int _paymentsPerYear;
        private int _termInYears;
       

        public decimal HomePrice { get { return _homePrice; } set { _homePrice = _totalLoanValue = value; } }
        public decimal DownPayment { get { return _downPayment; } set { _downPayment = value; } }
        public float InterestRate { get { return _interestRate; } set { _interestRate = value / 100; } }
        public int PaymentsPerYear { get { return _paymentsPerYear; } set { _paymentsPerYear = value; } }
        public int TermInYears { get { return _termInYears; } set { _termInYears = value; } }
        public decimal MarketValue { get { return _marketValue; } set { _marketValue = value; } }
        
        public decimal MonthlyPayment { get { return _monthlyPayment; } }
        public decimal TotalLoanValue { get { return _totalLoanValue; } }


        public BaseAccount()
        {
            _homePrice = 0;
            _downPayment = 0;
            _interestRate = 0f;
            _paymentsPerYear = 12;
            _termInYears = 30;
            _totalLoanValue = 0;
      
        }

        public BaseAccount(decimal homePrice, decimal downPayment, float interestRate, int paymentsPerYear = 12, int termInYears = 30, int hoaFees = 0)
        {
            _homePrice = homePrice;
            _downPayment = downPayment;
            _interestRate = interestRate;
            _paymentsPerYear = paymentsPerYear;
            _termInYears = termInYears;
            _totalLoanValue = homePrice;

        }

        public void AddFees(decimal[] fees)
        {
            foreach (decimal fee in fees)
            {
                _totalLoanValue += fee;
            }
        }
        public void CalculateMonthlyPayment()
        {
            
            decimal paymentInTerms = _paymentsPerYear * _termInYears;
            decimal monthlyInterestRate = (decimal)_interestRate / (decimal)_paymentsPerYear;

            decimal numerator = (_homePrice - _downPayment) * monthlyInterestRate * ((decimal)Math.Pow((double)(1 + monthlyInterestRate), (double)paymentInTerms));
            decimal denominator = (decimal)Math.Pow((double)(1 + monthlyInterestRate), (double)paymentInTerms) - 1;

            _monthlyPayment = (decimal)numerator / denominator;

            
        }

        public decimal GetMonthlyPayment()
        {
            return _monthlyPayment;
        }

        public void DisplayMonthlyPayment()
        {
            Console.WriteLine($"Principal and interest:\t { MonthlyPayment.ToString("C2") }");
        }
    }
}