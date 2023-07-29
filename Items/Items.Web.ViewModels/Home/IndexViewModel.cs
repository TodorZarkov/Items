namespace Items.Web.ViewModels.Home
{
	public class IndexViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string MainPictureUri { get; set; } = null!;


		public double CurrentPrice { get; set; }


        public bool IsAuction { get; set; }

    }
}
