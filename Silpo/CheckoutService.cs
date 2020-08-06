using System;
using System.Collections.Generic;

namespace Silpo {
    public class CheckoutService {
        private Check check;
        public void Open () {
            check = new Check ();
        }
    
        public void AddProduct (Product product) {
            if(check == null)
            {
                Open();
            }

            check.AddProduct(product);
        }

        public Check Close () {
            Check closedCheck = check;
            check = null;
            return closedCheck;
        }

        public void useOffer(AnyGoodsOffer offer)
        {
            

            if (offer is FactorByCategoryOffer)
            {
                FactorByCategoryOffer fbOffer = (FactorByCategoryOffer) offer;
                int points = check.getCostByCategory(fbOffer.category);
                check.AddPoints(points * (fbOffer.factor - 1));

            }
            else
            {
                if (check.GetTotalCost() > offer.totalCost)
                {
                    check.AddPoints(offer.points);
                }
            }
        }
    }
}