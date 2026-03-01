namespace SalesTaxCalculator.Rounding
{
    public class StandardRoundingStrategy : IRoundingStrategy
    {
        public decimal Round(decimal value) => Math.Round(value, 2);
    }
}
