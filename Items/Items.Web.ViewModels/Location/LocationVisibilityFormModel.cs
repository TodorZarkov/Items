namespace Items.Web.ViewModels.Location
{
	using Items.Common.Enums;

	public class LocationVisibilityFormModel
	{
		public LocationVisibilityFormModel()
		{
			Country = AccessModifier.Public;
			Town = AccessModifier.Public;

			GeoLocation = AccessModifier.Private;

			Name = AccessModifier.Private;
			Description = AccessModifier.Private;
			Border = AccessModifier.Private;
			Address = AccessModifier.Private;
		}
		public AccessModifier Name { get; set; }

		public AccessModifier Description { get; set; }

		public AccessModifier GeoLocation { get; set; }

		public AccessModifier Border { get; set; }

		public AccessModifier Country { get; set; }

		public AccessModifier Town { get; set; }

		public AccessModifier Address { get; set; }
	}
}
