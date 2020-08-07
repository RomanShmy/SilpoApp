using System;
namespace Silpo.Offers
{
    public class TradeMarkFactorOffer : Offer
    {
        private TradeMark tradeMark;
        private int factor;

        public TradeMarkFactorOffer(TradeMark tradeMark, int factor, int countDays = 7) : base(DateTime.Now.AddDays(countDays))
        {
            this.tradeMark = tradeMark;
            this.factor = factor;
        }
        protected override void AddPoints(Check check)
        {
            int points = check.getCostByTradeMark(this.tradeMark);
            check.AddPoints(points * (this.factor - 1));
        }
    }
}