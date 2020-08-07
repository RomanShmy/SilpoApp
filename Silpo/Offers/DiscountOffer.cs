using System;
namespace Silpo.Offers
{
    public class DiscountOffer : Offer
    {
        private int percent;

        public DiscountOffer(int percent, int countDays = 7) : base(DateTime.Now.AddDays(countDays))
        {
            this.percent = percent;
        }
        protected override void AddPoints(Check check)
        {
            int totalCost = check.GetTotalCost();
            int costWithDiscount = totalCost - totalCost * percent / 100;

            check.AddPoints(-costWithDiscount);
            
        }
    }
}