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
            AddedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
            ItemsCategories = new HashSet<ItemCategory>();
            ItemPictures = new HashSet<FileIdentifier>();
            Offers = new HashSet<Offer>();
            AsBarterForOffers = new HashSet<Offer>();
            Contracts = new HashSet<Contract>();
		}

        [Key]
        public Guid Id { get; set; }


		[Required]
		[ForeignKey(nameof(Owner))]
		public Guid OwnerId { get; set; }

		[Required]
		public ApplicationUser Owner { get; set; } = null!;




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

        public DateTime AddedOn { get; set; }

        public DateTime ModifiedOn { get; set; }


        [Precision(ValuePrecision, ValueScale)]
        public decimal? AcquiredPrice { get; set; }


		public DateTime? AcquiredDate { get; set; }


		[ForeignKey(nameof(AcquireDocument))]
		public Guid? DocumentId { get; set; }
		public Document? AcquireDocument { get; set; }



		public ICollection<ItemCategory> ItemsCategories { get; set; }



		[Required]
		[ForeignKey(nameof(Place))]
		public int PlaceId { get; set; }

		[Required]
		public Place Place { get; set; } = null!;


		[Required]
		[ForeignKey(nameof(Location))]
		public Guid LocationId { get; set; }// TODO: remove location as place has only one location

		[Required]
		public Location Location { get; set; } = null!;



        public ICollection<FileIdentifier> ItemPictures { get; set; }

        [MaxLength(UriMaxLength)]
        //todo(fc): change to guid and name to MainPictureId / remove MainPictureUri
        public string? MainPictureUri { get; set; }

        public Guid MainPictureId { get; set; }


        [Precision(ValuePrecision, ValueScale)]
        public decimal? CurrentPrice { get; set; }
        

        [ForeignKey(nameof(Currency))]
        public int? CurrencyId { get; set; }

        public Currency? Currency { get; set; }



        public DateTime? StartSell { get; set; }


        public DateTime? EndSell { get; set; }


        public bool? IsAuction { get; set; }

        [Precision(PromisedQuantityPrecision, PromisedQuantityScale)]
        public decimal PromisedQuantity { get; set; }


        public ICollection<Offer> Offers { get; set; }


        public ICollection<Offer> AsBarterForOffers { get; set; }



		public ICollection<Contract> Contracts { get; set; }



        public bool OnRotation { get; set; }
        public bool OnRotationNow { get; set; }


        public bool Deleted { get; set; }
    }
}
