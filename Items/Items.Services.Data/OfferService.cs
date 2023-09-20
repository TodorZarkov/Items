namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Web.ViewModels.Bid;
	using Items.Web.ViewModels.Item;
	using Items.Web.ViewModels.Base;
	using Items.Services.Common.Interfaces;
	using Items.Services.Data.Models.Offer;
	using Items.Services.Data.Interfaces;
	using static Items.Common.Enums.AccessModifier;
	using static Items.Common.FormatConstants.DateAndTime;
	using static Items.Common.GeneralConstants;
	using static Items.Common.EntityValidationConstants.Item;

	using Microsoft.EntityFrameworkCore;

	using AutoMapper;

	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Items.Common.Enums;

	public class OfferService : IOfferService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IMapper mapper;
		private readonly IDateTimeProvider dateTimeProvider;

		public OfferService(ItemsDbContext dbContext, IMapper mapper, IDateTimeProvider dateTimeProvider)
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
			this.dateTimeProvider = dateTimeProvider;
		}



		public async Task<AllOfferServiceModel> AllMineAsync(Guid userId, QueryFilterModel? queryModel = null)
		{
			var offerQuery = dbContext.Offers
				.AsQueryable()
				.AsNoTracking()
				.Where(o => o.BuyerId == userId);

			string? searchTerm = queryModel?.SearchTerm;
			if (!string.IsNullOrEmpty(searchTerm))
			{
				offerQuery = offerQuery

					.Where(o => o.Item.Name.ToLower().Contains(searchTerm.ToLower())
							|| (o.Id.ToString().ToLower().Contains(searchTerm.ToLower()))
					);
			}

			int[]? categoryIds = queryModel?.CategoryIds;
			if (categoryIds != null && categoryIds.Length != 0)
			{
				offerQuery = offerQuery
					.Where(o => o.Item.ItemsCategories
										.Any(ic => categoryIds.Contains(ic.CategoryId)));
			}

			Sorting? sorting = queryModel?.SortBy;
			if (sorting != null)
			{
				if (sorting == Sorting.Name)
				{
					offerQuery = offerQuery
						.OrderBy(o => o.Item.Name.ToLower());
				}
				else if (sorting == Sorting.PriceAsc)
				{
					offerQuery = offerQuery
						.OrderBy(o => o.Item.CurrentPrice);
				}
				else if (sorting == Sorting.PriceDec)
				{
					offerQuery = offerQuery
						.OrderByDescending(o => o.Item.CurrentPrice);
				}
				else if (sorting == Sorting.Latest)
				{
					offerQuery = offerQuery
						.OrderByDescending(o => o.Item.ModifiedOn);
				}
				else if (sorting == Sorting.EndDate)
				{
					offerQuery = offerQuery
						.OrderByDescending(o => o.Item.EndSell);
				}
				else if (sorting == Sorting.StartDate)
				{
					offerQuery = offerQuery
						.OrderByDescending(o => o.Item.StartSell);
				}


			}

			//Guid? offerId = queryModel?.OfferId;
			//if (offerId is not null)
			//{
			//	offerQuery = offerQuery
			//		.Where(o => o.Id == offerId);
			//}



			var totalOffersCount = await offerQuery.CountAsync();

			int currentPage = queryModel?.CurrentPage ?? DefaultCurrentPage;
			int hitsPerPage = queryModel?.HitsPerPage ?? DefaultHitsPerPage;

			offerQuery = offerQuery
				.Skip((currentPage - 1) * hitsPerPage)
				.Take(hitsPerPage);

			IEnumerable<AllBidViewModel> bids = await offerQuery
				
				//.Where(o => o.Expires > DateTime.UtcNow)
				.Select(o => new AllBidViewModel
				{
					OfferId = o.Id,
					Expires = o.Expires.ToString(BiddingLongUtcDateTime),
					Message = o.Message,
					ValuePerQuantity = o.Value,
					QuantityToBuy = o.Quantity,

					BarterItemId = o.BarterItemId,
					BarterQuantity = o.BarterQuantity.HasValue ? ((decimal)o.BarterQuantity).ToString("N2") : null,
					BarterUnit = o.BarterItem != null ? o.BarterItem.Unit.Symbol : null,
					BarterName = o.BarterItem != null ? o.BarterItem.Name : null,
					BarterPictureUri = o.BarterItem != null ? o.BarterItem.MainPictureUri : null,


					ItemId = o.ItemId,

					Item = new ItemBidViewModel
					{
						Name = o.Item.Name,
						MainPictureUri = o.Item.MainPictureUri,
						HighestBid = o.Item.Offers.Count != 0 ? o.Item.Offers.Max(io => io.Value).ToString("N2") : string.Empty,
						BarterOffers = o.Item.Offers.Count(io => io.BarterItemId != null),
						Country = o.Item.ItemVisibility.Location == Public &&
								  o.Item.Location.LocationVisibility.Country == Public ? o.Item.Location.Country : null,
						Town = o.Item.ItemVisibility.Location == Public &&
								  o.Item.Location.LocationVisibility.Town == Public ? o.Item.Location.Town : null,
						StartPrice = ((decimal)o.Item.CurrentPrice!).ToString("N2"),
						Unit = o.Item.Unit.Symbol,
						CurrencySymbol = o.Currency.Symbol,
						QuantityLeft = o.Item.ItemVisibility.Quantity == Public ?
										o.Item.Quantity : null,
						EndSell = ((DateTime)o.Item.EndSell!).ToString(BiddingLongUtcDateTime)
					},

				})
				.ToArrayAsync();

			AllOfferServiceModel result = new AllOfferServiceModel()
			{
				Bids = bids,
				TotalOffersCount = totalOffersCount
			};

			return result;
		}

		public async Task<AddBidFormModel> GetForCreate(Guid itemId)
		{
			AddBidFormModel model = new AddBidFormModel();

			Item item = await dbContext.Items
				.SingleAsync(i => i.Id == itemId);

			DateTime endSellDate = (DateTime)item.EndSell!;
			model.Expires = endSellDate.AddDays(DefaultOfferExpirationDays);

			model.CurrencyId = (int)item.CurrencyId!;

			model.ItemPictureUri = item.MainPictureUri;


			return model;
		}

		public async Task<decimal?> GetHighestBidByItemIdAsync(Guid itemId)
		{
			var result = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new {
					HighestBid = i.Offers.Count != 0 ? i.Offers.Max(o => o.Value) : 0,
					StartPrice = i.CurrentPrice
				})
				.SingleAsync();

			if (result.HighestBid == 0)
			{
				return result.StartPrice;
			}

			return result.HighestBid;
		}

		public async Task<decimal?> GetHighestBidByOfferIdAsync(Guid id)
		{
			var result = await dbContext.Offers
				.Where(o => o.Id == id)
				.Where(o => !o.Item.Deleted)
				.Select(o => new {
					HighestBid = o.Item.Offers.Count != 0 ? o.Item.Offers.Max(o => o.Value) : 0,
					StartPrice = o.Item.CurrentPrice
				})
				.SingleAsync();

			if (result.HighestBid == 0)
			{
				return result.StartPrice;
			}

			return result.HighestBid;
		}

		public async Task<bool> ExistByItemIdUserId(Guid itemId, Guid userId)
		{
			//todo: consider deleted, expired and so on offers!!!
			bool result = await dbContext.Offers
				.AnyAsync(o => 
								o.Expires >= dateTimeProvider.GetCurrentDateTime() 
								&& o.BuyerId == userId 
								&& o.ItemId == itemId);

			return result;
		}

		public async Task<bool> IsOwnerAsync(Guid id, Guid userId)
		{
			bool result = await dbContext.Offers
				.AnyAsync(o => o.Id == id && o.BuyerId == userId);

			return result;
		}

		public async Task<bool> CanUpdate(Guid id)
		{
			bool result = await dbContext.Offers.AnyAsync(o => o.Id == id &&
														  !o.Item.Deleted &&
														  o.Item.EndSell != null &&
														  o.Item.EndSell > dateTimeProvider.GetCurrentDateTime() &&
														  o.Item.Quantity >= (decimal)QuantityMinValue &&
														  o.Item.IsAuction != null &&
														  o.Item.IsAuction == true);

			return result;
		}

		public async Task<decimal> SufficientQuantity(Guid id, decimal quantity)
		{
			decimal itemQuantity = await dbContext.Offers
				.Where(o => o.Id == id)
				.Where(o => !o.Item.Deleted)
				.Select(o => o.Item.Quantity)
				.SingleAsync();// TODO: seller must have an option to restrict the quantity threshold!!!
							   // todo: globally, quantity must be integer and the measurement units must be added

			return itemQuantity - quantity;
		}



		public async Task<Guid> CreateAsync(AddBidFormModel model, Guid itemId, Guid userId)
		{
			Offer offer = mapper.Map<Offer>(model);
			offer.ItemId = itemId;
			offer.BuyerId = userId;

			dbContext.Offers.Add(offer);
			await dbContext.SaveChangesAsync();

			return offer.Id;
		}

		public async Task EditAsync(Guid id, EditBidFormModel model)
		{
			Offer? offer = await dbContext.Offers.FindAsync(id) ?? throw new ArgumentException($"Invalid offer id {id}");

			offer.Quantity = model.Quantity;
			offer.Value = model.Value ?? 0;
			if (model.BarterItemId == null || model.BarterQuantity == null)
			{
				offer.BarterItemId = null;
				offer.BarterQuantity = null;
			}
			else
			{
				offer.BarterItemId = model.BarterItemId;
				offer.BarterQuantity = model.BarterQuantity;
			}

			await dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			Offer? offer = await dbContext.Offers.FindAsync(id);
			if (offer == null)
			{
				return;
			}

			dbContext.Offers.Remove(offer);

			await dbContext.SaveChangesAsync();
		}
	}
}
