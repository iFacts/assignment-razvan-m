using SalesTaxCalculator.Configuration;
using SalesTaxCalculator.Models;

namespace SalesTaxCalculator.TaxCalculation
{
    public class ImportTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(Item item)
        {
            if (!item.IsImported)
            {
                return 0m;
            }

            return Math.Round(item.Price * TaxRates.ImportTaxRate, 2);
        }
    }
}
