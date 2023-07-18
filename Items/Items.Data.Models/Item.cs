namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Item;

    public class Item
    {
        public Item()
        {
            Id = Guid.NewGuid();
            ItemsCategories = new HashSet<ItemCategory>();
            Pictures = new HashSet<Picture>();
            Offers = new HashSet<Offer>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public decimal Quantity { get; set; }

        [Required]
        public Unit Unit { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public Price? AcquiredPrice { get; set; }

        public DateTime? AcquiredDate { get; set; }

        [MaxLength(DocumentUriMaxLength)]
        public string? AcquireDocumentUri { get; set; }


        public ICollection<ItemCategory> ItemsCategories { get; set; }


        [Required]
        [ForeignKey(nameof(Place))]
        public int PlaceId { get; set; }

        [Required]
        public Place Place { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Location))]
        public Guid LocationId { get; set; }

        [Required]
        public Location Location { get; set; } = null!;


        [ForeignKey(nameof(SellLocation))]
        public Guid? SellLocationId { get; set; }


        public Location? SellLocation { get; set; }


        public ICollection<Picture> Pictures { get; set; }


        public ICollection<Offer> Offers { get; set; }
    }
}
