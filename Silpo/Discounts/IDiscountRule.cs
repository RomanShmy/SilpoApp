namespace Silpo.Discounts
{
    public interface IDiscountRule
    {
        Discount CalcDiscount(Check check);
    }
}