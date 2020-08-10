using System;
using Silpo.Rewards;

namespace Silpo
{
    public class AnyGoodsOffer : IReward
    {
        public int totalCost { get; set; }
        public int points { get; set; }

        public AnyGoodsOffer(int totalCost, int points, int countDay = 7)
        {
            this.totalCost = totalCost;
            this.points = points;
        }
        public int CalcPoints(Check check)
        {
            if (check.GetTotalCost() > this.totalCost)
            {
                return this.points;
            }

            return 0;
        }
    }
}