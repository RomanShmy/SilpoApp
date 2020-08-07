using System;
namespace Silpo
{
    public abstract class Offer
    {
        private DateTime expirationDate;
        public Offer(DateTime expirationDate)
        {
            this.expirationDate = expirationDate;
        }


        public void Apply(Check check){
            bool Expirate = IsExpirate();
            if (!Expirate)
            {
                AddPoints(check);
            }
        }

        protected bool IsExpirate()
        {
            return DateTime.Now.Date > expirationDate.Date;
        }

        protected abstract void AddPoints(Check check);


    }
}