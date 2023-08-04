namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Home;
	using Items.Web.ViewModels.Item;

	public interface IItemService
	{
		Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems);

		Task<IEnumerable<AllItemViewModel>> GetByCategoryCombinationAsync(int[] categories);

		Task<IEnumerable<AllItemViewModel>> AllPublic();
	}
}
