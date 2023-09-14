namespace Items.Web.ViewModels.Location
{
	using Items.Web.ViewModels.Place;

	public class ForSelectLocationViewModel
	{
        public Guid LocationId { get; set; }

        public string LocationName { get; set; } = null!;

    }
}
