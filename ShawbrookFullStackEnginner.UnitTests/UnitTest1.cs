using Moq;
using Xunit;
using ShawbrookFullStackEngineer.Domain;
using ShawbrookFullStackEngineer.Services;
using ShawbrookFullStackEngineer.Models;
using System.Reflection;

namespace ShawbrookFullStackEnginner.UnitTests
{
    public class UnitTest1
    {
     

        [Fact]
        public void Create_WithPurchaseOrder_ShouldReturnCustomerMembershipType()
        {
            // Arrange
            var customer = new Customer(new Random().Next());
            var purchaseOrder = new PurchaseOrder(new Random().Next(), customer)
            {
                ItemLines =
                {
                    new Membership(MembershipType.BookClub,11,"Title"),
                }
            };

            // Act
            var processor = new Processor();
            var result = processor.Create(purchaseOrder);

            // Assert
            // Verify that the membership was activated for the customer
            if (result != null) Assert.Equal(result.Customer.Memberships.First().MembershipType, MembershipType.BookClub);
            

        }
    }
}