using ShawbrookFullStackEngineer.Domain;
using System.ComponentModel.DataAnnotations;

namespace ShawbrookFullStackEngineer.Models
{
    public class PurchaseOrderModel
    {
        [Required]
        public int CustomerId { get; set; }
        public List<ItemLineModel> ItemLines { get; set; }
    }

    public class ItemLineModel
    {
        /// <summary>
        /// The type of the item. Can be either "Membership" or "Product".
        /// </summary>
        [Required(ErrorMessage = "Item type is required.")]
        [ItemTypeValidation(ErrorMessage = "Invalid item type.")]
        public string ItemType { get; set; }
        /// <summary>
        /// The title of the item.
        /// </summary>
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        /// <summary>
        /// The price of the item.
        /// </summary>
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
    }
    public class ItemTypeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var itemLineModel = (ItemLineModel)validationContext.ObjectInstance;
            return itemLineModel.ItemType is "Membership" or "Product" ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }

    public class PurchaseOrderBinder
    {
        private readonly PurchaseOrderModel _purchaseOrderModel;

        public PurchaseOrderBinder(PurchaseOrderModel purchaseOrderModel)
        {
            _purchaseOrderModel = purchaseOrderModel;
        }

        public PurchaseOrder Bind()
        {
           
            PurchaseOrder purchaseOrder = new(new Random().Next(), new Customer(new Random().Next()));
            foreach (var itemLineModel in _purchaseOrderModel.ItemLines)
            {
                if (string.Equals(itemLineModel.ItemType, "Membership")  )
                {
                    purchaseOrder.AddItemLine(itemLineModel.Title.Contains($"Video")
                        ? new Membership(MembershipType.VideoClub, itemLineModel.Price, itemLineModel.Title)
                        : new Membership(MembershipType.BookClub, itemLineModel.Price, itemLineModel.Title));
                }
                else if (string.Equals(itemLineModel.ItemType, "Product"))
                {
                    purchaseOrder.AddItemLine(new Product(itemLineModel.Title, ProductType.Video, itemLineModel.Price));
                }
            }
            return purchaseOrder;
        }
    }


}
