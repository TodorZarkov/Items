namespace Items.Services.Data
{
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;

	using static Items.Common.EntityDbErrorMessages.Item;
	using static Items.Common.FormatConstants.DateAndTime;
	using static Items.Common.Enums.AccessModifier;
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Home;
	using Items.Web.ViewModels.Item;
	using Items.Web.ViewModels.Sell;
	using Items.Services.Common.Interfaces;
	using Items.Data.Models;
	using Items.Web.ViewModels.Location;

	public class ItemService : IItemService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IHelper helper;
		private readonly IDateTimeProvider dateTimeProvider;

		public ItemService(ItemsDbContext dbContext, IHelper helper, IDateTimeProvider dateTimeProvider)
		{
			this.dbContext = dbContext;
			this.helper = helper;
			this.dateTimeProvider = dateTimeProvider;
		}

		public async Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems)
		{
			IndexViewModel[] items = await dbContext.Items
				.AsNoTracking()
				.Where(i =>  !i.Deleted)
				.Where(i => i.EndSell != null && i.EndSell > dateTimeProvider.GetCurrentDateTime())
				.OrderByDescending(i => i.StartSell)
				.Take(numberOfItems)
				.Select(i => new IndexViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,

					CurrentPrice = !i.CurrentPrice.HasValue ? "No Price Set" : ((decimal)i.CurrentPrice).ToString("N2"),
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
			Array.Reverse(items);
			return items;
		}

		public async Task<IEnumerable<AllItemViewModel>> AllPublic()
		{
			IEnumerable<AllItemViewModel> items = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.EndSell != null && i.EndSell > dateTimeProvider.GetCurrentDateTime())
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
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => !i.Deleted)
				.Where(i => i.EndSell != null && i.EndSell > dateTimeProvider.GetCurrentDateTime()) 
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
				.AsNoTracking()
				.Where(i =>  !i.Deleted)
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

					IsOnMarket = i.EndSell >= dateTimeProvider.GetCurrentDateTime(),
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
				.AsNoTracking()
				.Where(i =>  !i.Deleted)
				.Where(i => i.OwnerId == userId
						|| i.EndSell != null && i.EndSell > dateTimeProvider.GetCurrentDateTime())
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

					IsOnMarket = i.EndSell >= dateTimeProvider.GetCurrentDateTime(),
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
				.AsNoTracking()
				.Where(i =>  !i.Deleted)
				.Where(i => i.OwnerId == userId
						|| i.EndSell != null && i.EndSell > dateTimeProvider.GetCurrentDateTime())
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

					IsOnMarket = i.EndSell >= dateTimeProvider.GetCurrentDateTime(),
					BarterOffers = i.Offers.Count(o => o.BarterItemId != null)
				})
				.ToArrayAsync();


			return items;
		}

		public async Task<IEnumerable<MyItemViewModel>> Mine(Guid userId)
		{
			IEnumerable<MyItemViewModel> items = await dbContext.Items
				.AsNoTracking()
				.Where(i =>  !i.Deleted)
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
					IsOnMarket = i.EndSell >= dateTimeProvider.GetCurrentDateTime(),


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
				.AsNoTracking()
				.Where(i =>  !i.Deleted)
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
				.Where(i =>  !i.Deleted)
				.Where(i => i.OwnerId == userId)
				.Where(i => i.EndSell.HasValue) //&& i.EndSell > dateTimeProvider.GetCurrentDateTime())
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
				.Where(i =>  !i.Deleted)
				.Where(i => i.OwnerId == userId)
				.Where(i => i.OnRotation && i.OnRotationNow)
				.Where(i => !i.EndSell.HasValue)
				.Where(i => i.Quantity > 0)
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
			var allItemRotation = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.OwnerId == userId)
				.Where(i => i.OnRotation)
				.Where(i => !i.EndSell.HasValue)
				.Where(i => i.Quantity > 0)
				.ToArrayAsync();


			HashSet<int> rands = helper.GetRandNUniqueOfM(numberOfItems, allItemRotation.Length);
			int index = 0;
			for (int i  = 0; i<allItemRotation.Length;  i++)
			{
				if (rands.Contains(i))
				{
					allItemRotation[i].OnRotationNow = true;
				}
				else
				{
					allItemRotation[i].OnRotationNow = false;
				}
				index++;
			}

			await dbContext.SaveChangesAsync();
		}



		public async Task CreateItemAsync(ItemFormModel model, Guid userId)
		{
			Item item = new Item
			{
				Name = model.Name,//1.2
				Quantity = model.Quantity,//1.3
				Description = model.Description,//2.1
				OnRotation = model.OnRotation,//2.3

				AcquiredPrice = model.AcquiredPrice,//3.1
				AcquiredDate = model.AcquiredDate,//3.2
				CurrentPrice = model.CurrentPrice,//4.1
				IsAuction = model.IsAuction,//4.2
				OwnerId = userId,



				MainPictureUri = model.MainPictureUri,//1.1

				StartSell = model.StartSell,//4.3
				EndSell = model.EndSell,//4.4



				UnitId = model.UnitId,//1.4
				PlaceId = model.PlaceId,//2.2
				LocationId = new Guid(),

				CurrencyId = model.CurrencyId,//3.3
				ItemVisibility = new ItemVisibility
				{
				
					AcquiredDate = model.ItemVisibility.AcquiredDate,
					AcquireDocument = model.ItemVisibility.AcquireDocument,
					AcquiredPrice = model.ItemVisibility.AcquiredPrice,
					AddedOn = model.ItemVisibility.AddedOn,
					ModifiedOn = model.ItemVisibility.ModifiedOn,
					CurrentPrice = model.ItemVisibility.CurrentPrice,
					Description = model.ItemVisibility.Description,
					Location = model.ItemVisibility.Location,
					Offers = model.ItemVisibility.Offers,
					Quantity = model.ItemVisibility.Quantity,
					Owner = model.ItemVisibility.Owner
				}
			};

			Place? theChosenPlace = await dbContext.Places.FindAsync(model.PlaceId);
			item.LocationId = theChosenPlace!.LocationId;//not null here due to controller check

			foreach (int categoryId in model.CategoryIds)
			{
				ItemCategory itemCategory = new ItemCategory
				{
					CategoryId = categoryId
				};
				item.ItemsCategories.Add(itemCategory);
			}

			dbContext.Items.Add(item);
			await dbContext.SaveChangesAsync();
		}

		public async Task<ItemFormModel> GetByIdForEditAsync(Guid itemId)
		{
			Item item = await dbContext.Items
				.Where(i => !i.Deleted)
				.SingleAsync(i => i.Id == itemId);

			int[] categoryIds = await dbContext.ItemsCategories
				.Where(ic => ic.ItemId == itemId)
				.Select(ic => ic.CategoryId)
				.ToArrayAsync();

			ItemVisibility itemVisibility = await dbContext.ItemVisibilities
				.SingleAsync(iv => iv.Item.Id == itemId);

			ItemFormModel model = new ItemFormModel
			{
				Name = item.Name,
				MainPictureUri = item.MainPictureUri,
				Description = item.Description,
				CurrencyId = item.CurrencyId,
				CurrentPrice = item.CurrentPrice,
				EndSell = item.EndSell,
				AcquiredDate = item.AcquiredDate,
				AcquiredPrice = item.AcquiredPrice,
				IsAuction = item.IsAuction.HasValue && (bool)item.IsAuction,
				OnRotation = item.OnRotation,
				PlaceId = item.PlaceId,
				Quantity = item.Quantity,
				StartSell = item.StartSell,
				UnitId = item.UnitId,
				CategoryIds = categoryIds,
				ItemVisibility = new ItemFormVisibilityModel
				{
					Description = itemVisibility.Description,
					AcquiredDate = itemVisibility.AcquiredDate,
					AcquireDocument = itemVisibility.AcquireDocument,
					AcquiredPrice = itemVisibility.AcquiredPrice,
					AddedOn = itemVisibility.AddedOn,
					ModifiedOn = itemVisibility.ModifiedOn,
					CurrentPrice = itemVisibility.CurrentPrice,
					Location = itemVisibility.Location,
					Offers = itemVisibility.Offers,
					Owner = itemVisibility.Owner,
					Quantity = itemVisibility.Quantity
				}
			};

			return model;
		}

		public async Task<bool> IsAuthorizedAsync(Guid itemId, Guid userId)
		{
			bool result = await dbContext.Items
				.Where(i => !i.Deleted)
				.AnyAsync(i => i.Id == itemId && i.OwnerId == userId);

			return result;
		}

		public async Task UpdateItemAsync(ItemFormModel model, Guid itemId)
		{
			Item? item = await dbContext.Items
				.Where(i => !i.Deleted && i.Id == itemId)
				.SingleAsync() ?? throw new ArgumentException(string.Format(ItemNotPresentInDb, "", ""));

			ItemVisibility? itemVisibility = await dbContext
				.ItemVisibilities
				.FindAsync(item.ItemVisibilityId) 
				?? throw new ArgumentException(string.Format(ItemVisibilityNotPresentInDb, "", ""));

			item.Name = model.Name;//1.2
			item.Quantity = model.Quantity;//1.3
			item.Description = model.Description;//2.1
			item.OnRotation = model.OnRotation;//2.3
			item.AcquiredPrice = model.AcquiredPrice;//3.1
			item.AcquiredDate = model.AcquiredDate;//3.2
			item.CurrentPrice = model.CurrentPrice;//4.1
			item.IsAuction = model.IsAuction;//4.2
			item.MainPictureUri = model.MainPictureUri;//1.1
			item.StartSell = model.StartSell;//4.3
			item.EndSell = model.EndSell;//4.4
			item.UnitId = model.UnitId;//1.4
			item.PlaceId = model.PlaceId;//2.2
			item.CurrencyId = model.CurrencyId;//3.3
			item.ModifiedOn = dateTimeProvider.GetCurrentDateTime();

			itemVisibility.AcquiredDate = model.ItemVisibility.AcquiredDate;
			itemVisibility.AcquireDocument = model.ItemVisibility.AcquireDocument;
			itemVisibility.AcquiredPrice = model.ItemVisibility.AcquiredPrice;
			itemVisibility.AddedOn = model.ItemVisibility.AddedOn;
			itemVisibility.ModifiedOn = model.ItemVisibility.ModifiedOn;
			itemVisibility.CurrentPrice = model.ItemVisibility.CurrentPrice;
			itemVisibility.Description = model.ItemVisibility.Description;
			itemVisibility.Location = model.ItemVisibility.Location;
			itemVisibility.Offers = model.ItemVisibility.Offers;
			itemVisibility.Quantity = model.ItemVisibility.Quantity;
			itemVisibility.Owner = model.ItemVisibility.Owner;

			await dbContext.SaveChangesAsync();
		}

		public async Task<bool> IsAuthorizedToViewAsync(Guid itemId, Guid userId)
		{
			bool result = await dbContext.Items
				.Where(i => !i.Deleted)
				.AnyAsync(i => i.Id == itemId && i.OwnerId == userId || i.EndSell > dateTimeProvider.GetCurrentDateTime());

			return result;
		}

		public async Task<ItemViewModel> GetByIdForViewAsync(Guid itemId)
		{
			ItemViewModel model = await dbContext.Items
				.AsNoTracking()
				.Where(i =>  !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ItemViewModel
				{
					Id = i.Id,
					MainPictureUri = i.MainPictureUri,
					Name = i.Name,
					CurrentPrice = i.CurrentPrice != null ? ((decimal)i.CurrentPrice).ToString("N2") : null,
					CurrencySymbol = i.Currency != null ? i.Currency.Symbol : null,
					CurrencyIsoCode = i.Currency != null ? i.Currency.IsoCode : null,
					StartSell = i.StartSell,
					EndSell = i.EndSell,
					Categories = string.Join(", ", i.ItemsCategories.Select(ic => ic.Category.Name)),
					IsAuction = i.IsAuction,


					PlaceId = i.PlaceId,
					PlaceName = i.Place.Name,
					AsBarterForOffersCount = i.AsBarterForOffers.Count,
					ContractsCount = i.Contracts.Count(),
					OnRotation = i.OnRotation,
					OnRotationNow = i.OnRotationNow,


					Description = i.ItemVisibility.Description == Public ? i.Description : null,
					AcquiredDate = i.ItemVisibility.AcquiredDate == Public ? i.AcquiredDate : null,
					//document here
					AcquiredPrice = i.AcquiredPrice != null ? ((decimal)i.AcquiredPrice).ToString("N2") : null,
					AddedOn = i.ItemVisibility.AddedOn == Public ? i.AddedOn : null,
					ModifiedOn = i.ItemVisibility.ModifiedOn == Public ? i.ModifiedOn : null,
					//current price todo: remove
					Quantity = i.ItemVisibility.Quantity == Public ? i.Quantity.ToString("N3") : null,
					UnitName = i.Unit.Name,
					UnitSymbol = i.Unit.Symbol,
					OffersCount = i.ItemVisibility.Offers == Public ? i.Offers.Count : null,
					OwnerEmail = i.ItemVisibility.Owner == Public ? i.Owner.Email : null,
					OwnerName = i.ItemVisibility.Owner == Public ? i.Owner.UserName : null,
					OwnerPhone = i.ItemVisibility.Owner == Public ? i.Owner.PhoneNumber : null,

					ItemVisibility = new ItemFormVisibilityModel
					{
						Description = i.ItemVisibility.Description,
						AcquiredDate = i.ItemVisibility.AcquiredDate,
						AcquireDocument = i.ItemVisibility.AcquireDocument,
						AcquiredPrice = i.ItemVisibility.AcquiredPrice,
						AddedOn = i.ItemVisibility.AddedOn,
						ModifiedOn = i.ItemVisibility.ModifiedOn,
						CurrentPrice = i.ItemVisibility.CurrentPrice,
						Location = i.ItemVisibility.Location,
						Offers = i.ItemVisibility.Offers,
						Owner = i.ItemVisibility.Owner,
						Quantity = i.ItemVisibility.Quantity
					},

					Location = i.ItemVisibility.Location == Public ? new AllLocationViewModel
					{
						Name = i.Location.LocationVisibility.Name == Public ? i.Location.Name : string.Empty, //todo: fix to be nullable
						Address = i.Location.LocationVisibility.Address == Public ? i.Location.Address : string.Empty, //todo: fix to be nullable
						Description = i.Location.LocationVisibility.Description == Public ? i.Location.Description : null,
						Border = i.Location.LocationVisibility.Border == Public && i.Location.Border != null ? i.Location.Border.ToString() : null,
						Country = i.Location.LocationVisibility.Country == Public ? i.Location.Country : string.Empty, //todo: fix to be nullable
						GeoLocation =  i.Location.LocationVisibility.GeoLocation == Public && i.Location.GeoLocation != null ? i.Location.GeoLocation.ToString() : null,
						Town = i.Location.LocationVisibility.Town == Public ? i.Location.Town : null,

						Visibility = new LocationVisibilityViewModel
						{
							Name = i.Location.LocationVisibility.Name,
							Description = i.Location.LocationVisibility.Description,
							Country = i.Location.LocationVisibility.Country,
							Town = i.Location.LocationVisibility.Town,
							Address = i.Location.LocationVisibility.Address,
							GeoLocation = i.Location.LocationVisibility.GeoLocation,
							Border = i.Location.LocationVisibility.Border,
						}

					} : null

					
				})
				.SingleAsync();

			return model;
		}

		public async Task<ItemViewModel> GetByIdForViewAsOwnerAsync(Guid itemId)
		{
			ItemViewModel model = await dbContext.Items
				.AsNoTracking()
				.Where(i =>  !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ItemViewModel
				{
					Id = i.Id,
					MainPictureUri = i.MainPictureUri,
					Name = i.Name,
					CurrentPrice = i.CurrentPrice != null?((decimal)i.CurrentPrice).ToString("N2") : null,
					CurrencySymbol = i.Currency != null?i.Currency.Symbol : null,
					CurrencyIsoCode = i.Currency != null ? i.Currency.IsoCode : null,
					StartSell = i.StartSell,
					EndSell = i.EndSell,
					Categories = string.Join(", ", i.ItemsCategories.Select(ic => ic.Category.Name)),
					IsAuction = i.IsAuction,


					PlaceId = i.PlaceId,
					PlaceName = i.Place.Name,
					LocationId = i.LocationId,
					LocationName = i.Location.Name,
					AsBarterForOffersCount = i.AsBarterForOffers.Count,
					ContractsCount = i.Contracts.Count(),
					OnRotation = i.OnRotation,
					OnRotationNow = i.OnRotationNow,

					Description = i.Description,
					AcquiredDate = i.AcquiredDate,
					AcquiredPrice = i.AcquiredPrice != null ? ((decimal)i.AcquiredPrice).ToString("N2") : null,
					Quantity = i.Quantity.ToString("N3"),
					UnitName = i.Unit.Name,
					UnitSymbol = i.Unit.Symbol,
					AddedOn = i.AddedOn,
					ModifiedOn = i.ModifiedOn,
					OffersCount = i.Offers.Count,
					OwnerEmail = i.Owner.Email,
					OwnerName = i.Owner.UserName,
					OwnerPhone = i.Owner.PhoneNumber,

					ItemVisibility = new ItemFormVisibilityModel
					{
						Description = i.ItemVisibility.Description,
						AcquiredDate = i.ItemVisibility.AcquiredDate,
						AcquireDocument = i.ItemVisibility.AcquireDocument,
						AcquiredPrice = i.ItemVisibility.AcquiredPrice,
						AddedOn = i.ItemVisibility.AddedOn,
						ModifiedOn = i.ItemVisibility.ModifiedOn,
						CurrentPrice = i.ItemVisibility.CurrentPrice,
						Location = i.ItemVisibility.Location,
						Offers = i.ItemVisibility.Offers,
						Owner = i.ItemVisibility.Owner,
						Quantity = i.ItemVisibility.Quantity
					}
				})
				.SingleAsync();

			return model;
		}

		public async Task<bool> IsOnMarketAsync(Guid id)
		{
			bool result = await dbContext.Items
				.AnyAsync(i => i.Id == id && i.EndSell != null);

			return result;
		}

		public async Task<PreDeleteItemViewModel> GetForDeleteByIdAsync(Guid id)
		{
			PreDeleteItemViewModel model = await dbContext.Items
				.AsNoTracking()
				.Where(i =>  !i.Deleted)
				.Where(i => i.Id == id)
				.Select(i => new PreDeleteItemViewModel
				{
					Name = i.Name,
					MainPictureUri = i.MainPictureUri,
					Quantity = i.Quantity.ToString("N3"),
					Unit = i.Unit.Symbol,
					Categories = string.Join(", ", i.ItemsCategories.Select(ic => ic.Category.Name))
				})
				.SingleAsync();

			return model;
		}

		public async Task DeleteByIdAsync(Guid id)
		{
			Item item = await dbContext.Items
				.Where(i => !i.Deleted)
				.SingleAsync(i => i.Id == id);

			item.Deleted = true;
			item.ModifiedOn = dateTimeProvider.GetCurrentDateTime();

			await dbContext.SaveChangesAsync();
		}

		public async Task<bool> ExistAsync(Guid id)
		{
			bool result = await dbContext.Items
				.AnyAsync(i => i.Id == id && !i.Deleted);

			return result;
		}

		public async Task<bool> IsAuctionAsync(Guid id)
		{
			bool result = await dbContext.Items
				.AnyAsync(i => i.Id == id && i.IsAuction != null && i.IsAuction == true);

			return result;
		}

		public async Task StopSellByItemIdAsync(Guid id)
		{
			Item item = await dbContext.Items
				.FindAsync(id) ?? throw new ArgumentException(string.Format(ItemNotPresentInDb, id.ToString(), ""));

			item.StartSell = null;
			item.EndSell = null;
			item.ModifiedOn = dateTimeProvider.GetCurrentDateTime();

			await dbContext.SaveChangesAsync();
		}

		public async Task<AuctionFormModel> GetForAuctionUpdateAsync(Guid id)
		{
			AuctionFormModel model = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == id)
				.Select(i => new AuctionFormModel
				{
					MainPictureUri = i.MainPictureUri,
					Name = i.Name,
					StartSell = (DateTime)i.StartSell!,
					EndSell = (DateTime)i.EndSell!,

				})
				.SingleAsync();

			return model;
		}

		public async Task AuctionUpdateAsync(AuctionFormModel model, Guid id)
		{
			Item item = await dbContext.Items
				.FindAsync(id) ?? throw new ArgumentException(string.Format(ItemNotPresentInDb, id.ToString(), ""));

			item.EndSell = model.EndSell;

			await dbContext.SaveChangesAsync();

		}
	}
}
