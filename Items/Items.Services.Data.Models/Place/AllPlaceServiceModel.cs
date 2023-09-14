namespace Items.Services.Data.Models.Place
{
	using Items.Web.ViewModels.Place;

	public class AllPlaceServiceModel
	{
		public AllPlaceServiceModel()
		{
			Places = new HashSet<AllPlaceViewModel>();
		}

		public IEnumerable<AllPlaceViewModel> Places { get; set; }

		public int TotalPlacesCount { get; set; }
	}
}
