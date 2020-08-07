using System;
namespace Silpo
{
    public class FactorByCategoryOffer : Offer
    {
        public Category category { get; set; }
        public int factor { get; set; }

        public FactorByCategoryOffer(Category category, int factor, int countDay = 7) : base(DateTime.Now.AddDays(countDay))
        {
            this.category = category;
            this.factor = factor;
        }

        protected override void AddPoints(Check check)
        {
            int points = check.getCostByCategory(this.category);
            check.AddPoints(points * (this.factor - 1));
        }
    }
}