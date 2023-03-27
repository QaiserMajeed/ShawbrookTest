using ShawbrookFullStackEngineer.Domain;
using ShawbrookFullStackEngineer.Models;
using Product = ShawbrookFullStackEngineer.Domain.Product;

namespace ShawbrookFullStackEngineer.Services
{
    public interface IPurchaseOrderProcessor
    {
        void ProcessPurchaseOrder(PurchaseOrder purchaseOrder, Customer customer);
    }

    public class PurchaseOrderHandler : IPurchaseOrderProcessor
    {
        private readonly List<IPurchaseOrderProcessor> _handlers;

        public PurchaseOrderHandler()
        {
            _handlers = new List<IPurchaseOrderProcessor>();
        }

        public void AddHandler(IPurchaseOrderProcessor handler)
        {
            _handlers.Add(handler);
        }

        public void ProcessPurchaseOrder(PurchaseOrder purchaseOrder, Customer customer)
        {
          

            foreach (var handler in _handlers)
            {
               handler.ProcessPurchaseOrder(purchaseOrder, customer);
            }
          
        }
    }


    public class MembershipActivationHandler : IPurchaseOrderProcessor
    {
        public void ProcessPurchaseOrder(PurchaseOrder purchaseOrder, Customer customer)
        {

            foreach (var itemLine in purchaseOrder.ItemLines)
            {
                if (itemLine is Membership membership)
                {
                    customer.ActivateMembership(membership);
                    purchaseOrder.Customer.Memberships.Add(membership);
                   
                }
            }

        }
    }


    public class ShippingSlipHandler : IPurchaseOrderProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public void ProcessPurchaseOrder(PurchaseOrder purchaseOrder, Customer customer)
        {
            foreach (var itemLine in purchaseOrder.ItemLines)
            {
                if (itemLine is Product product)
                {
                    GenerateShippingSlip(product);
                }
            }
        }

        private void GenerateShippingSlip(IPurchasableItem product)
        {
            Console.WriteLine($"Shipping slip generated for product: {product.Title}");
        }
    }

    public class Processor
    {
        public PurchaseOrder Create(PurchaseOrder purchaseOrder)
        {
            // create the handlers
            var membershipActivationHandler = new MembershipActivationHandler();
            ShippingSlipHandler shippingSlipHandler = new();
            var customer = new Customer(new Random().Next());
            // create the purchase order processor
            PurchaseOrderHandler purchaseOrderProcessor = new();
            purchaseOrderProcessor.AddHandler(membershipActivationHandler);
            purchaseOrderProcessor.AddHandler(shippingSlipHandler);

            // process the purchase order
            purchaseOrderProcessor.ProcessPurchaseOrder(purchaseOrder, customer);
            return purchaseOrder;
        }
    }
}
