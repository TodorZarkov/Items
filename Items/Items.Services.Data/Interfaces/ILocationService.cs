namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Location;

	public interface ILocationService
	{
		Task<IEnumerable<AllLocationViewModel>> AllAsync(Guid userId);
	}
}
