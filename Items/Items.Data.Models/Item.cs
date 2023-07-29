namespace Items.Data.Models
{
	using Items.Common.Enums;
	using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Item;

    public class Item
    {
        public Item()
        {
            Id = Guid.NewGuid();
            AddedOn = DateTime.UtcNow;
            ItemsCategories = new HashSet<ItemCategory>();
            Pictures = new HashSet<Picture>();
            Offers = new HashSet<Offer>();
            AsBarterForOffers = new HashSet<Offer>();
			Access = AccessModifier.Private;
		}

        [Key]
        public Guid Id { get; set; }


        [Required]
        public AccessModifier Access { get; set; }


        [ForeignKey(nameof(ItemVisibility))]
        public Guid ItemVisibilityId { get; set; }

        [Required]
        public ItemVisibility ItemVisibility { get; set; } = null!;


        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;





        [Precision(QuantityPrecision, QuantityScale)]
        public decimal Quantity { get; set; }




        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }

        [Required]
        public Unit Unit { get; set; } = null!;




        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }





        [Precision(ValuePrecision, ValueScale)]
        public decimal? AcquiredPrice { get; set; }
        
        [Precision(ValuePrecision, ValueScale)]
        public decimal? CurrentPrice { get; set; }

        




        [ForeignKey(nameof(Currency))]
        public int? CurrencyId { get; set; }

        public Currency? Currency { get; set; }





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




        public DateTime AddedOn { get; set; }


        public DateTime? StartSell { get; set; }


        public DateTime? EndSell { get; set; }


        [Required]
        [ForeignKey(nameof(MainPicture))]
        public Guid MainPictureId { get; set; }

        public Picture MainPicture { get; set; } = null!;


        public ICollection<Picture> Pictures { get; set; }




        public ICollection<Offer> Offers { get; set; }


        public ICollection<Offer> AsBarterForOffers { get; set; }
    }
}
