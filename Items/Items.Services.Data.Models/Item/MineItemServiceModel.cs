namespace Items.Services.Data.Models.Item
{
	using Items.Web.ViewModels.Item;

	public class MineItemServiceModel
	{
		public MineItemServiceModel()
		{
			Items = new HashSet<MyItemViewModel>();
		}

		public IEnumerable<MyItemViewModel> Items { get; set; }

		public int TotalItemsCount { get; set; }
	}
}
