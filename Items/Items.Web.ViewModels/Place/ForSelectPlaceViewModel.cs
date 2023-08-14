namespace Items.Web.ViewModels.Place
{
	public class ForSelectPlaceViewModel
	{
        public int PlaceId { get; set; }

        public string PlaceName { get; set; } = null!;

        public string LocationName { get; set; } = null!; //todo: this is due to missing ajax

        public string ExtendedPlaceName { get; set; } = null!; //todo: this is due to missing ajax
	}
}
