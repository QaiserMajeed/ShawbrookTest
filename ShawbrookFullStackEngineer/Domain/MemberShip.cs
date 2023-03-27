namespace ShawbrookFullStackEngineer.Domain
{
    public class Membership : IPurchasableItem
    {
        public MembershipType MembershipType { get; }


        public Membership(MembershipType membershipType, decimal price,string title)
        {
            MembershipType = membershipType;
            Price = price;
            Title = title;
        }

        public string Title { get; set; }
        public decimal Price { get; set; }
    }


    public enum MembershipType
    {
        BookClub,
        VideoClub,
        Premium
    }



}
