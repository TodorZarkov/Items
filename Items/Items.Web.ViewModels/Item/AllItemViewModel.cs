namespace Items.Web.ViewModels.Item
{
	// todo: reuse some of the models by inheritance 
	public class AllItemViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string MainPictureUri { get; set; } = null!;

		public string? EndSell { get; set; }

		public string? HighestBid { get; set; }
        public int? BarterOffers { get; set; }

        public bool? IsOnMarket { get; set; }

        public string CurrentPrice { get; set; } = null!;

		public string? CurrencySymbol { get; set; }


		public bool? IsAuction { get; set; }

        public bool IsMine { get; set; }

        public string? Quantity { get; set; }

        public string? Unit { get; set; }

        public string[] Categories { get; set; } = null!;
		public int[] CategoryIds { get; set; } = null!;
	}
}
