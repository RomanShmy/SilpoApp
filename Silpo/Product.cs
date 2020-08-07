namespace Silpo
{
    public class Product
    {
        public int price { get; }
        public Category category { get; }

        public TradeMark tradeMark { get; }

        private string name;


        public Product(int price, string name) : this(price, name, Category.Null) { }

        public Product(int price, string name, Category category) : this(price, name, category, TradeMark.Null){}
        

         public Product(int price, string name, Category category, TradeMark tradeMark)
        {
            this.price = price;
            this.name = name;
            this.category = category;
            this.tradeMark = tradeMark;
        }
    }
}