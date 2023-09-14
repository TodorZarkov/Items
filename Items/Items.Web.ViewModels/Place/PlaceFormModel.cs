namespace Items.Web.ViewModels.Place
{
	using Items.Web.ViewModels.Location;
	using System.ComponentModel.DataAnnotations;
	using static Items.Common.EntityValidationConstants.Place;

	public class PlaceFormModel
	{
		
		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;


		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string? Description { get; set; }


        public IEnumerable<ForSelectLocationViewModel>? AvailableLocations { get; set; }

		//async check for available and allowed id
		[Display(Name = "Location")]
		public Guid LocationId { get; set; }

	}
}
