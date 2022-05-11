using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class EscrowAccount : ILoanAccount
    {
        private BaseAccount _account;
        private decimal _homeownersInsurance = 0;
        private decimal _propertyTaxes = 0;
        private const decimal HOMEOWNERS_INSURANCE_RATE = (decimal).0075;
        private const decimal PROPERTY_TAX_RATE = (decimal).0125;
        public decimal HomeownersInsurance { get { return _homeownersInsurance; } }
        public decimal PropertyTaxes { get { return _propertyTaxes; } }

       
        public EscrowAccount(BaseAccount account)
        {
            _account = account;
            CalculateHomeownersInsurance();
            CalculatePropertyTaxes();
        }
        public void CalculateHomeownersInsurance()
        {
            _homeownersInsurance = Convert.ToDecimal(_account.MarketValue * HOMEOWNERS_INSURANCE_RATE / 12);
        }

        public void CalculatePropertyTaxes()
        {
            
            _propertyTaxes = Convert.ToDecimal(_account.MarketValue * PROPERTY_TAX_RATE / 12);
        }

        
        public void CalculateMonthlyPayment()
        {
            CalculateHomeownersInsurance();
            CalculatePropertyTaxes();
        }

        public decimal GetMonthlyPayment()
        {
            return _homeownersInsurance + _propertyTaxes;
        }

        public void DisplayMonthlyPayment()
        {
            Console.WriteLine($"Homeowners Insurance:\t { HomeownersInsurance.ToString("C2") }");
            Console.WriteLine($"Property Taxes:\t\t { PropertyTaxes.ToString("C2") }");
        }
    }
}
