namespace SalesTaxCalculator.Rounding
{
    public interface IRoundingStrategy
    {
        decimal Round(decimal value);
    }
}
