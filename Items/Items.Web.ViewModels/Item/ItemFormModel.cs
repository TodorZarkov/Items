namespace Items.Web.ViewModels.Item
{
	using Items.Common.Enums;
	using Items.Web.Validators.Attributes;
	using Items.Web.ViewModels.Category;
	using Items.Web.ViewModels.Currency;
	using Items.Web.ViewModels.Place;
	using Items.Web.ViewModels.Unit;
	using static Items.Common.EntityValidationConstants.Item;
	using static Items.Common.EntityValidationErrorMessages.Item;

	using System.ComponentModel.DataAnnotations;
	public class ItemFormModel 
	{

		public AccessModifier Access { get; set; } = AccessModifier.Private;//todo: remove Access from Item 


		[Required]
		public ItemFormVisibilityModel ItemVisibility { get; set; } = null!;


		[Required]
		public int UnitId { get; set; }
		public IEnumerable<ForSelectUnitViewModel>? AvailableUnits { get; set; }


		[Required]
		public int PlaceId { get; set; }
		public IEnumerable<ForSelectPlaceViewModel>? AvailablePlaces { get; set; } //todo: filter available places over client(ajax) or go supDropdown


		//[Required]
		////todo: asynchronous validation with db with model binding
		//public Guid LocationId { get; set; }
		//public IEnumerable<ForSelectLocationViewModel> AvailableLocations { get; set; } = null!;


		public int? CurrencyId { get; set; }
		public IEnumerable<ForSelectCurrencyViewModel>? AvailableCurrencies { get; set; }


		[Required]
		public int[] CategoryIds { get; set; } = null!;
        public IEnumerable<CategoryFilterViewModel>? AvailableCategories { get; set; }



		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;



		[Required]
		[Range(QuantityMinValue, QuantityMaxValue)]
		public decimal Quantity { get; set; }



        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string? Description { get; set; }



		[Range(ValueMinValue, ValueMaxValue)]
		[RequiredIfPresent("CurrencyId", ErrorMessage = PriceCurrencyRequired)]
		public decimal? AcquiredPrice { get; set; }



		public DateTime? AcquiredDate { get; set; }



		//todo: manage client picture files
		[Required]
		[StringLength(UriMaxLength, MinimumLength = UriMinLength)]
		public string MainPictureUri { get; set; } = null!;



		[Range(ValueMinValue, ValueMaxValue)]
		public decimal? CurrentPrice { get; set; }


		[EqualCurrentDate(ErrorMessage = StartSellMustBeToday)]
		[DateBefore("EndSell", ErrorMessage = StartSellAfterEndSell)]
        public DateTime? StartSell { get; set; }



		[RequiredIfPresent("CurrentPrice", "CurrencyId", "IsAuction", ErrorMessage = StartSellPriceCurrencyRequired)]
		public DateTime? EndSell { get; set; }



		public bool IsAuction { get; set; }


        public bool OnRotation { get; set; }



		//public Document? AcquireDocument { get; set; }

		//public ICollection<Picture> Pictures { get; set; }


	}
}
