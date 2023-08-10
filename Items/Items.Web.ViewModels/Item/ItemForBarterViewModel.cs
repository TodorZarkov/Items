namespace Items.Web.ViewModels.Item
{
	public class ItemForBarterViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string MainPictureUri { get; set; } = null!;

		public string QuantityCanBarter { get; set; } = null!;


		public string Unit { get; set; } = null!;
	}
}
