using System;
using Silpo.Rewards;

namespace Silpo.Offers
{
    public class BonusOffer : Offer
    {
        private IReward reward;

        public BonusOffer(IReward reward, int countDays = 7) : base(DateTime.Now.AddDays(countDays))
        {
            this.reward = reward;
        }
        protected override void AddPoints(Check check)
        {
            check.AddPoints(reward.CalcPoints(check));
        }
    }
}