namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Home;

	public interface IItemService
	{
		Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems);
	}
}
