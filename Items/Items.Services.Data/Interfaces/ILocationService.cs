namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Location;

	public interface ILocationService
	{
		Task<IEnumerable<AllLocationViewModel>> AllAsync(Guid userId);

		Task<IEnumerable<ForSelectLocationViewModel>> AllForSelectAsync(Guid userId);

		Task<bool> IsAllowedIdAsync(Guid locationId, Guid userId);
	}
}
