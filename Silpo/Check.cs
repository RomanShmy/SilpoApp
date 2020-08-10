using System.Linq;
using System;
using System.Collections.Generic;
using Silpo.Discounts;

namespace Silpo
{
    public class Check
    {

        public List<Product> products { get; set; } = new List<Product>();
        private int points;
        private int discount;
        public int GetTotalCost() => products.Sum(product => product.price) - discount;

        internal void AddProduct(Product product)
        {
            products.Add(product);
        }

        internal void AddDiscount(int discount)
        {
            this.discount += discount;
        }
        
        public int GetTotalPoints() => GetTotalCost() + points;
        

        internal void AddPoints(int points)
        {
            this.points += points;
        }

        internal List<Product> GetProductsByName(string productName) => products.Where(product => product.name.Equals(productName)).ToList();

        internal int getCostByCategory(Category category) => products.Where(o => o.category.Equals(category)).Sum(o => o.price);
        
        internal int getCostByTradeMark(TradeMark tradeMark) => products.Where(o => o.tradeMark.Equals(tradeMark)).Sum(o => o.price);
    
    }
}