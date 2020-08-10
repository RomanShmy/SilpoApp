using System.Linq;
using System;
using Silpo.Rewards;

namespace Silpo.Offers
{
    public class TradeMarkAmountOffer : IReward
    {
        private TradeMark tradeMark; 
        private int amount;
        public TradeMarkAmountOffer(TradeMark tradeMark, int amount, int countDays = 7)
        {
            this.tradeMark = tradeMark;
            this.amount = amount;
        }

        public int CalcPoints(Check check)
        {
            var isPresent = check.products.Where(o => o.tradeMark.Equals(this.tradeMark)).First();
            if (isPresent != null)
            {
                return this.amount;
            }

            return 0;
        }
    }
}