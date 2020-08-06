namespace Silpo
{
    public class Product
    {
        public int price { get; }
        public Category category { get; }

        private string name;

        public Product(int price, string name) : this(price, name, Category.Null) { }

        public Product(int price, string name, Category category)
        {
            this.price = price;
            this.name = name;
            this.category = category;
        }
    }
}