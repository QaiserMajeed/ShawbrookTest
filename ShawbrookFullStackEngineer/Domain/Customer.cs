namespace ShawbrookFullStackEngineer.Domain
{
    public class Customer
    {
        public int CustomerID { get; }
        public List<Membership> Memberships { get; set; }

        public Customer(int customerId)
        {
            CustomerID = customerId;
            Memberships = new List<Membership>();
        }

        public void ActivateMembership(Membership membership)
        {
            Memberships.Add(membership);
            Console.WriteLine($"MemberShip Added for the {CustomerID}{membership.MembershipType}");
            //return Memberships;
            
        }
    }
}
