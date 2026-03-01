using SalesTaxCalculator.Configuration;
using SalesTaxCalculator.Models;
using SalesTaxCalculator.Rounding;

namespace SalesTaxCalculator.TaxCalculation
{
    public class ImportTaxCalculator(IRoundingStrategy roundingStrategy) : ITaxCalculator
    {
        private readonly IRoundingStrategy _roundingStrategy = roundingStrategy;

        public decimal CalculateTax(Item item)
        {
            if (!item.IsImported)
            {
                return 0m;
            }

            return _roundingStrategy.Round(item.Price * TaxRates.ImportTaxRate);
        }
    }
}
