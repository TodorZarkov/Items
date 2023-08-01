namespace Items.Web.ViewModels.Home
{
	public class IndexViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string MainPictureUri { get; set; } = null!;


		public decimal? CurrentPrice { get; set; }

		public string? CurrencySymbol { get; set; }


        public bool? IsAuction { get; set; }

    }
}
