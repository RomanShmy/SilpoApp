using System;
using Silpo.Condition;
using Silpo.Rewards;

namespace Silpo.Offers
{
    public class BonusOffer : Offer
    {
        private IReward reward;

        public BonusOffer(IReward reward, ICondition condition = null, int countDays = 7) : base(condition, DateTime.Now.AddDays(countDays))
        {
            this.reward = reward;
        }
        protected override void AddPoints(Check check)
        {
            check.AddPoints(reward.CalcPoints(check));
        }
    }
}