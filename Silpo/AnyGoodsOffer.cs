namespace Silpo
{
    public class AnyGoodsOffer
    {
        public int totalCost { get; set; }
        public int points { get; set; }

        public AnyGoodsOffer(int totalCost, int points)
        {
            this.totalCost = totalCost;
            this.points = points;
        }
    }
}