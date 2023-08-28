﻿namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Bid;
	using Items.Web.ViewModels.Item;
	using static Items.Common.Enums.AccessModifier;
	using static Items.Common.FormatConstants.DateAndTime;

	using Microsoft.EntityFrameworkCore;

	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class OfferService : IOfferService
	{
		private readonly ItemsDbContext dbContext;

		public OfferService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
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
						HighestBid = o.Item.Offers.Max(io => io.Value).ToString("N2"),
						BarterOffers = o.Item.Offers.Count(io => io.BarterItemId != null),
						Country = o.Item.ItemVisibility.Location == Public &&
								  o.Item.Location.LocationVisibility.Country == Public ? o.Item.Location.Country : null,
						Town = o.Item.ItemVisibility.Location == Public &&
								  o.Item.Location.LocationVisibility.Town == Public ? o.Item.Location.Town : null,
						StartPrice = ((decimal)o.Item.CurrentPrice!).ToString("N2"),
						Unit = o.Item.Unit.Symbol,
						CurrencySymbol = o.Currency.Symbol,
						QuantityLeft = o.Item.ItemVisibility.Quantity == Public ?
										o.Item.Quantity : null
					},

				})
				.ToArrayAsync();


			return bids;
		}


	}
}
