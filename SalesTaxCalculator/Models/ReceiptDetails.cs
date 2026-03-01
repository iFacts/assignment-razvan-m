namespace SalesTaxCalculator.Models
{
    public class ReceiptDetails(IEnumerable<ReceiptItem> items, decimal salesTax, decimal total)
    {
        public IEnumerable<ReceiptItem> Items { get; } = items;
        public decimal SalesTax { get; } = salesTax;
        public decimal Total { get; } = total;
    }
}
