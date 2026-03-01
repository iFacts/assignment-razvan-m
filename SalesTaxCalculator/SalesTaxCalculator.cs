using SalesTaxCalculator.Models;
using SalesTaxCalculator.Rounding;
using SalesTaxCalculator.TaxCalculation;

namespace SalesTaxCalculator
{
    public static class SalesTaxCalculator
    {
        private static readonly StandardRoundingStrategy _roundingStrategy = new();

        public static ReceiptDetails Process(params Item[] items)
        {
            var taxCalculator = CreateTaxCalculator();

            var receiptItems = new List<ReceiptItem>();
            decimal totalSalesTax = 0m;
            decimal totalCost = 0m;

            foreach (var item in items)
            {
                var tax = taxCalculator.CalculateTax(item);
                var priceIncludingTax = item.Price + tax;

                receiptItems.Add(new ReceiptItem(item.Name, _roundingStrategy.Round(priceIncludingTax)));

                totalSalesTax += tax;
                totalCost += priceIncludingTax;
            }

            return new ReceiptDetails(receiptItems, _roundingStrategy.Round(totalSalesTax), _roundingStrategy.Round(totalCost));
        }

        private static CompositeTaxCalculator CreateTaxCalculator()
        {
            var salesTaxCalculator = new BaseSalesTaxCalculator();
            var importTaxCalculator = new ImportTaxCalculator();

            return new CompositeTaxCalculator([salesTaxCalculator, importTaxCalculator]);
        }

    }
}
