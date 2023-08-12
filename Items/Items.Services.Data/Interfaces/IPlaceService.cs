namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Place;

	public interface IPlaceService
	{
		Task<IEnumerable<AllPlaceViewModel>> AllAsync(Guid userId);

		Task<IEnumerable<ForSelectPlaceViewModel>> AllForSelectAsync(Guid userId);

		Task<bool> IsAllowedIdAsync(int placeId, Guid locationId, Guid userId);
	}
}
