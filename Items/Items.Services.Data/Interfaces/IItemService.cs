namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Home;
	using Items.Web.ViewModels.Item;

	public interface IItemService
	{
		Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems);


		Task<IEnumerable<AllItemViewModel>> GetByCategoriesOnSaleItemsAsync(
			int[] categories, Guid? userId);

		Task<IEnumerable<AllItemViewModel>> GetByCategoriesMineItemsAsync(
			int[] categories, Guid userId);

		Task<IEnumerable<AllItemViewModel>> GetByCategoriesAllItemsAsync(
			int[] categories, Guid userId);

		Task<IEnumerable<AllItemViewModel>> AllPublic();

		Task<IEnumerable<AllItemViewModel>> All(Guid userId);


		Task<IEnumerable<MyItemViewModel>> Mine(Guid userId);


		Task<IEnumerable<ItemForBarterViewModel>> MyAvailableForBarter(Guid userId);
	}
}
