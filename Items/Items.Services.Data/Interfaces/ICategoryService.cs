namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Category;

	public interface ICategoryService
	{
		Task<ICollection<CategoryFilterViewModel>> GetAllAsync();

		Task<ICollection<CategoryFilterViewModel>> GetMineAsync(Guid userId);
	}
}
