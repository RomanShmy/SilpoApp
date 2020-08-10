using System.Linq;

namespace Silpo.Discounts
{
    public class Percent : IDiscountRule
    {
        public string productName;

        public Percent(string productName)
        {
            this.productName = productName;
        }
        public Discount CalcDiscount(Check check)
        {
            var products = check.GetProductsByName(productName);
            if (products == null)
            {
                return new Discount(0);
            }

            int discount = products.Sum(product => product.price) / 2;
            return new Discount(discount);
        }
    }
}