namespace Items.Web.ViewModels.Location
{
	using Items.Common.Enums;

	public class LocationVisibilityViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string GeoLocation { get; set; } = null!;

		public string Border { get; set; } = null!;

		public string Country { get; set; } = null!;

		public string Town { get; set; } = null!;

		public string Address { get; set; } = null!;
	}
}
