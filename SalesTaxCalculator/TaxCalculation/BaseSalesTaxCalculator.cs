using SalesTaxCalculator.Configuration;
using SalesTaxCalculator.Models;
using SalesTaxCalculator.Rounding;

namespace SalesTaxCalculator.TaxCalculation
{
    public class BaseSalesTaxCalculator : ITaxCalculator
    {
        private readonly IRoundingStrategy _roundingStrategy;

        public BaseSalesTaxCalculator(IRoundingStrategy roundingStrategy)
        {
            _roundingStrategy = roundingStrategy;
        }

        public decimal CalculateTax(Item item)
        {
            if (item.Category.IsTaxExempt)
            {
                return 0m;
            }

            return _roundingStrategy.Round(item.Price * TaxRates.SalesTaxRate);
        }
    }
}
