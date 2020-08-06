using System;
using System.Collections.Generic;

namespace Silpo {
    public class CheckoutService {
        private Check check;
        public void Open () {
            check = new Check ();
            check.products = new List<Product>();
        }
    
        public void AddProduct (Product product) {
            check.products.Add(product);
        }

        public Check Close () {
            foreach(var product in check.products)
            {
                check.totalCost += product.price;
            }
            return check;
        }
    }
}