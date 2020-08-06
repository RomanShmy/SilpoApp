using System;
using Xunit;
using Silpo;

namespace Silpo.Test
{
    public class CheckoutServiceTest
    {
        [Fact]
        public void closeCheck__withOneProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.Open();
            checkoutService.AddProduct(new Product(7, "Milk"));
            Check check = checkoutService.Close();

            Assert.Equal(7, check.GetTotalCost());

        }

        [Fact]
        public void closeCheck__withTwoProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.Open();
            checkoutService.AddProduct(new Product(7, "Milk"));
            checkoutService.AddProduct(new Product(3, "Bread"));
            Check check = checkoutService.Close();

            Assert.Equal(10, check.GetTotalCost());

        }
        
    }
}