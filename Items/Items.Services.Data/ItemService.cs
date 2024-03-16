namespace Items.Services.Data
{
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;


	using static Items.Common.EntityDbErrorMessages.Item;
	using static Items.Common.FormatConstants.DateAndTime;
	using static Items.Common.Enums.AccessModifier;
	using static Items.Common.EntityValidationConstants.Item;
	using static Items.Common.GeneralConstants;
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Home;
	using Items.Web.ViewModels.Item;
	using Items.Web.ViewModels.Sell;
	using Items.Services.Common.Interfaces;
	using Items.Data.Models;
	using Items.Web.ViewModels.Location;
	using Items.Web.ViewModels.Base;
	using Items.Services.Data.Models.Item;
	using Items.Common.Enums;
	using AutoMapper;
	using System.Reflection.Metadata.Ecma335;
	using Items.Services.Data.Models.File;
	using Microsoft.AspNetCore.Http;
	using static Items.Common.EntityValidationConstants;

	public class ItemService : IItemService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IHelper helper;
		private readonly IDateTimeProvider dateTimeProvider;
		private readonly IMapper mapper;
		private readonly IFileService fileService;

		public ItemService(ItemsDbContext dbContext, IHelper helper, IDateTimeProvider dateTimeProvider, IMapper mapper, IFileService fileService)
		{
			this.dbContext = dbContext;
			this.helper = helper;
			this.dateTimeProvider = dateTimeProvider;
			this.mapper = mapper;
			this.fileService = fileService;
		}

		public async Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems)
		{
			IndexViewModel[] items = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.EndSell != null && i.EndSell > dateTimeProvider.GetCurrentDateTime() && i.Quantity > (decimal)QuantityMinValue)
				.OrderByDescending(i => i.StartSell)
				.Take(numberOfItems)
				.Select(i => new IndexViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureId = i.MainPictureId,
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

		public async Task<IEnumerable<OnRotationViewModel>> GetDailyRotationsAsync(Guid userId)
		{
			IEnumerable<OnRotationViewModel> currentItemRotation = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.OwnerId == userId)
				.Where(i => i.OnRotation && i.OnRotationNow)
				.Where(i => !i.EndSell.HasValue)
				.Where(i => i.Quantity > 0)
				.Select(i => new OnRotationViewModel
				{
					Id = i.Id,
					MainPictureId = i.MainPictureId,
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
			for (int i = 0; i < allItemRotation.Length; i++)
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




		public async Task<AllItemServiceModel> GetAllAsync(Guid? userId = null, QueryFilterModel? queryModel = null)
		{
			var itemsQuery = dbContext.Items.AsQueryable();
			itemsQuery = itemsQuery
				.Where(i => !i.Deleted)
				.AsNoTracking();

			string? searchTerm = queryModel?.SearchTerm;
			if (!string.IsNullOrEmpty(searchTerm))
			{
				itemsQuery = itemsQuery
					.Where(i => i.Name.ToLower().Contains(searchTerm.ToLower()) ||
								(i.Description != null && i.Description.ToLower().Contains(searchTerm.ToLower())) ||
								i.Location.Name.ToLower().Contains(searchTerm.ToLower()) ||
								i.Place.Name.ToLower().Contains(searchTerm.ToLower()));
			}

			int[]? categoryIds = queryModel?.CategoryIds;
			if (categoryIds != null && categoryIds.Length != 0)
			{
				itemsQuery = itemsQuery
					.Where(i => i.ItemsCategories.Any(ic => categoryIds.Contains(ic.CategoryId)));
			}

			Criteria[]? criteria = queryModel?.Criteria;
			if (criteria == null || criteria.Length == 0)
			{
				itemsQuery = itemsQuery
				.Where(i => i.OwnerId == userId
						|| i.EndSell != null && i.EndSell > dateTimeProvider.GetCurrentDateTime() && i.Quantity > (decimal)QuantityMinValue);
			}
			else
			{
				if (criteria.Contains(Criteria.Mine) && !criteria.Contains(Criteria.NotMine))
				{
					itemsQuery = itemsQuery
					.Where(i => i.OwnerId == userId);
				}

				if (criteria.Contains(Criteria.NotMine) && !criteria.Contains(Criteria.Mine))
				{
					itemsQuery = itemsQuery
						.Where(i => i.OwnerId != userId &&
									i.EndSell != null &&
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue);
				}

				if (criteria.Contains(Criteria.NotMine) && criteria.Contains(Criteria.Mine))
				{
					itemsQuery = itemsQuery
						.Where(i => i.OwnerId == userId ||
									i.EndSell != null &&
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue);
				}



				if (criteria.Contains(Criteria.OnSale) && !criteria.Contains(Criteria.Auctions))
				{
					itemsQuery = itemsQuery
						.Where(i => (
									i.EndSell != null &&
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue) &&
									!(i.IsAuction != null && (bool)i.IsAuction!));
				}

				if (criteria.Contains(Criteria.OnSale) && criteria.Contains(Criteria.Auctions))
				{
					itemsQuery = itemsQuery
						.Where(i => (
									i.EndSell != null &&
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue));
				}

				if (!criteria.Contains(Criteria.OnSale) && criteria.Contains(Criteria.Auctions))
				{
					itemsQuery = itemsQuery
						.Where(i => (
									i.EndSell != null &&
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue) &&
									(i.IsAuction != null && (bool)i.IsAuction!));
				}



			}

			Sorting? sorting = queryModel?.SortBy;
			if (sorting != null)
			{
				if (sorting == Sorting.Name)
				{
					itemsQuery = itemsQuery
						.OrderBy(i => i.Name.ToLower());
				}
				else if (sorting == Sorting.PriceDec)
				{
					itemsQuery = itemsQuery
						.OrderByDescending(i => i.Offers.Max(o => o.Value))
						.ThenByDescending(i => i.CurrentPrice)
						.ThenByDescending(i => i.AcquiredPrice);
				}
				else if (sorting == Sorting.PriceAsc)
				{
					itemsQuery = itemsQuery
						.OrderBy(i => i.Offers.Max(o => o.Value))
						.ThenBy(i => i.CurrentPrice)
						.ThenBy(i => i.AcquiredPrice);
				}
				else if (sorting == Sorting.Latest)
				{
					itemsQuery = itemsQuery
						.OrderByDescending(i => i.ModifiedOn);
				}

			}

			var totalItemsCount = itemsQuery.Count();


			int currentPage = queryModel?.CurrentPage ?? DefaultCurrentPage;
			int hitsPerPage = queryModel?.HitsPerPage ?? DefaultHitsPerPage;
			
			itemsQuery = itemsQuery
				.Skip((currentPage - 1) * hitsPerPage)
				.Take(hitsPerPage);

			var items = await itemsQuery
				.Select(i => new AllItemViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureId = i.MainPictureId,

					IsMine = userId == i.OwnerId,
					Quantity = userId == i.OwnerId ? i.Quantity.ToString("N2") : null,
					Unit = userId == i.OwnerId ? i.Unit.Symbol : null,

					CurrentPrice = !i.CurrentPrice.HasValue ? "No Price Set" : ((decimal)i.CurrentPrice).ToString("N2"),
					CurrencySymbol =
						!i.CurrentPrice.HasValue ||
						i.Currency == null
						? "" : i.Currency.Symbol,

					IsAuction =
								i.IsAuction != null
								&& (bool)i.IsAuction
								&& i.EndSell.HasValue
								&& i.EndSell > dateTimeProvider.GetCurrentDateTime()
								&& i.Quantity > (decimal)QuantityMinValue,

					IsOnMarket =
								i.EndSell.HasValue
								&& i.EndSell > dateTimeProvider.GetCurrentDateTime()
								&& i.Quantity > (decimal)QuantityMinValue,

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

					BarterOffers = i.Offers.Count(o => o.BarterItemId != null)
				})
				.ToArrayAsync();


			AllItemServiceModel result = new AllItemServiceModel()
			{
				Items = items,
				TotalItemsCount = totalItemsCount
			};

			return result;
		}

		public async Task<MineItemServiceModel> GetMineAsync(Guid userId, QueryFilterModel? queryModel = null)
		{
			var itemsQuery = dbContext.Items.AsQueryable();
			itemsQuery = itemsQuery
				.Where(i => !i.Deleted)
				.Where(i => i.OwnerId == userId)
				.AsNoTracking();

			string? searchTerm = queryModel?.SearchTerm;
			if (!string.IsNullOrEmpty(searchTerm))
			{
				itemsQuery = itemsQuery
					.Where(i => i.Name.ToLower().Contains(searchTerm.ToLower()) ||
								(i.Description != null && i.Description.ToLower().Contains(searchTerm.ToLower())) ||
								i.Location.Name.ToLower().Contains(searchTerm.ToLower()) ||
								i.Place.Name.ToLower().Contains(searchTerm.ToLower()));
			}
			
			int[]? categoryIds = queryModel?.CategoryIds;
			if (categoryIds != null && categoryIds.Length != 0)
			{
				itemsQuery = itemsQuery
					.Where(i => i.ItemsCategories.Any(ic => categoryIds.Contains(ic.CategoryId)));
			}

			Criteria[]? criteria = queryModel?.Criteria;
			if (criteria == null || criteria.Length == 0)
			{
				itemsQuery = itemsQuery
				.Where(i => i.OwnerId == userId
						|| (i.EndSell != null && 
							i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
							i.Quantity > (decimal)QuantityMinValue));
			}
			else
			{
				itemsQuery = itemsQuery
				.Where(i => i.OwnerId == userId);
				if (criteria.Contains(Criteria.OnSale) && !criteria.Contains(Criteria.Auctions))
				{
					itemsQuery = itemsQuery
						.Where(i => (
									i.EndSell != null &&
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue) &&
									!(i.IsAuction != null && (bool)i.IsAuction!));
				}

				if (criteria.Contains(Criteria.OnSale) && criteria.Contains(Criteria.Auctions))
				{
					itemsQuery = itemsQuery
						.Where(i => (
									i.EndSell != null &&
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue));
				}

				if (!criteria.Contains(Criteria.OnSale) && criteria.Contains(Criteria.Auctions))
				{
					itemsQuery = itemsQuery
						.Where(i => (
									i.EndSell != null &&
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue) &&
									(i.IsAuction != null && (bool)i.IsAuction!));
				}



			}

			Sorting? sorting = queryModel?.SortBy;
			if (sorting != null)
			{
				if (sorting == Sorting.Name)
				{
					itemsQuery = itemsQuery
						.OrderBy(i => i.Name.ToLower());
				}
				else if (sorting == Sorting.PriceDec)
				{
					itemsQuery = itemsQuery
						.OrderByDescending(i => i.Offers.Max(o => o.Value))
						.ThenByDescending(i => i.CurrentPrice)
						.ThenByDescending(i => i.AcquiredPrice);
				}
				else if (sorting == Sorting.PriceAsc)
				{
					itemsQuery = itemsQuery
						.OrderBy(i => i.Offers.Max(o => o.Value))
						.ThenBy(i => i.CurrentPrice)
						.ThenBy(i => i.AcquiredPrice);
				}
				else if (sorting == Sorting.Latest)
				{
					itemsQuery = itemsQuery
						.OrderByDescending(i => i.ModifiedOn);
				}

			}

			Guid? locationId = queryModel?.LocationId;
			if (locationId is not null)
			{
				itemsQuery = itemsQuery
					.Where(i => i.LocationId == locationId);
			}

			int? placeId = queryModel?.PlaceId;
			if (placeId is not null)
			{
				itemsQuery = itemsQuery
					.Where(i => i.PlaceId == placeId);
			}


			var totalItemsCount = await itemsQuery.CountAsync();


			int currentPage = queryModel?.CurrentPage ?? DefaultCurrentPage;
			int hitsPerPage = queryModel?.HitsPerPage ?? DefaultHitsPerPage;

			itemsQuery = itemsQuery
				.Skip((currentPage - 1) * hitsPerPage)
				.Take(hitsPerPage);

			var items = await itemsQuery
				.Select(i => new MyItemViewModel
				{
					Id = i.Id,
					Name = i.Name,
					MainPictureId = i.MainPictureId,

					Quantity = userId == i.OwnerId ? i.Quantity.ToString("N2") : null,
					Unit = userId == i.OwnerId ? i.Unit.Symbol : null,

					IsAuction = 
								i.IsAuction != null 
								&& (bool)i.IsAuction 
								&& i.EndSell.HasValue 
								&& i.EndSell > dateTimeProvider.GetCurrentDateTime() 
								&& i.Quantity > (decimal)QuantityMinValue,

					IsOnMarket = 
								i.EndSell.HasValue 
								&& i.EndSell > dateTimeProvider.GetCurrentDateTime() 
								&& i.Quantity > (decimal)QuantityMinValue,


					Categories = i.ItemsCategories
						.Where(ic => ic.ItemId == i.Id)
						.Select(ic => ic.Category.Name)
						.ToArray(),

					Offers = i.Offers.Count,

					Location = i.Location.Name,

					Place = i.Place.Name,
				})
				.ToArrayAsync();


			MineItemServiceModel result = new MineItemServiceModel()
			{
				Items = items,
				TotalItemsCount = totalItemsCount
			};


			return result;
		}



		public async Task<IEnumerable<ItemForBarterViewModel>> MyAvailableForBarterAsync(Guid userId)
		{
			IEnumerable<ItemForBarterViewModel> allItemsForBarter =
				await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.OwnerId == userId)
				.Where(i => i.Quantity > i.AsBarterForOffers.Sum(bo => bo.BarterQuantity)) //  TODO: observe the equality when dealing with decimal!!!!!
				.Select(i => new ItemForBarterViewModel
				{
					Id = i.Id,
					MainPictureId = i.MainPictureId,
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

		public async Task<AllSellServiceModel> MyAllOnMarketAsync(Guid userId, QueryFilterModel? queryModel = null)
		{
			var sellsQuery = dbContext.Items.AsQueryable();
			sellsQuery = sellsQuery
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.OwnerId == userId)
				.Where(i => i.EndSell.HasValue); //&& i.EndSell > dateTimeProvider.GetCurrentDateTime() && i.Quantity > (decimal)QuantityMinValue)



			string? searchTerm = queryModel?.SearchTerm;
			if (!string.IsNullOrEmpty(searchTerm))
			{
				sellsQuery = sellsQuery
					.Where(i => i.Name.ToLower().Contains(searchTerm.ToLower()) ||
								(i.Description != null && i.Description.ToLower().Contains(searchTerm.ToLower())) ||
								i.Location.Name.ToLower().Contains(searchTerm.ToLower()) ||
								i.Place.Name.ToLower().Contains(searchTerm.ToLower()));
			}

			int[]? categoryIds = queryModel?.CategoryIds;
			if (categoryIds != null && categoryIds.Length != 0)
			{
				sellsQuery = sellsQuery
					.Where(i => i.ItemsCategories.Any(ic => categoryIds.Contains(ic.CategoryId)));
			}

			Criteria[]? criteria = queryModel?.Criteria;
			if (criteria != null && criteria.Length != 0)
			{
				if (criteria.Contains(Criteria.OnSale) && !criteria.Contains(Criteria.Auctions))
				{
					sellsQuery = sellsQuery
						.Where(i => (
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue) &&
									!(i.IsAuction != null && (bool)i.IsAuction!));
				}
				else if (criteria.Contains(Criteria.OnSale) && criteria.Contains(Criteria.Auctions))
				{
					sellsQuery = sellsQuery
						.Where(i => (
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue));
				}
				else if (!criteria.Contains(Criteria.OnSale) && criteria.Contains(Criteria.Auctions))
				{
					sellsQuery = sellsQuery
						.Where(i => (
									i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
									i.Quantity > (decimal)QuantityMinValue) &&
									(i.IsAuction != null && (bool)i.IsAuction!));
				}

			}

			Sorting? sorting = queryModel?.SortBy;
			if (sorting != null)
			{
				if (sorting == Sorting.Name)
				{
					sellsQuery = sellsQuery
						.OrderBy(i => i.Name.ToLower());
				}
				else if (sorting == Sorting.PriceDec)
				{
					sellsQuery = sellsQuery
						.OrderByDescending(i => i.CurrentPrice);
				}
				else if (sorting == Sorting.PriceAsc)
				{
					sellsQuery = sellsQuery
						.OrderBy(i => i.CurrentPrice);
				}
				else if (sorting == Sorting.Latest)
				{
					sellsQuery = sellsQuery
						.OrderByDescending(i => i.ModifiedOn);
				}
				else if (sorting == Sorting.Type)
				{
					sellsQuery = sellsQuery
						.OrderByDescending(i => i.IsAuction != null && (bool)i.IsAuction);
				}
				else if (sorting == Sorting.EndDate)
				{
					sellsQuery = sellsQuery
						.OrderByDescending(i => i.EndSell);
				}
				else if (sorting == Sorting.StartDate)
				{
					sellsQuery = sellsQuery
						.OrderByDescending(i => i.StartSell);
				}

			}

			
			var totalSellsCount = await sellsQuery.CountAsync();


			int currentPage = queryModel?.CurrentPage ?? DefaultCurrentPage;
			int hitsPerPage = queryModel?.HitsPerPage ?? DefaultHitsPerPage;

			sellsQuery = sellsQuery
				.Skip((currentPage - 1) * hitsPerPage)
				.Take(hitsPerPage);



			var sells = await sellsQuery
				.Select(i => new AllSellViewModel
				{
					ItemId = i.Id,
					Name = i.Name,
					MainPictureId = i.MainPictureId,
					Location = i.Location.Name,
					Place = i.Place.Name,
					Quantity = i.Quantity,
					Unit = i.Unit.Symbol,
					CurrentPrice = ((decimal)i.CurrentPrice!).ToString("N2"),
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

			var result = new AllSellServiceModel()
			{
				Sells = sells,
				TotalSellsCount = totalSellsCount
			};

			return result;
		}


		public async Task<ItemEditFormModel> GetByIdForEditAsync(Guid itemId)
		{
			// TODO: instead of many queries, use Include! In all similar places.
			// TODO: implement auto mapper in all similar places!

			Items.Data.Models.Item item = await dbContext.Items
				.Where(i => !i.Deleted)
				.SingleAsync(i => i.Id == itemId);

			int[] categoryIds = await dbContext.ItemsCategories
				.Where(ic => ic.ItemId == itemId)
				.Select(ic => ic.CategoryId)
				.ToArrayAsync();

			ItemVisibility itemVisibility = await dbContext.ItemVisibilities
				.SingleAsync(iv => iv.Item.Id == itemId);

			ItemEditFormModel model = new ItemEditFormModel
			{
				Name = item.Name,
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
				MainImageId = item.MainPictureId,

				ItemVisibility = new ItemFormVisibilityModel
				{
					Description = itemVisibility.Description,
					AcquiredDate = itemVisibility.AcquiredDate,
					AcquireDocument = itemVisibility.AcquireDocument,
					AcquiredPrice = itemVisibility.AcquiredPrice,
					AddedOn = itemVisibility.AddedOn,
					ModifiedOn = itemVisibility.ModifiedOn,
					Location = itemVisibility.Location,
					Offers = itemVisibility.Offers,
					Owner = itemVisibility.Owner,
					Quantity = itemVisibility.Quantity
				}
			};

			

			return model;
		}

		public async Task<ItemViewModel> GetByIdForViewAsync(Guid itemId)
		{
			ItemViewModel model = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ItemViewModel
				{
					Id = i.Id,
					Images = i.ItemPictures
						.OrderByDescending(ip => ip.FileId == i.MainPictureId)
						.Select(ip => ip.FileId)
						.ToArray(),
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
					AcquiredPrice = i.ItemVisibility.AcquiredPrice == Public ?
						i.AcquiredPrice != null ? ((decimal)i.AcquiredPrice).ToString("N2") : null : null,
					AddedOn = i.ItemVisibility.AddedOn == Public ? i.AddedOn : null,
					ModifiedOn = i.ItemVisibility.ModifiedOn == Public ? i.ModifiedOn : null,
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
						Location = i.ItemVisibility.Location,
						Offers = i.ItemVisibility.Offers,
						Owner = i.ItemVisibility.Owner,
						Quantity = i.ItemVisibility.Quantity
					},

					Location = i.ItemVisibility.Location == Public ? new AllLocationViewModel
					{
						Name = i.Location.LocationVisibility.Name == Public ? i.Location.Name : null,
						Address = i.Location.LocationVisibility.Address == Public ? i.Location.Address : null,
						Description = i.Location.LocationVisibility.Description == Public ? i.Location.Description : null,
						Border = i.Location.LocationVisibility.Border == Public && i.Location.Border != null ? i.Location.Border.ToString() : null,
						Country = i.Location.LocationVisibility.Country == Public ? i.Location.Country : null,
						GeoLocation = i.Location.LocationVisibility.GeoLocation == Public && i.Location.GeoLocation != null ? i.Location.GeoLocation.ToString() : null,
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
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ItemViewModel
				{
					Id = i.Id,
					Images = i.ItemPictures
						.OrderByDescending(ip => ip.FileId == i.MainPictureId)
						.Select(ip => ip.FileId)
						.ToArray(),
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
						Location = i.ItemVisibility.Location,
						Offers = i.ItemVisibility.Offers,
						Owner = i.ItemVisibility.Owner,
						Quantity = i.ItemVisibility.Quantity
					}
				})
				.SingleAsync();

			return model;
		}

		public async Task<PreDeleteItemViewModel> GetForDeleteByIdAsync(Guid id)
		{
			PreDeleteItemViewModel model = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.Id == id)
				.Select(i => new PreDeleteItemViewModel
				{
					Name = i.Name,
					MainPictureId = i.MainPictureId,
					Quantity = i.Quantity.ToString("N3"),
					Unit = i.Unit.Symbol,
					Categories = string.Join(", ", i.ItemsCategories.Select(ic => ic.Category.Name))
				})
				.SingleAsync();

			return model;
		}

		public async Task<AuctionFormModel> GetForAuctionUpdateAsync(Guid id)
		{
			AuctionFormModel model = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == id)
				.Select(i => new AuctionFormModel
				{
					MainPictureId = i.MainPictureId,
					Name = i.Name,
					StartSell = (DateTime)i.StartSell!,
					EndSell = (DateTime)i.EndSell!,

				})
				.SingleAsync();

			return model;
		}

		public async Task<DateTime?> GetEndSellDateTime(Guid itemId)
		{
			DateTime? result = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => i.EndSell)
				.SingleAsync();

			return result;
		}

		public async Task<int?> GetCurrencyIdAsync(Guid itemId)
		{
			int? result = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => i.CurrencyId)
				.SingleAsync();

			return result;
		}

		public async Task<IEnumerable<Guid>> GetImagesByIdAsync(Guid itemId)
		{
			Guid[] result = await dbContext.FileIdentifiers
				.Where(fi => fi.ItemId == itemId)
				.OrderByDescending(fi => fi.FileId == fi.Item!.MainPictureId)
				.Select(fi => fi.FileId)
				.ToArrayAsync();

			return result;
		}




		public async Task<bool> ExistAsync(Guid id)
		{
			bool result = await dbContext.Items
				.AnyAsync(i => i.Id == id && !i.Deleted);

			return result;
		}

		public async Task<bool> IsOwnerAsync(Guid itemId, Guid userId)
		{
			bool result = await dbContext.Items
				.Where(i => !i.Deleted)
				.AnyAsync(i => i.Id == itemId && i.OwnerId == userId);

			return result;
		}

		public async Task<bool> IsOnMarketAsync(Guid id)
		{
			bool result = await dbContext.Items
				.Where(i => !i.Deleted)
				.AnyAsync(i =>
				i.Id == id &&
				i.EndSell != null &&
				i.EndSell > dateTimeProvider.GetCurrentDateTime() &&
				i.Quantity >= (decimal)QuantityMinValue);

			return result;
		}

		public async Task<bool> IsAuctionAsync(Guid id)
		{
			bool result = await dbContext.Items
				.Where(i => !i.Deleted)
				.AnyAsync(i => 
				i.Id == id 
				&& i.IsAuction != null 
				&& i.IsAuction == true
				);

			return result;
		}

		public async Task<bool> HasQuantity(Guid id)
		{
			bool result = await dbContext.Items
				.AnyAsync(i => i.Id == id && i.Quantity >= (decimal)QuantityMinValue && !i.Deleted);

			return result;
		}

		public async Task<decimal> SufficientQuantity(Guid itemId, decimal quantity)
		{
			decimal itemQuantity = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => i.Quantity)
				.SingleAsync() ;// TODO: seller must have an option to restrict the quantity threshold!!!
												  // todo: globally, quantity must be integer and the measurement units must be supplemented

			return itemQuantity - quantity;
		}

		public async Task<bool> IsValidBarterAsync(Guid? barterItemId, decimal? barterQuantity, Guid userId)
		{
			bool result = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.OwnerId == userId)
				.Where(i => i.Quantity > i.AsBarterForOffers.Sum(bo => bo.BarterQuantity))
				.Select(i => new
				{
					Id = i.Id,
					QuantityCanBarter =
										(i.Quantity -
										(i.AsBarterForOffers.Sum(bo => bo.BarterQuantity).HasValue ?
										(decimal)(i.AsBarterForOffers.Sum(bo => bo.BarterQuantity)!) : decimal.Zero)),
				})
				.Where(res => res.Id == barterItemId)
				.AnyAsync(res => res.QuantityCanBarter >= barterQuantity);

			return result;
		}

		public async Task<bool> ExistBarterItemByOfferIdAsync(Guid offerId)
		{
			Guid? barterId = await dbContext.Offers
				.Where(o => o.Id == offerId)
				.Select(o => o.BarterItemId)
				.SingleAsync();

			if (barterId == null)
			{
				return true;
			}

			bool result = await ExistAsync((Guid)barterId);

			return result;
		}

		public async Task<bool> IsValidMainImageAsync(Guid mainImageId, Guid userId, Guid itemId)
		{
			FileIdentifier? result = await dbContext.FileIdentifiers.FindAsync(mainImageId);
			if (result != null && result.ItemId == itemId && result.OwnerId == userId)
			{
				return true;
			}

			return false;
		}

		public async Task<bool> IsAllowedImagesToDeleteAsync(IEnumerable<Guid> imagesToDelete, Guid mainImageId, Guid userId, Guid itemId)
		{
			if (imagesToDelete.Contains(mainImageId))
			{
				return false;
			}

			int numberOfImagesToDelete = await dbContext.FileIdentifiers
				.Where(fi => imagesToDelete.Contains(fi.FileId))
				.Where(fi => fi.OwnerId == userId)
				.Where(fi => fi.ItemId == itemId)
				.CountAsync();

			if (numberOfImagesToDelete != imagesToDelete.Count())
			{
				return false;
			}

			return true;
		}



		public async Task<Guid> CreateItemAsync(ItemFormModel model, Guid userId)
		{
			Items.Data.Models.Item item = new Items.Data.Models.Item
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
					Description = model.ItemVisibility.Description,
					Location = model.ItemVisibility.Location,
					Offers = model.ItemVisibility.Offers,
					Quantity = model.ItemVisibility.Quantity,
					Owner = model.ItemVisibility.Owner,
				}
			};

			Items.Data.Models.Place? theChosenPlace = await dbContext.Places.FindAsync(model.PlaceId);
			item.LocationId = theChosenPlace!.LocationId;

			foreach (int categoryId in model.CategoryIds)
			{
				ItemCategory itemCategory = new ItemCategory
				{
					CategoryId = categoryId
				};
				item.ItemsCategories.Add(itemCategory);
			}

			//todo: lower the size and rate limits before the file upload itself for further evaluation!!!
			//todo: check the IFormFile for: 
			//- size against zero byte[] (the content length actually)
			//- size against the concrete entity max size limit (for the item that will be the max size for Item picture)
			//- size against the given disk amount to the concrete user
			//- xss (html encode the file name)
			//- extension in the name to match file signature
			//- virus and malware
			//if everything above is fine proceed with the IFileService
			//todo it in Update method!
			List<Guid> pictureIds = new List<Guid>();
			foreach (IFormFile image in model.Images)
			{
				using (var memoryStream = new MemoryStream())
				{
					await image.CopyToAsync(memoryStream);
					Guid pictureId = await fileService.AddAsync(new FileServiceModel
					{
						Bytes = memoryStream.ToArray(),
						Name = image.FileName,
						MimeType = image.ContentType
					});
					pictureIds.Add(pictureId);
					
					FileIdentifier fi = new FileIdentifier
					{
						Item = item,
						FileId = pictureId,
						OwnerId = userId,
						IsPublic = model.EndSell != null && model.EndSell > dateTimeProvider.GetCurrentDateTime()
					};
					item.ItemPictures.Add(fi);
				}
			}
			item.MainPictureId = pictureIds.First();


				dbContext.Items.Add(item);
			await dbContext.SaveChangesAsync();
			await fileService.SaveChangesAsync();
			return item.Id;
		}

		public async Task UpdateItemAsync(ItemEditFormModel model, Guid itemId)
		{
			Items.Data.Models.Item? item = await dbContext.Items
				.Where(i => !i.Deleted && i.Id == itemId)
				.Include(i => i.ItemPictures)
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
			itemVisibility.Description = model.ItemVisibility.Description;
			itemVisibility.Location = model.ItemVisibility.Location;
			itemVisibility.Offers = model.ItemVisibility.Offers;
			itemVisibility.Quantity = model.ItemVisibility.Quantity;
			itemVisibility.Owner = model.ItemVisibility.Owner;


			if (model.EndSell != null && model.EndSell > dateTimeProvider.GetCurrentDateTime())
			{
				foreach (FileIdentifier ip in item.ItemPictures)
				{
					ip.IsPublic = true;
				}
			}

			foreach (IFormFile image in model.Images)
			{
				using (var memoryStream = new MemoryStream())
				{
					await image.CopyToAsync(memoryStream);
					Guid pictureId = await fileService.AddAsync(new FileServiceModel
					{
						Bytes = memoryStream.ToArray(),
						Name = image.FileName,
						MimeType = image.ContentType
					});

					FileIdentifier fi = new FileIdentifier
					{
						ItemId = itemId,
						FileId = pictureId,
						OwnerId = item.OwnerId,
						IsPublic = model.EndSell != null && model.EndSell > dateTimeProvider.GetCurrentDateTime()
					};
					await dbContext.FileIdentifiers.AddAsync(fi);
				}
			}
			item.MainPictureId = model.MainImageId;

			if (model.ImagesToDelete.Any())
			{
				FileIdentifier[] fiToDelete = await dbContext.FileIdentifiers
				.Where(fi => model.ImagesToDelete.Contains(fi.FileId))
				.ToArrayAsync();
				dbContext.FileIdentifiers.RemoveRange(fiToDelete);
				
				await fileService.DeleteManyAsync(model.ImagesToDelete);
			}

			

			await dbContext.SaveChangesAsync();
			await fileService.SaveChangesAsync();
		}

		public async Task DeleteByIdAsync(Guid id)
		{
			Items.Data.Models.Item item = await dbContext.Items
				.Where(i => !i.Deleted)
				.SingleAsync(i => i.Id == id);

			item.Deleted = true;
			item.ModifiedOn = dateTimeProvider.GetCurrentDateTime();

			//todo: to consider deleting the actual pictures or to leave only the main one.
			//todo: to consider deleting the actual entity permanently.

			await dbContext.SaveChangesAsync();
		}

		public async Task StopSellByItemIdAsync(Guid id)
		{
			Items.Data.Models.Item item = await dbContext.Items
				.Where(i => i.Id == id)
				.Include(i => i.Offers)
				.Include(i => i.ItemPictures)
				.SingleAsync();

			item.StartSell = null;
			item.EndSell = null;
			item.ModifiedOn = dateTimeProvider.GetCurrentDateTime();
			item.IsAuction = false;
			item.PromisedQuantity = 0;

			Items.Data.Models.Offer[] offers = await dbContext.Offers
				.Where(o => o.ItemId == id)
				.ToArrayAsync();

			dbContext.Offers.RemoveRange(offers);

			foreach (FileIdentifier ip in item.ItemPictures)
			{
				ip.IsPublic = false;
			}

			await dbContext.SaveChangesAsync();
		}

		public async Task AuctionUpdateAsync(AuctionFormModel model, Guid id)
		{
			Items.Data.Models.Item item = await dbContext.Items
				.FindAsync(id) ?? throw new ArgumentException(string.Format(ItemNotPresentInDb, id.ToString(), ""));

			item.EndSell = model.EndSell;

			await dbContext.SaveChangesAsync();

		}

		public async Task<ItemEditFormModel> CopyFromContract(Guid id, Guid userId)
		{
			ItemEditFormModel model = await dbContext.Contracts
				.Where(c => c.Id == id && c.BuyerId == userId)
				.Select(c => new ItemEditFormModel
				{
					Name = c.ItemName,
					Description = c.ItemDescription,
					AcquiredDate = c.ContractDate,
					AcquiredPrice = c.Price,
					CurrencyId = c.CurrencyId,
					Quantity = c.Quantity,
					UnitId = c.UnitId,
					CurrentImages = c.ItemImages.Select(fi => fi.FileId),
					MainImageId = c.ItemMainPictureId
				})
				.SingleAsync();

			return model;
		}

		
	}


}
