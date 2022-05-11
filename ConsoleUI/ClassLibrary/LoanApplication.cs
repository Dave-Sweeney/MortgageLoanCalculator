using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class LoanApplication : ILoanAccount
    {
        private List<ILoanAccount> _loanAccount;

        private EscrowAccount _escrowAccount;
        private PrivateMortgageInsurance _mortgageInsurance;
        private HoaAccount _hoaAccount;
        private BaseAccount _baseAccount;
        private decimal _originationFee;
        private decimal _monthlyPayment;

        private const decimal ORIGINATION_FEE = (decimal).01;
        private const decimal TAXES_AND_CLOSING_FEE = 2500;

        public LoanApplication()
        {
            _baseAccount = new BaseAccount();

            _escrowAccount = new EscrowAccount(_baseAccount);
            _mortgageInsurance = new PrivateMortgageInsurance(_baseAccount);
            _hoaAccount = new HoaAccount(_baseAccount);

            _loanAccount = new List<ILoanAccount>();
            _loanAccount.Add(_baseAccount);
            _loanAccount.Add(_escrowAccount);
            _loanAccount.Add(_mortgageInsurance);
            _loanAccount.Add(_hoaAccount);

            _originationFee = _baseAccount.HomePrice * ORIGINATION_FEE;
        }

        public decimal PrincipleAndInterest { get { return this._baseAccount.MonthlyPayment; } }
        public decimal OriginationFee { get { return _originationFee; } }

        public BaseAccount BaseAccount { get { return _baseAccount; } }
        public EscrowAccount EscrowAccount { get { return _escrowAccount; } }
        public PrivateMortgageInsurance PMI { get { return _mortgageInsurance; } }
        public HoaAccount HoaAccount { get { return _hoaAccount; } }

        public decimal HomeownersInsurance { get { return this._escrowAccount.HomeownersInsurance; } }
        public decimal TotalLoanValue { get { return _baseAccount.HomePrice - _baseAccount.DownPayment + _originationFee; } }
                
        public void CalculateMonthlyPayment()
        {
            _originationFee = _baseAccount.HomePrice * ORIGINATION_FEE;

            decimal[] additionalFees = { _originationFee, TAXES_AND_CLOSING_FEE };
            _baseAccount.AddFees(additionalFees);

            foreach (ILoanAccount loan in _loanAccount)
            {
                loan.CalculateMonthlyPayment();
            }
        }

        public decimal GetMonthlyPayment()
        {
            _monthlyPayment = 0;

            foreach (ILoanAccount loan in _loanAccount)
            {
                _monthlyPayment += loan.GetMonthlyPayment();
            }

            return _monthlyPayment;
        }

        public void DisplayMonthlyPayment()
        {
            Console.WriteLine();
            Console.WriteLine("SUMMARY:");
            Console.WriteLine("Description\t\t Monthly");
            Console.WriteLine("-----------\t\t -------");
            foreach(ILoanAccount loan in _loanAccount)
            {
                loan.DisplayMonthlyPayment();
            }
            Console.WriteLine($"Total:\t\t\t { GetMonthlyPayment().ToString("C2") }");
            Console.WriteLine();
        }

    }
}
