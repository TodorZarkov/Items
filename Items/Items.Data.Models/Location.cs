namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;
    using static Common.EntityValidationConstants.Location;

    public class Location
    {
        public Location()
        {
            Places = new HashSet<Place>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;


        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DbGeography? GeoLocation { get; set; }


        [Required]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;


        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        public bool IsVisible { get; set; }

        public ICollection<Place> Places { get; set; }

    }
}
