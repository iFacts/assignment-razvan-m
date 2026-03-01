using SalesTaxCalculator.Models;

namespace SalesTaxCalculator.TaxCalculation
{
    public class CompositeTaxCalculator(IEnumerable<ITaxCalculator> taxCalculators) : ITaxCalculator
    {
        private readonly IEnumerable<ITaxCalculator> _taxCalculators = taxCalculators;

        public decimal CalculateTax(Item item)
        {
            return _taxCalculators.Sum(calculator => calculator.CalculateTax(item));
        }
    }
}
