namespace Items.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() 
        {
            Items = new HashSet<Item>();
            OwnCategories = new HashSet<Category>();
            Locations = new HashSet<Location>();
        }
        public ICollection<Item> Items { get; set; }

        public ICollection<Category> OwnCategories { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
