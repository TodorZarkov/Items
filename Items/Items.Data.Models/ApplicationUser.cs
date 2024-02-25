namespace Items.Data.Models
{
    using static Common.EntityValidationConstants.User;

    using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;
	using Microsoft.EntityFrameworkCore;
	using System.ComponentModel.DataAnnotations.Schema;

	[Index(nameof(Email),IsUnique = true)]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Items = new HashSet<Item>();

            Categories = new HashSet<Category>();

            Locations = new HashSet<Location>();

            Offers = new HashSet<Offer>();

            ContractsAsBuyer = new HashSet<Contract>();
            ContractsAsSeller = new HashSet<Contract>();
        }

        
        [MaxLength(UserEmailMaxLength)]
        override public string Email { get; set; } = null!;

        public Guid? ProfilePictureId { get; set; }

        public DateTime RotationItemsDate { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Location> Locations { get; set; }

        public ICollection<Offer> Offers { get; set; }


        public ICollection<Contract> ContractsAsBuyer { get; set; }
        public ICollection<Contract> ContractsAsSeller { get; set; }

    }
}
