namespace ShawbrookFullStackEngineer.Domain
{
    public class Product : IPurchasableItem
    {
        public string Title { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Price { get; set;  }

        public Product(string title, ProductType productType, decimal price)
        {
            Title = title;
            ProductType = productType;
            Price = price;
        }
    }
    public enum ProductType
    {
        Book,
        Video
    }
    public class ItemLine
    {
        public IPurchasableItem Item { get; set; }

        public ItemLine(IPurchasableItem item)
        {
            Item = item;
        }
    }

    public interface IPurchasableItem
    {
        public string Title { get; set; }
        decimal Price { get; set; }
    }
}
