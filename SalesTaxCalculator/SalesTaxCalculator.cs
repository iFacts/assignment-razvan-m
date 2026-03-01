using SalesTaxCalculator.Models;
using SalesTaxCalculator.Rounding;
using SalesTaxCalculator.TaxCalculation;

namespace SalesTaxCalculator
{
    public static class SalesTaxCalculator
    {
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

                receiptItems.Add(new ReceiptItem(item.Name, priceIncludingTax));

                totalSalesTax += tax;
                totalCost += priceIncludingTax;
            }

            return new ReceiptDetails(receiptItems, totalSalesTax, totalCost);
        }

        private static CompositeTaxCalculator CreateTaxCalculator()
        {
            var roundingStrategy = new StandardRoundingStrategy();

            var salesTaxCalculator = new BaseSalesTaxCalculator(roundingStrategy);
            var importTaxCalculator = new ImportTaxCalculator(roundingStrategy);

            return new CompositeTaxCalculator([salesTaxCalculator, importTaxCalculator]);
        }

    }
}
