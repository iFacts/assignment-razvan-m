using SalesTaxCalculator.Models;

namespace SalesTaxCalculator.TaxCalculation
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(Item item);
    }
}
