namespace Items.Web.ViewModels.Item
{
	using Items.Common.Enums;
	using static Items.Common.EntityValidationConstants.Item;

	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;
	using Microsoft.AspNetCore.Mvc;
	using Items.Web.ModelBinder;
	using Items.Web.ViewModels.Category;
	using Items.Web.ViewModels.Unit;
	using Items.Web.ViewModels.Place;
	using Items.Web.ViewModels.Location;
	using Items.Web.ViewModels.Currency;

	public class ItemFormModel
	{

		public AccessModifier Access { get; set; } = AccessModifier.Private;//todo: remove Access from Item 


		[Required]
		public ItemFormVisibilityModel ItemVisibility { get; set; } = null!;


		[Required]
		[ModelBinder(binderType: typeof(UnitIdModelBinder))]
		public int UnitId { get; set; }
		public IEnumerable<ForSelectUnitViewModel> AvailableUnits { get; set; } = null!;


		[Required]
		//todo: asynchronous validation with db with model binding
		public int PlaceId { get; set; }
		public IEnumerable<ForSelectPlaceViewModel> AvailablePlaces { get; set; } = null!;//todo: filter available places over client(ajax) or go supDropdown


		//[Required]
		////todo: asynchronous validation with db with model binding
		//public Guid LocationId { get; set; }
		//public IEnumerable<ForSelectLocationViewModel> AvailableLocations { get; set; } = null!;


		//todo: asynchronous validation with db
		//todo: validate if any price is set to be required
		public int? CurrencyId { get; set; }
		public IEnumerable<ForSelectCurrencyViewModel> AvailableCurrencies { get; set; } = null!;


		[Required]
		//todo: asynchronous validation with db With model binder
		public int[] CategoryIds { get; set; } = null!;
        public IEnumerable<CategoryFilterViewModel> AvailableCategories { get; set; } = null!;



		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;



		[Required]
		[Range(QuantityMinValue, QuantityMaxValue)]
		public decimal Quantity { get; set; }



        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string? Description { get; set; }



		[Range(ValueMinValue, ValueMaxValue)]
		public decimal? AcquiredPrice { get; set; }



		//todo: my dateTime? valid attribute also may check is it after now
		public DateTime? AcquiredDate { get; set; }



		//todo: manage client picture files
		[Required]
		[StringLength(UriMaxLength, MinimumLength = UriMinLength)]
		public string MainPictureUri { get; set; } = null!;



		[Range(ValueMinValue, ValueMaxValue)]
		public decimal? CurrentPrice { get; set; }



        //todo: my dateTime? valid attribute also may check is it after now
        public DateTime? StartSell { get; set; }



		//todo: my dateTime? valid attribute also may check is it after StartSell, gets Required after StartDate is present
		public DateTime? EndSell { get; set; }



		//todo: gets Required after StartSell is present
		public bool IsAuction { get; set; }


        public bool OnRotation { get; set; }



		//public Document? AcquireDocument { get; set; }
		 
		//public ICollection<Picture> Pictures { get; set; }

	}
}
