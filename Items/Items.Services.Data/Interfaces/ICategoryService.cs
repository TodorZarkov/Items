namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Category;

	public interface ICategoryService
	{
		Task<IEnumerable<CategoryViewModel>> GetAllAsync();

		Task<IEnumerable<CategoryViewModel>> GetMineAsync(Guid userId);
	}
}
