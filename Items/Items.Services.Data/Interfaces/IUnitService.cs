namespace Items.Services.Data.Interfaces
{
    using Items.Services.Data.Models.Unit;
    using Items.Web.ViewModels.Unit;

	public interface IUnitService
	{

		Task<IEnumerable<ForSelectUnitViewModel>> AllForSelectAsync();

		Task<AllUnitInfoServiceModel> AllAsync();

		Task<UnitServiceModel> GetByIdAsync(int unitId);

		Task<int> CreateAsync(UnitServiceModel unitModel);

		Task DeleteByIdAsync(int unitId);


		Task<long> CountRelationsAsync(int unitId);

		Task<bool> IsValidIdAsync(int unitId);

		Task<bool> ExistByNameAsync(string unitName);

	}
}
