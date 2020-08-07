using System.Linq;
using System;
namespace Silpo.Offers
{
    public class TradeMarkAmountOffer : Offer
    {
        private TradeMark tradeMark; 
        private int amount;
        public TradeMarkAmountOffer(TradeMark tradeMark, int amount, int countDays = 7) : base(DateTime.Now.AddDays(countDays))
        {
            this.tradeMark = tradeMark;
            this.amount = amount;
        }
        protected override void AddPoints(Check check)
        {
            var isPresent = check.products.Where(o => o.tradeMark.Equals(this.tradeMark)).First();
            if (isPresent != null)
            {
                check.AddPoints(this.amount);
            }
            
        }
    }
}