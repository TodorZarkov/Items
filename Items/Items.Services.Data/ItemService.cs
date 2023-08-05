namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Home;
	using System.Collections.Generic;
	using Common.Enums;
	using Microsoft.EntityFrameworkCore;
	using Items.Web.ViewModels.Item;
	using Items.Data.Models;

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


		public async Task<IEnumerable<AllItemViewModel>> AllPublic()
		{
			IEnumerable<AllItemViewModel> items = await dbContext.Items
				.Where(i => i.Access == AccessModifier.Public)
				.OrderByDescending(i => i.StartSell)
				.Select(i => new AllItemViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,

					IsMine = false,

					CurrentPrice = !i.CurrentPrice.HasValue ? "No Price Set" : ((decimal)i.CurrentPrice).ToString("N2"),
					CurrencySymbol =
						!i.CurrentPrice.HasValue ||
						i.Currency == null
						? "" : i.Currency.Symbol,
					IsAuction = i.IsAuction,

					Categories = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Name)
						.ToArray(),

					CategoryIds = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Id)
						.ToArray()
				})
				.ToArrayAsync();

			return items;
		}


		public async Task<IEnumerable<AllItemViewModel>> GetByCategoriesOnSaleItemsAsync(
			int[] categories, Guid? userId = null)
		{
			IEnumerable<AllItemViewModel> items = await dbContext.Items
				.Where(i => i.Access == AccessModifier.Public)
				.Where(i => i.ItemsCategories.Any(ic => categories.Contains(ic.CategoryId)))
				.OrderByDescending(i => i.StartSell)
				.Select(i => new AllItemViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,

					IsMine = userId == i.OwnerId,
					Quantity = userId == i.OwnerId ? i.Quantity.ToString("N2") : null,
					Unit = userId == i.OwnerId ? i.Unit.Symbol : null,

					CurrentPrice = !i.CurrentPrice.HasValue ? "No Price Set" : ((decimal)i.CurrentPrice).ToString("N2"),
					CurrencySymbol =
						!i.CurrentPrice.HasValue ||
						i.Currency == null
						? "" : i.Currency.Symbol,
					IsAuction = i.IsAuction,

					Categories = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Name)
						.ToArray(),

					CategoryIds = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Id)
						.ToArray()
				})
				.ToArrayAsync();



			//todo: now the required can be more than the returned. to  implement set equality!!!
			//todo: prevent client side filtering!!!
			return items.Where(i => categories.All(cid => i.CategoryIds.Contains(cid)))
				.ToArray();
		}


		public async Task<IEnumerable<AllItemViewModel>> GetByCategoriesMineItemsAsync(
			int[] categories, Guid userId)
		{
			IEnumerable<AllItemViewModel> items = await dbContext.Items
				.Where(i => i.OwnerId == userId)
				.Where(i => i.ItemsCategories.Any(ic => categories.Contains(ic.CategoryId)))
				.OrderByDescending(i => i.ModifiedOn) 
				.Select(i => new AllItemViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,

					IsMine = userId == i.OwnerId,
					Quantity = userId == i.OwnerId ? i.Quantity.ToString("N2") : null,
					Unit = userId == i.OwnerId ? i.Unit.Symbol : null,

					CurrentPrice = !i.CurrentPrice.HasValue ? "No Price Set" : ((decimal)i.CurrentPrice).ToString("N2"),
					CurrencySymbol =
						!i.CurrentPrice.HasValue ||
						i.Currency == null
						? "" : i.Currency.Symbol,
					IsAuction = i.IsAuction,

					Categories = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Name)
						.ToArray(),

					CategoryIds = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Id)
						.ToArray()
				})
				.ToArrayAsync();


			//todo: now the required can be more than the returned. to  implement set equality!!!
			//todo: prevent client side filtering!!!
			return items.Where(i => categories.All(cid => i.CategoryIds.Contains(cid)))
				.ToArray(); ;

		}



		public async Task<IEnumerable<AllItemViewModel>> GetByCategoriesAllItemsAsync(
			int[] categories, Guid userId)
		{
			IEnumerable<AllItemViewModel> items = await dbContext.Items
				.Where(i => i.OwnerId == userId || i.Access == AccessModifier.Public)
				.Where(i => i.ItemsCategories.Any(ic => categories.Contains(ic.CategoryId)))
				.OrderByDescending(i => i.ModifiedOn) 
				.Select(i => new AllItemViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,

					IsMine = userId == i.OwnerId,
					Quantity = userId == i.OwnerId ? i.Quantity.ToString("N2") : null,
					Unit = userId == i.OwnerId ? i.Unit.Symbol : null,

					CurrentPrice = !i.CurrentPrice.HasValue ? "No Price Set" : ((decimal)i.CurrentPrice).ToString("N2"),
					CurrencySymbol =
						!i.CurrentPrice.HasValue ||
						i.Currency == null
						? "" : i.Currency.Symbol,
					IsAuction = i.IsAuction,

					Categories = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Name)
						.ToArray(),

					CategoryIds = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Id)
						.ToArray()
				})
				.ToArrayAsync();


			//todo: now the required can be more than the returned. to  implement set equality!!!
			//todo: prevent client side filtering!!!
			return items.Where(i => categories.All(cid => i.CategoryIds.Contains(cid)))
				.ToArray(); ;
		}

		public async Task<IEnumerable<AllItemViewModel>> All(Guid userId)
		{
			IEnumerable<AllItemViewModel> items = await dbContext.Items
				.Where(i => i.OwnerId == userId || i.Access == AccessModifier.Public)
				.OrderByDescending(i => i.ModifiedOn) 
				.Select(i => new AllItemViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,

					IsMine = userId == i.OwnerId,
					Quantity = userId == i.OwnerId ? i.Quantity.ToString("N2") : null,
					Unit = userId == i.OwnerId ? i.Unit.Symbol : null,

					CurrentPrice = !i.CurrentPrice.HasValue ? "No Price Set" : ((decimal)i.CurrentPrice).ToString("N2"),
					CurrencySymbol =
						!i.CurrentPrice.HasValue ||
						i.Currency == null
						? "" : i.Currency.Symbol,
					IsAuction = i.IsAuction,

					Categories = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Name)
						.ToArray(),

					CategoryIds = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Id)
						.ToArray()
				})
				.ToArrayAsync();


			return items;
		}

		public async Task<IEnumerable<MyItemViewModel>> Mine(Guid userId)
		{
			IEnumerable<MyItemViewModel> items = await dbContext.Items
				.Where(i => i.OwnerId == userId)
				.OrderByDescending(i => i.ModifiedOn)
				.Select(i => new MyItemViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,
					
					Quantity = userId == i.OwnerId ? i.Quantity.ToString("N2") : null,
					Unit = userId == i.OwnerId ? i.Unit.Symbol : null,

					IsAuction = i.IsAuction,
					IsOnMarket = i.Access == AccessModifier.Public,
					
					Categories = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Name)
						.ToArray(),

					Offers = i.Offers.Count,

					Location = i.Location.Name,

					Place = i.Place.Name,
				})
				.ToArrayAsync();


			return items;
		}
	}
}
