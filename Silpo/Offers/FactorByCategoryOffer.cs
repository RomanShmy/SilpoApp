using System;
using Silpo.Rewards;

namespace Silpo
{
    public class FactorByCategoryOffer : IReward
    {
        public Category category { get; set; }
        public int factor { get; set; }

        public FactorByCategoryOffer(Category category, int factor, int countDay = 7)
        {
            this.category = category;
            this.factor = factor;
        }

        public int CalcPoints(Check check)
        {
            int points = check.getCostByCategory(this.category);
            return points * (this.factor - 1);
        }
    }
}