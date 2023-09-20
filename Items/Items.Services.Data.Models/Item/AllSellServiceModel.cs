namespace Items.Services.Data.Models.Item
{
	using Items.Web.ViewModels.Sell;

	public class AllSellServiceModel
	{
		public AllSellServiceModel()
		{
			Sells = new HashSet<AllSellViewModel>();
		}

		public IEnumerable<AllSellViewModel> Sells { get; set; }

		public int TotalSellsCount { get; set; }
	}
}
