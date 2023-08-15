namespace Items.Web.ViewModels.Item
{
	using Items.Web.ViewModels.Location;

	public class ItemViewModel
	{
		//default public
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public decimal? CurrentPrice { get; set; } //todo: delete it from ItemVisibilities table
		public string? CurrencySymbol { get; set; } = null!;
		public string? CurrencyIsoCode { get; set; } = null!;
		public DateTime? StartSell { get; set; }
		public DateTime? EndSell { get; set; }
		public string Categories { get; set; } = null!;
		public string MainPictureUri { get; set; } = null!;
		public bool? IsAuction { get; set; }
		public ItemFormVisibilityModel ItemVisibility { get; set; } = null!;



		//default private
		public int? PlaceId { get; set; }
		public string? PlaceName { get; set; } = null!;
		public Guid? LocationId { get; set; }
		public string? LocationName { get; set; } = null!;
		public int? AsBarterForOffersCount { get; set; }
		public int? ContractsCount { get; set; }
		public bool? OnRotation { get; set; }
		public bool? OnRotationNow { get; set; }


		//conditional
		public string? OwnerName { get; set; }
        public string? OwnerEmail { get; set; }
        public string? OwnerPhone { get; set; }
		public decimal? Quantity { get; set; }
		public string? UnitSymbol { get; set; } = null!;
		public string? UnitName { get; set; } = null!;
		public string? Description { get; set; }
		public DateTime? AddedOn { get; set; }
		public DateTime? ModifiedOn { get; set; }//todo: add it to ItemVisibilities table
		public decimal? AcquiredPrice { get; set; }
		public DateTime? AcquiredDate { get; set; }

		//public Document? AcquireDocument { get; set; }

		//public ICollection<Picture>? Pictures { get; set; }//todo: add it to ItemVisibilities table
		public int? OffersCount { get; set; } //todo: fix it in according to visibility on AllItems
        public AllLocationViewModel? Location { get; set; }

    }
}
