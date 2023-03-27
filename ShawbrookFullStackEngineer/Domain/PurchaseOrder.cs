namespace ShawbrookFullStackEngineer.Domain
{
    public class PurchaseOrder
    {
        public int POID { get; set; }
        public Customer Customer { get; }
        public IList<IPurchasableItem> ItemLines { get; }
        public decimal TotalPrice { get; private set; }

        public PurchaseOrder(int poId, Customer customer)
        {
            POID = poId;
            Customer = customer;
            ItemLines = new List<IPurchasableItem>();
            TotalPrice = 0;
        }

        public void AddItemLine(IPurchasableItem itemLine)
        {
            ItemLines.Add(itemLine);
            if (itemLine is not Product product)
            {
                if (itemLine is Membership membership)
                {
                    TotalPrice += membership.Price;
                }
            }
            else
            {
                TotalPrice += product.Price;
            }
        }
    }
}
