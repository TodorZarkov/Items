namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Home;
	using System.Collections.Generic;

	public class ItemService : IItemService
	{
		private readonly ItemsDbContext dbContext;

        public ItemService(ItemsDbContext dbContext)
        {
			this.dbContext = dbContext;   
        }


        public IEnumerable<IndexViewModel> LastThreePublicItemsAsync()
		{
			throw new NotImplementedException();
		}
	}
}
