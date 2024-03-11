namespace Items.Web.ViewModels.Item
{
	public class PreDeleteItemViewModel
	{
		public string Name { get; set; } = null!;

		public Guid MainPictureId { get; set; }

		public string Quantity { get; set; } = null!;

		public string Unit { get; set; } = null!;

		public string Categories { get; set; } = null!;
	}
}
