using System.Linq;
using System;
using System.Collections.Generic;

namespace Silpo
{
    public class Check
    {

        private List<Product> products;
        private int points;

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
            
            return GetTotalCost() + points;
        }

        internal void AddPoints(int points)
        {
            this.points += points;
        }

        internal int getCostByCategory(Category category)
        {
            return products.Where(o => o.category.Equals(category)).Sum(o => o.price);
        }
    }
}