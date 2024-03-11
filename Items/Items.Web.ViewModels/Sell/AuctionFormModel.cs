namespace Items.Web.ViewModels.Sell
{
	using Items.Web.Validators.Attributes;
	using static Common.EntityValidationErrorMessages.Item;

	public class AuctionFormModel
	{
		//async validation after or equal old end sell
		[AfterOrEqualCurrentDate]
        public DateTime EndSell { get; set; }

		public DateTime StartSell { get; set; }

		public string Name { get; set; } = null!;

        public Guid MainPictureId { get; set; }

    }
}
