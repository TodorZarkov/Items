namespace Items.Services.Data.Models.Offer
{
	using Items.Web.ViewModels.Bid;
	using Items.Web.ViewModels.Item;

	public class AllOfferServiceModel
	{
		public AllOfferServiceModel()
		{
			Bids = new HashSet<AllBidViewModel>();
			ItemsFitForBarter = new HashSet<ItemForBarterViewModel>();
		}

		public IEnumerable<AllBidViewModel> Bids { get; set; }

		public int TotalOffersCount { get; set; }

        public IEnumerable<ItemForBarterViewModel> ItemsFitForBarter { get; set; }
    }
		
}
