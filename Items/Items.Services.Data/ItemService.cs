namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Home;
	using System.Collections.Generic;
	using Common.Enums;
	using Microsoft.EntityFrameworkCore;

	public class ItemService : IItemService
	{
		private readonly ItemsDbContext dbContext;

        public ItemService(ItemsDbContext dbContext)
        {
			this.dbContext = dbContext;   
        }


        public async Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems)
		{
			IEnumerable<IndexViewModel> items = await dbContext.Items
				.Where(i => i.Access == AccessModifier.Public &&
							(i.EndSell == null || i.EndSell > DateTime.UtcNow))
				.OrderByDescending(i => i.StartSell)
				.Take(numberOfItems)
				.Select(i => new IndexViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,

					CurrentPrice = !i.CurrentPrice.HasValue ? "No Price Set" : ((decimal)i.CurrentPrice).ToString("N2") ,
					CurrencySymbol = 
						!i.CurrentPrice.HasValue || 
						i.Currency == null 
						? "" : i.Currency.Symbol,
					IsAuction = i.IsAuction,

					Categories = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Name)
						.ToArray()
				})
				.ToArrayAsync();

			return items;
		}
	}
}
