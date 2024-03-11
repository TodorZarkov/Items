namespace Items.Web.ViewModels.Bid
{
    using Items.Web.ViewModels.Item;

    public class AllBidViewModel
	{
		public Guid ItemId { get; set; }

        public bool Win { get; set; }

        public ItemBidViewModel Item { get; set; } = null!;

		public Guid OfferId { get; set; }

		public string Expires { get; set; } = null!;

		public string? Message { get; set; }


		public decimal QuantityToBuy { get; set; }
		public decimal ValuePerQuantity { get; set; }


		public string? BarterQuantity { get; set; }
		public string? BarterUnit { get; set; }
		public Guid? BarterItemId { get; set; }
		//todo: to use the barterPicture in the dropdown
		public Guid? BarterPictureId { get; set; }
		public string? BarterName { get; set; }
	}
}
