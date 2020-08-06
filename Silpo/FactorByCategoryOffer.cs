namespace Silpo
{
    public class FactorByCategoryOffer : AnyGoodsOffer
    {
        public Category category { get; set; }
        public int factor { get; set; }

        public FactorByCategoryOffer(Category category, int factor) : base(0,0)
        {
            this.category = category;
            this.factor = factor;
        }
    }
}