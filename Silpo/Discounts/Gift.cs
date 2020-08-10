namespace Silpo.Discounts
{
    public class Gift : IDiscountRule
    {
        private Product product;
        public Gift(Product product)
        {
            this.product = product;
        }

        public Discount CalcDiscount(Check check)
        {
            check.AddProduct(new Product(1, product.name));
            return null;
        }
    }
}