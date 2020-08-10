using System;
using Silpo.Discounts;

namespace Silpo.Offers
{
    public class DiscountOffer : Offer
    {
        private IDiscountRule discountRule;

        public DiscountOffer(IDiscountRule discountRule, int countDays = 7) : base(DateTime.Now.AddDays(countDays))
        {
            this.discountRule = discountRule;
        }
        protected override void AddPoints(Check check)
        {
            check.AddDiscount(discountRule.CalcDiscount(check).Amount);   
        }
    }
}