namespace Items.Web.ViewModels.Location
{
	using Items.Common.Enums;

	public class LocationVisibilityViewModel
	{
		public Guid Id { get; set; }

		public AccessModifier Name { get; set; }

		public AccessModifier Description { get; set; }

		public AccessModifier GeoLocation { get; set; }

		public AccessModifier Border { get; set; }

		public AccessModifier Country { get; set; }

		public AccessModifier Town { get; set; }

		public AccessModifier Address { get; set; }
	}
}
