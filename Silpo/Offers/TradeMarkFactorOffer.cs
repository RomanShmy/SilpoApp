using System;
using Silpo.Rewards;

namespace Silpo.Offers
{
    public class TradeMarkFactorOffer : IReward
    {
        private TradeMark tradeMark;
        private int factor;

        public TradeMarkFactorOffer(TradeMark tradeMark, int factor, int countDays = 7)
        {
            this.tradeMark = tradeMark;
            this.factor = factor;
        }

        public int CalcPoints(Check check)
        {
            int points = check.getCostByTradeMark(this.tradeMark);
            return points * (this.factor - 1);
        }
    }
}