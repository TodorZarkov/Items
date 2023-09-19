namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Bid;
	using Items.Web.ViewModels.Item;
	using static Items.Common.Enums.AccessModifier;
	using static Items.Common.FormatConstants.DateAndTime;
	using static Items.Common.GeneralConstants;
	using static Items.Common.EntityValidationConstants.Item;

	using Microsoft.EntityFrameworkCore;

	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Items.Data.Models;
	using AutoMapper;
	using Items.Services.Common.Interfaces;

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



		public async Task<IEnumerable<AllBidViewModel>> AllMineAsync(Guid userId)
		{
			IEnumerable<AllBidViewModel> bids = await dbContext.Offers
				.Where(o => o.BuyerId == userId)
				//.Where(o => o.Expires > DateTime.UtcNow)
				.OrderByDescending(o => o.Expires)
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


			return bids;
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
				.AllAsync(o => 
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

	}
}
