namespace Items.Web.ViewModels.Bid
{
	using Items.Web.Validators.Attributes;
	using System.ComponentModel.DataAnnotations;
	using static Items.Common.EntityValidationConstants.Offer;
	using static Items.Common.EntityValidationErrorMessages.Offer;

	public class EditBidFormModel
	{
		[Required]
		[Range(QuantityMinValue, QuantityMaxValue)]
		//async check for available quantity
		public decimal Quantity { get; set; }


		[Required]
		[Range(ValueMinValue, ValueMaxValue)]
		//async check cannot be les than highest bid or the start price
		public decimal Value { get; set; }


		[RequiredIfPresent("BarterQuantity", ErrorMessage = BarterItemRequired)]
		//async check for barter availability: owner check, quantity, is for barter in another place ...
		public Guid? BarterItemId { get; set; }


		[RequiredIfPresent("BarterItemId", ErrorMessage = BarterQuantityRequired)]
		//async check for availability and if is as barter in another offer
		public decimal? BarterQuantity { get; set; }
	}
}
