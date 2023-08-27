namespace Items.Web.ViewModels.Place
{
	public class ForSelectPlaceViewModel
	{
        public int PlaceId { get; set; }

        public string PlaceName { get; set; } = null!;

        public string LocationName { get; set; } = null!; // TODO: this is due to missing ajax

        public string ExtendedPlaceName { get; set; } = null!; // TODO: this is due to missing ajax
	}
}
