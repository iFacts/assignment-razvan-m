using SalesTaxCalculator.Configuration;
using SalesTaxCalculator.Models;

namespace SalesTaxCalculator.TaxCalculation
{
    public class ImportTaxCalculator() : ITaxCalculator
    {
        public decimal CalculateTax(Item item)
        {
            if (!item.IsImported)
            {
                return 0m;
            }

            return item.Price * TaxRates.ImportTaxRate;
        }
    }
}
