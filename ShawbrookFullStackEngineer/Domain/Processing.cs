namespace ShawbrookFullStackEngineer.Domain
{
    public interface IProcessingStrategy
    {
        void Process(Product product);
    }
    public class DefaultShippingStrategy : IProcessingStrategy
    {
        public void Process(Product product)
        {
            Console.WriteLine($"Generated shipping slip for product '{product.Title}'");
        }
    }
    public class DigitalProductStrategy : IProcessingStrategy
    {
        public void Process(Product product)
        {
            Console.WriteLine($"Subscribe to product '{product.Title}'");
        }
    }
}
