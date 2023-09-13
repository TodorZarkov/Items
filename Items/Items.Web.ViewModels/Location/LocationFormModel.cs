namespace Items.Web.ViewModels.Location
{
	using System.ComponentModel.DataAnnotations;

	using static Items.Common.EntityValidationConstants.Location;

	public class LocationFormModel
	{
		[Required]
		public LocationVisibilityFormModel LocationVisibility { get; set; } = null!;

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;


		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string? Description { get; set; }

		// todo: choose api to get coordinates
		// todo: validate accordingly
		[Display(Name = "Geo Location")]
		public string? GeoLocation { get; set; }

		// todo: choose api to get border
		// todo: validate accordingly
		public string? Border { get; set; }


		[Required]
		[StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
		public string Country { get; set; } = null!;


		[StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
		public string? Town { get; set; }


		[Required]
		[StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
		public string Address { get; set; } = null!;
	}
}
