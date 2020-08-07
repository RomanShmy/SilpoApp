using System;
using System.Collections.Generic;

namespace Silpo {
    public class CheckoutService {
        private Check check;
        private List<Offer> offers;
        public void Open () {
            check = new Check ();
            offers = new List<Offer>();
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
            foreach(var offer in offers)
            {
                offer.Apply(closedCheck);
            }
            check = null;
            return closedCheck; 
        }

        public void useOffer(Offer offer)
        {
            offers.Add(offer);
        }
    }
}