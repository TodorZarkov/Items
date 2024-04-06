namespace Items.Web.ViewModels.Home
{
	public class IndexStatViewModel
	{
		public IEnumerable<IndexViewModel> IndexViewModels { get; set; } = null!;

		public long ItemsCount { get; set; }
		public long ItemsOnMarketCount { get; set; }
		public long DealsCompletedCount { get; set; }
		public long UsersCount { get; set; }
	}
}
