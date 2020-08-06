using System;
using Xunit;
using Silpo;

namespace Silpo.Test
{
    public class CheckoutServiceTest
    {
        private CheckoutService checkoutService;
        private Product milk;
        private Product bread;
        public CheckoutServiceTest()
        {
            checkoutService = new CheckoutService();
            checkoutService.Open();
            milk = new Product(7, "Milk", Category.MILK);
            bread = new Product(3, "Bread");
        }

        [Fact]
        public void closeCheck__withOneProduct()
        {
            checkoutService.AddProduct(milk);
            Check check = checkoutService.Close();

            Assert.Equal(7, check.GetTotalCost());

        }

        [Fact]
        public void closeCheck__withTwoProduct()
        {
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            Check check = checkoutService.Close();
            Assert.Equal(10, check.GetTotalCost());
        }

        [Fact]
        public void addProducts__whenCheckIsClosed__openNewCheck()
        {   
            checkoutService.AddProduct(milk);
            Check milkCheck = checkoutService.Close();
            Assert.Equal(7, milkCheck.GetTotalCost());

            checkoutService.AddProduct(bread);
            Check bredCheck = checkoutService.Close();
            Assert.Equal(3, bredCheck.GetTotalCost());
        }

        [Fact]
        public void closeCheck__calcTotalPoints()
        {
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            Check check = checkoutService.Close();
            Assert.Equal(10, check.GetTotalPoints());
        }

        [Fact]
        public void useOffer__addOfferPoints()
        {
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);

            checkoutService.useOffer(new AnyGoodsOffer(6, 2));
            Check check = checkoutService.Close();
            Assert.Equal(12, check.GetTotalPoints());
        }

        [Fact]
        public void useOffer__whenCostLessThenRequiried__addOfferPoints()
        {
            checkoutService.AddProduct(bread);

            checkoutService.useOffer(new AnyGoodsOffer(6, 2));
            Check check = checkoutService.Close();
            Assert.Equal(3, check.GetTotalPoints());
        }

        [Fact]
        public void useOffer__factorByCategory()
        {
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);

            checkoutService.useOffer(new FactorByCategoryOffer(Category.MILK, 2));
            Check check = checkoutService.Close();
            Assert.Equal(31, check.GetTotalPoints());
        }

         [Fact]
        public void useOffer__BeforeBuy__factorByCategory()
        {
            checkoutService.AddProduct(milk);
            checkoutService.useOffer(new FactorByCategoryOffer(Category.MILK, 2));
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);

            Check check = checkoutService.Close();
            Assert.Equal(31, check.GetTotalPoints());
        }

        
    }
}