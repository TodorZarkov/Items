namespace Items.Web.ViewModels.Bid
{

	using System.ComponentModel.DataAnnotations;

	using Items.Web.ViewModels.Currency;
	using Items.Web.ViewModels.Item;
	using Items.Web.Validators.Attributes;
	using Items.Web.ViewModels.Location;
	using static Items.Common.EntityValidationConstants.Offer;
	using static Items.Common.EntityValidationErrorMessages.Offer;

	public class BidFormModel
	{
		[MaxLength(MessageMaxLength)]
		public string? Message { get; set; }





		[Required]
		[Range(QuantityMinValue, QuantityMaxValue)]
		//async check for available quantity
		public decimal Quantity { get; set; }





		[Required]
		//async check if is les than default expiration days + end auction date
		//async set to default expiration days + end auction date by default
		public DateTime Expires { get; set; }


		[Required]
		[Range(ValueMinValue, ValueMaxValue)]
		//async check cannot be les than highest bid or the start price
		public decimal Value { get; set; }


		[Required]
		//async check for available currencies
		// the currency must be same as the item currency for now
		public int CurrencyId { get; set; }

		public IEnumerable<ForSelectCurrencyViewModel>? AvailableCurrencies { get; set; }


		[RequiredIfPresent("BarterQuantity", ErrorMessage = BarterItemRequired)]
		//async check for barter availability: owner check, quantity, is for barter in another place ...
		public Guid? BarterItemId { get; set; }

		public IEnumerable<ItemForBarterViewModel>? BarterItem { get; set; }


		[RequiredIfPresent("BarterItemId", ErrorMessage = BarterQuantityRequired)]
		//async check for availability and if is as barter in another offer
		public decimal? BarterQuantity { get; set; }





		//async check location id
		public Guid? LocationId { get; set; }

		public IEnumerable<ForSelectLocationViewModel>? AvailableLocations { get; set; }
	}
}
