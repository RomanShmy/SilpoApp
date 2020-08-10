using System;
using Xunit;
using Silpo;
using Silpo.Offers;
using Silpo.Rewards;
using Silpo.Discounts;
using Silpo.Condition;

namespace Silpo.Test
{
    public class CheckoutServiceTest
    {
        private CheckoutService checkoutService;
        private Product milk;
        private Product bread;
        private Product water;
        private Product cheese;
        private IReward AnyGoodsOffer;
        private IReward FactorByCategoryOffer;
        private IReward TradeMarkAmountOffer;
        private IReward TradeMarkFactorOffer;
        private IDiscountRule percent;
        private IDiscountRule gift;
        public CheckoutServiceTest()
        {
            checkoutService = new CheckoutService();
            checkoutService.Open();
            milk = new Product(7, "Milk", Category.MILK);
            bread = new Product(3, "Bread");
            water = new Product(5, "Woter", Category.Null, TradeMark.COCA_COLA);
            cheese = new Product(10, "Cheese");
            AnyGoodsOffer = new AnyGoodsOffer(6, 2);
            FactorByCategoryOffer = new FactorByCategoryOffer(Category.MILK, 2);
            TradeMarkFactorOffer = new TradeMarkFactorOffer(TradeMark.COCA_COLA, 2);
            TradeMarkAmountOffer = new TradeMarkAmountOffer(TradeMark.COCA_COLA, 2);
            percent = new Percent("Cheese");
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

            checkoutService.useOffer(new BonusOffer(AnyGoodsOffer));
            Check check = checkoutService.Close();
            Assert.Equal(12, check.GetTotalPoints());
        }

        [Fact]
        public void useOffer__whenCostLessThenRequiried__addOfferPoints()
        {
            checkoutService.AddProduct(bread);

            checkoutService.useOffer(new BonusOffer(AnyGoodsOffer));
            Check check = checkoutService.Close();
            Assert.Equal(3, check.GetTotalPoints());
        }

        [Fact]
        public void useOffer__factorByCategory()
        {
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);

            checkoutService.useOffer(new BonusOffer(FactorByCategoryOffer));
            Check check = checkoutService.Close();
            Assert.Equal(31, check.GetTotalPoints());
        }

        [Fact]
        public void useOffer__BeforeBuy__factorByCategory()
        {
            checkoutService.AddProduct(milk);
            checkoutService.useOffer(new BonusOffer(FactorByCategoryOffer));
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);

            Check check = checkoutService.Close();
            Assert.Equal(31, check.GetTotalPoints());
        }

        [Fact]
        public void useTwoOffer__BeforeBuy__factorByCategory()
        {
            checkoutService.AddProduct(milk);
            checkoutService.useOffer(new BonusOffer(FactorByCategoryOffer));
            checkoutService.AddProduct(milk);
            checkoutService.useOffer(new BonusOffer(AnyGoodsOffer));
            checkoutService.AddProduct(bread);

            Check check = checkoutService.Close();
            Assert.Equal(33, check.GetTotalPoints());
        }

        [Fact]
        public void checkExpirateOffer_useOfferIsExpirate()
        {
            checkoutService.AddProduct(milk);
            checkoutService.useOffer(new BonusOffer(FactorByCategoryOffer));
            checkoutService.AddProduct(milk);
            checkoutService.useOffer(new BonusOffer(AnyGoodsOffer, null, -1));
            checkoutService.AddProduct(bread);

            Check check = checkoutService.Close();
            Assert.Equal(31, check.GetTotalPoints());
        }

        [Fact]
        public void useTradeMarkOffer_Factor()
        {
            checkoutService.AddProduct(water);
            checkoutService.AddProduct(bread);
            checkoutService.useOffer(new BonusOffer(TradeMarkFactorOffer));
            Check check = checkoutService.Close();
            Assert.Equal(13, check.GetTotalPoints());
        }

        [Fact]
        public void useTradeMarkOffer_Amount()
        {
            checkoutService.AddProduct(water);
            checkoutService.AddProduct(bread);
            checkoutService.useOffer(new BonusOffer(TradeMarkAmountOffer));
            Check check = checkoutService.Close();
            Assert.Equal(10, check.GetTotalPoints());
        }

        [Fact]
        public void useBonusOffer__withOneProduct()
        {
            checkoutService.AddProduct(cheese);
            checkoutService.AddProduct(bread);
            checkoutService.useOffer(new DiscountOffer(percent));
            Check check = checkoutService.Close();
            Assert.Equal(8, check.GetTotalPoints());
        }

        [Fact]
        public void useAnyGoodsOffer__withTotalCostCondition()
        {
            checkoutService.AddProduct(cheese);
            ICondition condition = new TotalCost(6);
            checkoutService.useOffer(new BonusOffer(AnyGoodsOffer, condition));
            Check check = checkoutService.Close();
            Assert.Equal(12, check.GetTotalPoints());
        }

        [Fact]
        public void useFactorByCategoryOffer__withByCategoryCondition()
        {
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(milk);
            checkoutService.AddProduct(bread);
            ICondition condition = new ByCategory(Category.MILK);
            checkoutService.useOffer(new BonusOffer(FactorByCategoryOffer, condition));
            Check check = checkoutService.Close();
            Assert.Equal(31, check.GetTotalPoints());
        }
        
        
    }
}