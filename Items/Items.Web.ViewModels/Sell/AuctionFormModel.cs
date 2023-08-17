namespace Items.Web.ViewModels.Sell
{
	public class AuctionFormModel
	{
		//validate end sell according to start sell and now
        public DateTime EndSell { get; set; }


        public DateTime StartSell { get; set; }

		public string Name { get; set; } = null!;

		public string? MainPictureUri { get; set; } = null!;

	}
}
