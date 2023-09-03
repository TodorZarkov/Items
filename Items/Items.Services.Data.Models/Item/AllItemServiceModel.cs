namespace Items.Services.Data.Models.Item
{
	using Items.Web.ViewModels.Item;

	public class AllItemServiceModel
	{
        public AllItemServiceModel()
        {
            Items = new HashSet<AllItemViewModel>();
        }

        public IEnumerable<AllItemViewModel> Items { get; set; }

        public int TotalItemsCount { get; set; }
    }
}
