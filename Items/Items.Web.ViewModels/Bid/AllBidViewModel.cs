namespace Items.Web.ViewModels.Bid
{
	using Items.Web.ViewModels.Item;
	using Items.Web.ViewModels.Offer;

	public class AllBidViewModel : AllOfferViewModel
	{
		public Guid ItemId { get; set; }

		public ItemBidViewModel Item { get; set; } = null!;
	}
}
