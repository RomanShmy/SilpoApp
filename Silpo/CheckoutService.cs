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
            foreach(var offer in closedCheck.getOffers())
            {
                offer.Apply(closedCheck);
            }
            check = null;
            return closedCheck; 
        }

        public void useOffer(Offer offer)
        {
            check.AddOffer(offer);
        }
    }
}