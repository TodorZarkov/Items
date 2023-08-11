namespace Items.Services.Data
{
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;

	using Common.Enums;
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Home;
	using Items.Web.ViewModels.Item;
	using static Common.FormatConstants.DateAndTime;
	using Items.Web.ViewModels.Sell;
	using Items.Common.Interfaces;

	public class ItemService : IItemService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IHelper helper;

		public ItemService(ItemsDbContext dbContext, IHelper helper)
		{
			this.dbContext = dbContext;
			this.helper = helper;
		}

		public async Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems)
		{
			IEnumerable<IndexViewModel> items = await dbContext.Items
				.Where(i => i.Access == AccessModifier.Public &&// todo: remove Access!!!
							i.EndSell != null && i.EndSell > DateTime.UtcNow)
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
				.Where(i => i.Access == AccessModifier.Public //todo: remove Access
						&& i.EndSell != null && i.EndSell > DateTime.UtcNow)
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
						.ToArray(),

					EndSell = i.EndSell.HasValue ? i.EndSell.Value.ToString(BiddingLongUtcDateTime) : null,

					HighestBid = i.Offers.Max(o => o.Value).ToString("N2"),

					IsOnMarket = true,
					BarterOffers = i.Offers.Count(o => o.BarterItemId != null)
				})
				.ToArrayAsync();

			return items;
		}


		public async Task<IEnumerable<AllItemViewModel>> GetByCategoriesOnSaleItemsAsync(
			int[] categories, Guid? userId = null)
		{
			IEnumerable<AllItemViewModel> items = await dbContext.Items
				.Where(i => i.Access == AccessModifier.Public //todo: remove Access from entity
						&& i.EndSell != null && i.EndSell > DateTime.UtcNow)
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
						.ToArray(),

					EndSell = i.EndSell.HasValue ? i.EndSell.Value.ToString(BiddingLongUtcDateTime) : null,

					HighestBid = i.Offers.Max(o => o.Value).ToString("N2"),

					IsOnMarket = true,
					BarterOffers = i.Offers.Count(o => o.BarterItemId != null)

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
						.ToArray(),

					EndSell = i.EndSell.HasValue ? i.EndSell.Value.ToString(BiddingLongUtcDateTime) : null,

					HighestBid = i.Offers.Max(o => o.Value).ToString("N2"),

					IsOnMarket = i.EndSell >= DateTime.UtcNow,
					BarterOffers = i.Offers.Count(o => o.BarterItemId != null)

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
				.Where(i => i.OwnerId == userId 
						|| i.Access == AccessModifier.Public //todo: remove Access from entity
								&& i.EndSell != null && i.EndSell > DateTime.UtcNow)
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
						.ToArray(),

					EndSell = i.EndSell.HasValue ? i.EndSell.Value.ToString(BiddingLongUtcDateTime) : null,

					HighestBid = i.Offers.Max(o => o.Value).ToString("N2"),

					IsOnMarket = i.EndSell >= DateTime.UtcNow,
					BarterOffers = i.Offers.Count(o => o.BarterItemId != null)

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
				.Where(i => i.OwnerId == userId 
						|| i.Access == AccessModifier.Public //todo: remove Access
								&& i.EndSell != null && i.EndSell > DateTime.UtcNow)
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
						.ToArray(),

					EndSell = i.EndSell.HasValue ? i.EndSell.Value.ToString(BiddingLongUtcDateTime) : null,

					HighestBid = i.Offers.Max(o => o.Value).ToString("N2"),

					IsOnMarket = i.EndSell >= DateTime.UtcNow,
					BarterOffers = i.Offers.Count(o => o.BarterItemId != null)
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
					IsOnMarket = i.EndSell >= DateTime.UtcNow,


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

		public async Task<IEnumerable<ItemForBarterViewModel>> MyAvailableForBarter(Guid userId)
		{
			IEnumerable<ItemForBarterViewModel> allItemsForBarter =
				await dbContext.Items
				.Where(i => i.OwnerId == userId)
				.Where(i => i.Quantity > i.AsBarterForOffers.Sum(bo => bo.BarterQuantity)) // todo: observe the equality when dealing with decimal!!!!!
				.Select(i => new ItemForBarterViewModel
				{
					Id = i.Id,
					MainPictureUri = i.MainPictureUri,
					Name = i.Name,
					Unit = i.Unit.Symbol,
					QuantityCanBarter = 
										(i.Quantity - 
										(i.AsBarterForOffers.Sum(bo => bo.BarterQuantity).HasValue ? 
										(decimal)(i.AsBarterForOffers.Sum(bo => bo.BarterQuantity)!) : decimal.Zero))
										.ToString("N2"),
				})
				.ToArrayAsync();

			return allItemsForBarter;
		}

		public async Task<IEnumerable<AllSellViewModel>> MyAllOnMarket(Guid userId)
		{
			AllSellViewModel[] itemsOnMarket = await dbContext.Items
				.AsNoTracking()
				.Where(i => i.OwnerId == userId)
				.Where(i => i.EndSell.HasValue) //&& i.EndSell > DateTime.UtcNow)
				.OrderByDescending(i => i.EndSell)
				.Select(i => new AllSellViewModel
				{
					ItemId = i.Id,
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,
					Location = i.Location.Name,
					Place = i.Place.Name,
					Quantity = i.Quantity.ToString("N2"),
					Unit = i.Unit.Symbol,
					CurrentPrice = ((decimal)i.CurrentPrice!).ToString("N2"),// It has to have it at this point. It's ether start or sell price!
					Currency = i.Currency!.Symbol,
					StartSell = ((DateTime)i.StartSell!).ToString(BiddingLongUtcDateTime),
					EndSell = ((DateTime)i.EndSell!),
					Categories = i.ItemsCategories
									.Select(ic => ic.Category.Name)
									.ToArray(),
					BartersCount = i.IsAuction.HasValue && (bool)i.IsAuction ? i.Offers.Count(o => o.BarterItemId.HasValue) : null,
					HighestBid = i.IsAuction.HasValue && (bool)i.IsAuction ? i.Offers.Max(o => o.Value).ToString("N2") : null,
					OffersCount = i.IsAuction.HasValue && (bool)i.IsAuction ? i.Offers.Count() : null,
					IsAuction = i.IsAuction.HasValue && (bool)i.IsAuction,
					IsSell = !(i.IsAuction.HasValue && (bool)i.IsAuction),

					Visibility = new ItemVisibilityViewModel
					{
						Location = i.ItemVisibility.Location,
						Offers = i.ItemVisibility.Offers,
						Quantity = i.ItemVisibility.Quantity
					}
				})
				.ToArrayAsync();

			return itemsOnMarket;
		}

		public async Task<IEnumerable<OnRotationViewModel>> GetDailyRotationsAsync(Guid userId)
		{

			IEnumerable<OnRotationViewModel> currentItemRotation = await dbContext.Items
				.AsNoTracking()
				.Where(i => i.OwnerId == userId)
				.Where(i => i.OnRotation && i.OnRotationNow)
				.Where(i => !i.EndSell.HasValue)
				.Select(i => new OnRotationViewModel
				{
					Id = i.Id,
					MainPictureUri = i.MainPictureUri,
					Name = i.Name,
					Quantity = i.Quantity.ToString("N2"),
					Unit = i.Unit.Symbol,
					Categories = i.ItemsCategories.Select(ic => ic.Category.Name).ToArray(),
					AddedOn = i.AddedOn.ToString(RotatedItemsDateTime),
					Place = i.Place.Name,
					Location = i.Location.Name
				})
				.ToArrayAsync();

			return currentItemRotation;
		}

		public async Task SetDailyRotationsAsync(Guid userId, int numberOfItems)
		{

			var allItemRotation = dbContext.Items
				.Where(i => i.OwnerId == userId)
				.Where(i => i.OnRotation)
				.Where(i => !i.EndSell.HasValue);


			HashSet<int> rands = helper.GetRandNUniqueOfM(numberOfItems, allItemRotation.Count());
			int index = 0;
			foreach (var item in allItemRotation)
			{
				if (rands.Contains(index))
				{
					item.OnRotationNow = true;
				}
				else
				{
					item.OnRotationNow = false;
				}
				index++;
			}

			await dbContext.SaveChangesAsync();
		}
	}
}
