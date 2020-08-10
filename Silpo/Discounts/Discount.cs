namespace Silpo.Discounts
{
    public class Discount
    {
        public int Amount { get; protected set; }

        public Discount(int amount)
        {
            this.Amount = amount;
        }
    }
}