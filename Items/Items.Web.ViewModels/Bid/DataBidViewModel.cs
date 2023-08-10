namespace Items.Web.ViewModels.Bid
{
	using Items.Web.ViewModels.Item;

	public class DataBidViewModel
	{
		public IEnumerable<AllBidViewModel> Bids { get; set; } = null!;

		public IEnumerable<ItemForBarterViewModel> ItemsFitForBarter { get; set; } = null!;
    }
}
