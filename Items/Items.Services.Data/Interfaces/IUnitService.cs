namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Unit;

	public interface IUnitService
	{
		Task<bool> IsValidIdAsync(int unitId);

		Task<IEnumerable<ForSelectUnitViewModel>> AllForSelectAsync();
	}
}
