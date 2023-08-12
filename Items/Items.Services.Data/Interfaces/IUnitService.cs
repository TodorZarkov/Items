namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Unit;

	public interface IUnitService
	{
		Task<bool> IsValidId(int unitId);

		Task<IEnumerable<ForSelectUnitViewModel>> AllForSelectAsync();
	}
}
