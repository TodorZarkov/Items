namespace Items.Web.ViewModels.Item
{
	public class ItemForBarterViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		//todo: it would be appropriate to show the picture in the dropdown.
		public Guid MainPictureId { get; set; }

		public string QuantityCanBarter { get; set; } = null!;

		public string ExtendedName
		{
			get => $"{Name} - You have {QuantityCanBarter} {Unit} left.";
		}

		public string Unit { get; set; } = null!;
	}
}
