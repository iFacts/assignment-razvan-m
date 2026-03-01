namespace SalesTaxCalculator.Models
{
    public class ReceiptItem(string name, decimal priceIncludingSalesTax)
    {
        public string Name { get; set; } = name;
        public decimal PriceIncludingSalesTax { get; } = priceIncludingSalesTax;
    }
}
