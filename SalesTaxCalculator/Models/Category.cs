namespace SalesTaxCalculator.Models
{
    public abstract class Category
    {
        public abstract bool IsTaxExempt { get; }

        public static readonly Category NotSpecified = new NotSpecifiedCategory();
        public static readonly Category Magazines = new MagazinesCategory();
        public static readonly Category Food = new FoodCategory();
        public static readonly Category Electronics = new ElectronicsCategory();

        private sealed class NotSpecifiedCategory : Category
        {
            public override bool IsTaxExempt => false;
        }

        private sealed class MagazinesCategory : Category
        {
            public override bool IsTaxExempt => true;
        }

        private sealed class FoodCategory : Category
        {
            public override bool IsTaxExempt => true;
        }

        private sealed class ElectronicsCategory : Category
        {
            public override bool IsTaxExempt => true;
        }
    }
}
