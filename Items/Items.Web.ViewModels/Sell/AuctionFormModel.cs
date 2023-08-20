namespace Items.Web.ViewModels.Sell
{
	using Items.Web.Validators.Attributes;
	using static Common.EntityValidationErrorMessages.Item;

	public class AuctionFormModel
	{
        public DateTime EndSell { get; set; }

		[AfterOrEqualCurrentDate(ErrorMessage = StartSellCannotBeInThePast)]
		[DateBefore("EndSell", ErrorMessage = StartSellAfterEndSell)]
		public DateTime StartSell { get; set; }

		public string Name { get; set; } = null!;

		public string? MainPictureUri { get; set; } = null!;

	}
}
