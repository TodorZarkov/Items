namespace Items.Web.ViewModels.Item
{
	public class MyItemViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string MainPictureUri { get; set; } = null!;



		public string? Quantity { get; set; }

		public string? Unit { get; set; }

		public string[] Categories { get; set; } = null!;
	}
}
