namespace Silpo
{
    public class FactorByCategoryOffer : Offer
    {
        public Category category { get; set; }
        public int factor { get; set; }

        public FactorByCategoryOffer(Category category, int factor)
        {
            this.category = category;
            this.factor = factor;
        }

        public override void Apply(Check check)
        {
            int points = check.getCostByCategory(this.category);
            check.AddPoints(points * (this.factor - 1));
        }
    }
}