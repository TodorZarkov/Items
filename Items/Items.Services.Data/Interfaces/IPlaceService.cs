namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Place;

	public interface IPlaceService
	{
		/// <summary>
		/// TO BE USED IN CASE OF ON AJAX ON CLIENT FOR LOCATION CHOISE!!!
		/// IT RETURNS ALL PLACES FOR ALL LOCATIONS!!!
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<IEnumerable<AllPlaceViewModel>> AllAsync(Guid userId);

		Task<IEnumerable<ForSelectPlaceViewModel>> AllForSelectAsync(Guid userId, Guid locationId);

		Task<IEnumerable<ForSelectPlaceViewModel>> AllForSelectAsync(Guid userId);

		Task<bool> IsAllowedIdAsync(int placeId, Guid locationId, Guid userId);

		/// <summary>
		/// NO LOCATION CHOISE CONSIDERED!
		/// </summary>
		/// <param name="placeId"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<bool> IsAllowedIdAsync(int placeId, Guid userId);
	}
}
