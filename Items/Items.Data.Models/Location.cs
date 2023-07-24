namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using NetTopologySuite.Geometries;

    using static Common.EntityValidationConstants.Location;

    public class Location
    {
        public Location()
        {
            Items = new HashSet<Item>();
            Places = new HashSet<Place>();
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }


        public bool IsPublic { get; set; }


        [Required]
        public Guid UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; } = null!;


        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }


        public Point? GeoLocation { get; set; }


        public Geometry? Border { get; set; }


        [Required]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;


        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;


        public ICollection<Place> Places { get; set; }


        public ICollection<Item> Items { get; set; }

    }
}
