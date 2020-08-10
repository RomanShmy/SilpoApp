using System;
using Silpo.Condition;

namespace Silpo
{
    public abstract class Offer
    {
        private DateTime expirationDate;
        private ICondition condition;
        public Offer(DateTime expirationDate) : this(null, expirationDate) { }

        public Offer(ICondition condition, DateTime expirationDate)
        {
            this.expirationDate = expirationDate;
            this.condition = condition;
        }
        public void Apply(Check check){
            if (!IsExpirate())
            {
                AddPoints(check);
            }
        }

        protected bool IsExpirate() => DateTime.Now.Date > expirationDate.Date;
        protected abstract void AddPoints(Check check);
    }
}