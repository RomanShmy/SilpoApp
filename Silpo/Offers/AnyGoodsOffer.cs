using System;
namespace Silpo
{
    public class AnyGoodsOffer : Offer
    {
        public int totalCost { get; set; }
        public int points { get; set; }

        public AnyGoodsOffer(int totalCost, int points, int countDay = 7) : base(DateTime.Now.AddDays(countDay))
        {
            this.totalCost = totalCost;
            this.points = points;
        }

        protected override void AddPoints(Check check)
        {
            if (check.GetTotalCost() > this.totalCost)
            {
                check.AddPoints(this.points);
            }
        }
    }
}