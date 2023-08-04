namespace Items.Web.ViewModels.Item
{
	public class AllItemViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string MainPictureUri { get; set; } = null!;


		public string CurrentPrice { get; set; } = null!;

		public string? CurrencySymbol { get; set; }


		public bool? IsAuction { get; set; }


		public string[] Categories { get; set; } = null!;
		public int[] CategoryIds { get; set; } = null!;
	}
}
