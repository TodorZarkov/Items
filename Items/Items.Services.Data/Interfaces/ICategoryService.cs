namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Category;

	public interface ICategoryService
	{
		Task<ICollection<CategoryFilterViewModel>> GetAllPublicAsync();
		Task<ICollection<CategoryFilterViewModel>> GetMineAsync(Guid userId);
		Task<IEnumerable<CategoryFilterViewModel>> AllForSelectAsync(Guid userId);


		Task<ICollection<int>> GetAllIdsAsync();
		
		Task<ICollection<int>> GetAllPublicIdsAsync();

		Task<IEnumerable<ForSelectCategoryViewModel>> GetForSelectAsync(Guid? userId = null);


		Task<int> AddAsync(CategoryFormViewModel model, Guid userId);
		Task DeleteAsync(int categoryId);

		Task<bool> IsAllowedIdsAsync(int[] ids, Guid userId);
		Task<bool> IsAllowedPublicIdsAsync(int[] ids);
		/// <summary>
		/// Checks if the the given category name is already added by one of the admins or by the user (userId) itself.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<bool> ExistNameAsync(string name, Guid userId);

		Task<long> CountReferencesAsync(int categoryId);
		Task<bool> IsOwnerAsync(Guid userId, int categoryId);

	}
}
