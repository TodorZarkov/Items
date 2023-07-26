namespace Items.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() 
        {
            Items = new HashSet<Item>();
            Categories = new HashSet<Category>();
            Locations = new HashSet<Location>();
            Offers = new HashSet<Offer>();
            Accounts = new HashSet<Account>();
        }
        public ICollection<Item> Items { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Location> Locations { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
