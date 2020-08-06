using System;
using System.Collections.Generic;

namespace Silpo {
    public class CheckoutService {
        private Check check;
        public void Open () {
            check = new Check ();
        }
    
        public void AddProduct (Product product) {
            check.AddProduct(product);
        }

        public Check Close () {
            return check;
        }
    }
}