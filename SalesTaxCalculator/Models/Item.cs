namespace SalesTaxCalculator.Models
{
    public class Item(string name, decimal price, Category? category = null, bool isImported = false)
    {
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public Category Category { get; set; } = category ?? Category.NotSpecified;
        public bool IsImported { get; set; } = isImported;
    }
}
