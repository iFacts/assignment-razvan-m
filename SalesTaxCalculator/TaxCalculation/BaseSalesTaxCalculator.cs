using SalesTaxCalculator.Configuration;
using SalesTaxCalculator.Models;

namespace SalesTaxCalculator.TaxCalculation
{
    public class BaseSalesTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(Item item)
        {
            if (item.Category.IsTaxExempt)
            {
                return 0m;
            }

            return Math.Round(item.Price * TaxRates.SalesTaxRate, 2);
        }
    }
}
