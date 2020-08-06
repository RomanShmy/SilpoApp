using System;
using System.Collections.Generic;

namespace Silpo
{
    public class Check
    {

        private List<Product> products;

        public Check() 
        {
            
            products = new List<Product>();
        }
        public int GetTotalCost()
        {
            int totalCost = 0;
            foreach(var product in this.products)
            {
                totalCost += product.price;
            }
            return totalCost;
        }

        internal void AddProduct(Product product)
        {
            products.Add(product);
        }

        public int GetTotalPoints()
        {
            return GetTotalCost();
        }
    }
}