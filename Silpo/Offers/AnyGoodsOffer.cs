namespace Silpo
{
    public class AnyGoodsOffer : Offer
    {
        public int totalCost { get; set; }
        public int points { get; set; }

        public AnyGoodsOffer(int totalCost, int points)
        {
            this.totalCost = totalCost;
            this.points = points;
        }

        public override void Apply(Check check)
        {
            if (check.GetTotalCost() > this.totalCost)
            {
                check.AddPoints(this.points);
            }
        }
    }
}