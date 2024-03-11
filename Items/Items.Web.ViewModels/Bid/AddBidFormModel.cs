namespace Items.Web.ViewModels.Bid
{

	using System.ComponentModel.DataAnnotations;

	using Items.Web.ViewModels.Currency;
	using Items.Web.ViewModels.Item;
	using Items.Web.Validators.Attributes;
	using Items.Web.ViewModels.Location;
	using static Items.Common.EntityValidationConstants.Offer;
	using static Items.Common.EntityValidationErrorMessages.Offer;

	public class AddBidFormModel
	{
        public Guid ItemPictureId { get; set; }


        [StringLength(MessageMaxLength, MinimumLength = MessageMinLength)]
		public string? Message { get; set; }





		[Required]
		[Range(QuantityMinValue, QuantityMaxValue)]
		//async check for available quantity
		public decimal Quantity { get; set; }




		[Required]
		//async check if is les than default expiration days + end auction date
		public DateTime Expires { get; set; }


		[Display(Name = "Bid Value")]
		[RequiredIfNotPresent("BarterItemId", "BarterQuantity", ErrorMessage = BidValueRequired)]
		[Range(ValueMinValue, ValueMaxValue)]
		//async check cannot be les than highest bid or the start price
		public decimal? Value { get; set; }


		[Display(Name = "Currency")]
		[Required]
		//async check for available currencies
		//async check the currency must be same as the item currency for now
		public int CurrencyId { get; set; }

		public IEnumerable<ForSelectCurrencyViewModel>? AvailableCurrencies { get; set; }


		[Display(Name = "Barter Item")]
		[RequiredIfPresent("BarterQuantity", ErrorMessage = BarterItemRequired)]
		//async check for barter availability: owner check, quantity, is for barter in another place ...
		public Guid? BarterItemId { get; set; }

		public IEnumerable<ItemForBarterViewModel>? AvailableBarters { get; set; }


		[Display(Name = "Barter Quantity")]
		[RequiredIfPresent("BarterItemId", ErrorMessage = BarterQuantityRequired)]
		//async check for availability and if is as barter in another offer
		public decimal? BarterQuantity { get; set; }


		[Display(Name = "Give My User Name to the Seller.")]
		public bool UseBuyerName { get; set; }
		[Display(Name = "Give My Email to the Seller.")]
		public bool UseBuyerEmail { get; set; }
		[Display(Name = "Give My Phone Number to the Seller.")]
		public bool UseBuyerPhone { get; set; }

	}
}
