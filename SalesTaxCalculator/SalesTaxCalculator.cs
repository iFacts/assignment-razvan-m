using SalesTaxCalculator.Models;
using SalesTaxCalculator.Rounding;
using SalesTaxCalculator.TaxCalculation;

namespace SalesTaxCalculator
{
    public static class SalesTaxCalculator
    {
        public static ReceiptDetails Process(params Item[] items)
        {
            return Process(new StandardRoundingStrategy(), items);
        }

        public static ReceiptDetails Process(IRoundingStrategy roundingStrategy, params Item[] items)
        {
            var taxCalculator = CreateTaxCalculator();

            var receiptItems = new List<ReceiptItem>();
            decimal totalSalesTax = 0m;
            decimal totalCost = 0m;

            foreach (var item in items)
            {
                var tax = taxCalculator.CalculateTax(item);
                var priceIncludingTax = item.Price + tax;

                receiptItems.Add(new ReceiptItem(item.Name, roundingStrategy.Round(priceIncludingTax)));

                totalSalesTax += tax;
                totalCost += priceIncludingTax;
            }

            return new ReceiptDetails(receiptItems, roundingStrategy.Round(totalSalesTax), roundingStrategy.Round(totalCost));
        }

        private static CompositeTaxCalculator CreateTaxCalculator()
        {
            var salesTaxCalculator = new BaseSalesTaxCalculator();
            var importTaxCalculator = new ImportTaxCalculator();

            return new CompositeTaxCalculator([salesTaxCalculator, importTaxCalculator]);
        }

    }
}
