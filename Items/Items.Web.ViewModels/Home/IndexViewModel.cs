namespace Items.Web.ViewModels.Home
{
	public class IndexViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public Guid MainPictureId { get; set; }

		public string CurrentPrice { get; set; } = null!;

		public string? CurrencySymbol { get; set; }


        public bool? IsAuction { get; set; }


		public string[] Categories { get; set; } = null!;

    }
}
