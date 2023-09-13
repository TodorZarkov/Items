namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.Location;
	using Items.Web.ViewModels.Base;
	using Items.Web.ViewModels.Location;

	public interface ILocationService
	{
		Task<AllLocationServiceModel> GetAllAsync(Guid userId, QueryFilterModel? queryModel = null);

		Task<LocationFormModel> GetByIdAsync(Guid id);

		Task<IEnumerable<ForSelectLocationViewModel>> AllForSelectAsync(Guid userId);


		Task<bool> IsAllowedIdAsync(Guid locationId, Guid userId);



		Task<Guid> CreateAsync(LocationFormModel model, Guid userId);

		Task EditAsync(LocationFormModel model, Guid locationId);
		Task<bool> IsEmptyAsync(Guid id);
		Task Delete(Guid id);
	}
}
