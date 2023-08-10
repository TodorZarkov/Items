namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Place;

	public interface IPlaceService
	{
		Task<IEnumerable<AllPlaceViewModel>> AllAsync(Guid userId);
	}
}
