namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Category;

	public interface ICategoryService
	{
		Task<ICollection<CategoryFilterViewModel>> GetAllPublicAsync();

		Task<ICollection<int>> GetAllIdsAsync();
		
		Task<ICollection<int>> GetAllPublicIdsAsync();

		Task<ICollection<CategoryFilterViewModel>> GetMineAsync(Guid userId);

		Task<bool> IsAllowedIdsAsync(int[] ids, Guid userId);
		Task<bool> IsAllowedPublicIdsAsync(int[] ids);
	}
}
