namespace Items.Services.Data.Models.Offer
{
	using Items.Web.ViewModels.Item;
	using Items.Web.ViewModels.Offer;

	public class AllOfferServiceModel
	{
		public AllOfferServiceModel()
		{
			Offers = new HashSet<AllOfferViewModel>();
		}

		public IEnumerable<AllOfferViewModel> Offers { get; set; }

		public int TotalOffersCount { get; set; }

		public ItemOfferViewModel Item { get; set; } = null!;
	}
}
