namespace Items.Services.Data.Models.Location
{
	using Items.Web.ViewModels.Location;

	public class AllLocationServiceModel
	{
		public AllLocationServiceModel()
		{
			Locations = new HashSet<AllLocationViewModel>();
		}

		public IEnumerable<AllLocationViewModel> Locations { get; set; }

		public int TotalLocationsCount { get; set; }
	}
}
