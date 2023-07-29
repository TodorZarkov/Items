namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Home;

	public interface IItemService
	{
		IEnumerable<IndexViewModel> LastThreePublicItemsAsync();
	}
}
