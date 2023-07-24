namespace Items.Data.Models
{
    using Microsoft.EntityFrameworkCore;
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


        [Precision(QuantityPrecision, QuantityScale)]
        public decimal Quantity { get; set; }


        [Required]
        public Unit Unit { get; set; } = null!;


        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }


        [ForeignKey(nameof(AcquiredPrice))]
        public int? PriceId { get; set; }
        public Price? AcquiredPrice { get; set; }


        public DateTime? AcquiredDate { get; set; }


        [ForeignKey(nameof(AcquireDocument))]
        public Guid? DocumentId { get; set; }
        public Document? AcquireDocument { get; set; }


        [Required]
        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

        [Required]
        public ApplicationUser Owner { get; set; } = null!;

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



        public ICollection<Picture> Pictures { get; set; }


        public ICollection<Offer> Offers { get; set; }
    }
}
