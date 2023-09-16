namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Bid;
	using Items.Web.ViewModels.Item;
	using static Items.Common.NotificationMessages;
	using static Items.Common.EntityValidationErrorMessages.Item;
	using static Items.Common.EntityValidationErrorMessages.Offer;
	using static Items.Common.EntityValidationErrorMessages.Currency;
	using static Items.Common.EntityValidationErrorMessages.Location;
	using static Items.Common.EntityValidationConstants.Offer;
	using static Items.Common.GeneralConstants;

	using Microsoft.AspNetCore.Mvc;

	public class BidController : BaseController
	{
		private readonly IOfferService offerService;
		private readonly IItemService itemService;
		private readonly ICurrencyService currencyService;
		private readonly ILocationService locationService;

		public BidController(
			IOfferService offerService,
			IItemService itemService,
			ICurrencyService currencyService,
			ILocationService locationService)
		{
			this.offerService = offerService;
			this.itemService = itemService;
			this.currencyService = currencyService;
			this.locationService = locationService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());

				IEnumerable<AllBidViewModel> myBids =
					await offerService.AllMineAsync(userId);

				IEnumerable<ItemForBarterViewModel> itemsFitForBarter =
					await itemService.MyAvailableForBarterAsync(userId);

				var model = new DataBidViewModel
				{
					Bids = myBids,
					ItemsFitForBarter = itemsFitForBarter
				};

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}

		}

		

		[HttpGet]
		public async Task<IActionResult> Add(Guid itemId)
		{
			Guid userId = Guid.Parse(User.GetId());

			bool isMyItem = await itemService.IsOwnerAsync(itemId, userId);
			if (isMyItem)
			{
				TempData[ErrorMessage] = "Cannot Bid on your own Item!";
				return RedirectToAction("All", "Item");
			}
			bool isOnMarket = await itemService.IsOnMarketAsync(itemId);
			bool isAuction = await itemService.IsAuctionAsync(itemId);
			if (!isOnMarket || !isAuction)
			{
				TempData[ErrorMessage] = "Cannot Bid on this Item!";
				return RedirectToAction("All", "Item");
			}

			BidFormModel model = await offerService.GetForCreate(itemId);
			model.AvailableBarters =
				await itemService.MyAvailableForBarterAsync(userId);
			model.AvailableCurrencies =
				await currencyService.AllForSelectAsync();
			model.AvailableLocations =
				await locationService.GetForSelectAsync(userId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Guid itemId, BidFormModel model)
		{
			Guid userId = Guid.Parse(User.GetId());

			bool isMyItem = await itemService.IsOwnerAsync(itemId, userId);
			if (isMyItem)
			{
				TempData[ErrorMessage] = "Cannot Bid on your own Item!";
				return RedirectToAction("All", "Item");
			}
			bool isOnMarket = await itemService.IsOnMarketAsync(itemId);
			bool isAuction = await itemService.IsAuctionAsync(itemId);
			if (!isOnMarket || !isAuction)
			{
				TempData[ErrorMessage] = "Cannot Bid on this Item!";
				return RedirectToAction("All", "Item");
			}

			// todo: fix potential probing to review hidden quantity. Consider changing quantity to int and populating more measurement units approach...
			decimal quantityLeft = await itemService.SufficientQuantity(itemId, model.Quantity);
			if (quantityLeft < 0m)
			{
				ModelState.AddModelError(nameof(model.Quantity), string.Format(InsufficientQuantity, quantityLeft + model.Quantity));
			}

			DateTime endAuction =(DateTime)(await itemService.GetEndSellDateTime(itemId));
			bool isInvalidExpirationDate =
				model.Expires < endAuction.AddDays(DefaultOfferExpirationDays);
			if (isInvalidExpirationDate)
			{
				ModelState.AddModelError(nameof(model.Expires), string.Format(InvalidExpirationDate, endAuction.AddDays(DefaultOfferExpirationDays)));
			}

			decimal highestBid = (decimal)await offerService.GetHighestBidByItemIdAsync(itemId);
			bool isValidBidValue = model.Value - highestBid >= (decimal)ValueMinValue;
			if (!isValidBidValue)
			{
				ModelState.AddModelError(nameof(model.Value), string.Format(InvalidBidValue, highestBid, ValueMinValue));
			}

			bool isValidCurrency = await currencyService.ExistsByIdAsync(model.CurrencyId);
			int itemCurrencyId = (int)await itemService.GetCurrencyIdAsync(itemId);
			if (!isValidCurrency || itemCurrencyId != model.CurrencyId)
			{
				ModelState.AddModelError(nameof(model.CurrencyId), InvalidCurrencyId);
			}

			bool isValidBarterItem = true;
			if (model.BarterItemId != null && model.BarterQuantity != null)
			{
				isValidBarterItem = await itemService.IsValidBarterAsync(model.BarterItemId, model.BarterQuantity, userId);
				if (!isValidBarterItem)
				{
					ModelState.AddModelError(nameof(model.BarterItemId), InvalidBarterItemId);
				}
			}

			bool isValidLocation = true;
			if (model.LocationId != null)
			{
				isValidLocation = 
					await locationService.IsAllowedIdAsync((Guid)model.LocationId, userId);
				if (!isValidLocation)
				{
					ModelState.AddModelError(nameof(model.LocationId), InvalidLocationId);
				}
			}


			if (!ModelState.IsValid || quantityLeft < 0m || isInvalidExpirationDate || !isValidBidValue || !isValidCurrency || itemCurrencyId != model.CurrencyId || !isValidBarterItem || !isValidLocation)
			{
				model.AvailableBarters =
				await itemService.MyAvailableForBarterAsync(userId);
				model.AvailableCurrencies =
					await currencyService.AllForSelectAsync();
				model.AvailableLocations =
					await locationService.GetForSelectAsync(userId);

				return View(model);
			}

			Guid offerId = await offerService.CreateAsync(model, itemId, userId);

			return RedirectToAction("All", "Bid");
		}
	}
}
