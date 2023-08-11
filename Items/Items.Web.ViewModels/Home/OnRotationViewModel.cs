namespace Items.Web.ViewModels.Home
{
	public class OnRotationViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string MainPictureUri { get; set; } = null!;

		public string AddedOn { get; set; } = null!;

        public string Quantity { get; set; } = null!;

		public string Unit { get; set; } = null!;

        public string[] Categories { get; set; } = null!;

		public string Place { get; set; } = null!;

		public string Location { get; set; } = null!;

	}
}
