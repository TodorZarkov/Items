namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.Offer;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Bid;
	using Items.Web.ViewModels.Base;
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
		public async Task<IActionResult> All(QueryFilterModel? queryModel = null)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());

				AllBidServiceModel model = await offerService.AllMineAsync(userId, queryModel);

				model.ItemsFitForBarter = await itemService.MyAvailableForBarterAsync(userId);


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
			try
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

				bool offerExist = await offerService.ExistByItemIdUserId(itemId, userId);
				if (offerExist)
				{
					TempData[InformationMessage] = "Update your Offer here!";
					return RedirectToAction("All", "Bid");
				}

				AddBidFormModel model = await offerService.GetForCreateAsync(itemId);
				model.AvailableBarters =
					await itemService.MyAvailableForBarterAsync(userId);
				model.AvailableCurrencies =
					await currencyService.AllForSelectAsync();

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}

		}

		[HttpPost]
		public async Task<IActionResult> Add(Guid itemId, AddBidFormModel model)
		{
			try
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

				bool offerExist = await offerService.ExistByItemIdUserId(itemId, userId);
				if (offerExist)
				{
					TempData[InformationMessage] = "Update your Offer here!";
					return RedirectToAction("All", "Bid");
				}

				// todo: fix potential probing to review hidden quantity. Consider changing quantity to int and populating more measurement units approach...
				decimal quantityLeft = await itemService.SufficientQuantity(itemId, model.Quantity);
				if (quantityLeft < 0m)
				{
					ModelState.AddModelError(nameof(model.Quantity), string.Format(InsufficientQuantity, quantityLeft + model.Quantity));
				}

				DateTime endAuction = (DateTime)(await itemService.GetEndSellDateTime(itemId));
				bool isInvalidExpirationDate =
					model.Expires < endAuction.AddDays(DefaultOfferExpirationDays);
				if (isInvalidExpirationDate)
				{
					ModelState.AddModelError(nameof(model.Expires), string.Format(InvalidExpirationDate, endAuction.AddDays(DefaultOfferExpirationDays)));
				}

				decimal highestBid = (decimal)await offerService.GetHighestBidByItemIdAsync(itemId);
				bool isValidBidValue = ((model.Value ?? 0) - highestBid >= (decimal)ValueMinStep) || (model.BarterItemId.HasValue && model.BarterQuantity.HasValue);
				if (!isValidBidValue)
				{
					ModelState.AddModelError(nameof(model.Value), string.Format(InvalidBidValue, highestBid, ValueMinStep));
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



				if (!ModelState.IsValid || quantityLeft < 0m || isInvalidExpirationDate || !isValidBidValue || !isValidCurrency || itemCurrencyId != model.CurrencyId || !isValidBarterItem )
				{
					model.AvailableBarters =
					await itemService.MyAvailableForBarterAsync(userId);
					model.AvailableCurrencies =
						await currencyService.AllForSelectAsync();

					return View(model);
				}

				Guid offerId = await offerService.CreateAsync(model, itemId, userId);
				TempData[SuccessMessage] = "Offer Added Successfully!";

				return RedirectToAction("All", "Bid");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}

		}


		[HttpPost]
		public async Task<IActionResult> Edit(Guid id, EditBidFormModel model, [FromQuery] QueryFilterModel? queryModel = null)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());

				bool isMyOffer = await offerService.IsOwnerAsync(id, userId);
				if (!isMyOffer)
				{
					TempData[ErrorMessage] = "Cannot Edit this Offer!";
					return RedirectToAction("All", "Bid");
				}
				bool canUpdate = await offerService.CanUpdate(id);
				if (!canUpdate)
				{
					TempData[InformationMessage] = "Cannot update this Offer. The Auction is Closed.";
					return RedirectToAction("All", "Bid");
				}

				// todo: fix potential probing to review hidden quantity. Consider changing quantity to int and populating more measurement units approach...
				decimal quantityLeft = await offerService.SufficientQuantity(id, model.Quantity);
				if (quantityLeft < 0m)
				{
					ModelState.AddModelError("", $"{id} - {string.Format(InsufficientQuantity, quantityLeft + model.Quantity)}");
				}

				decimal highestBid = (decimal)await offerService.GetHighestBidByOfferIdAsync(id);
				bool isValidBidValue = ((model.Value ?? 0) - highestBid >= (decimal)ValueMinStep) || (model.BarterItemId.HasValue && model.BarterQuantity.HasValue);
				if (!isValidBidValue)
				{
					ModelState.AddModelError("", $"{id} - {string.Format(InvalidBidValue, highestBid, ValueMinStep)}");
				}

				bool isValidBarterItem = true;
				if (model.BarterItemId != null && model.BarterQuantity != null)
				{
					isValidBarterItem = await itemService.IsValidBarterAsync(model.BarterItemId, model.BarterQuantity, userId);
					if (!isValidBarterItem)
					{
						ModelState.AddModelError("", $"{id} - {InvalidBarterItemId}");
					}
				}

				if (!ModelState.IsValid || quantityLeft < 0m || !isValidBidValue || !isValidBarterItem)
				{
					var errors = ModelState
						.Where(m => m.Value != null
									&& m.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid
									&& !string.IsNullOrEmpty(m.Key))
						.Select(m => new
						{
							m.Key,
							m.Value!.Errors.First().ErrorMessage
						});
					if (errors != null)
					{
						foreach (var error in errors)
						{
							ModelState.AddModelError("", $"{id} - {error.Key} - {error.ErrorMessage}");
						}
					}

					
					AllBidServiceModel allModel = await offerService.AllMineAsync(userId, queryModel);

					allModel.ItemsFitForBarter = await itemService.MyAvailableForBarterAsync(userId);

					return View("All", allModel);
				}


				await offerService.EditAsync(id, model);
				TempData[SuccessMessage] = "Offer Updated Successfully!";

				return RedirectToAction("All", "Bid", new {queryModel});
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}

		}


		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());

				bool isMyOffer = await offerService.IsOwnerAsync(id, userId);
				if (!isMyOffer)
				{
					TempData[ErrorMessage] = "Cannot Cancel this Offer!";
					return RedirectToAction("All", "Bid");
				}
				bool canUpdate = await offerService.CanUpdate(id);
				if (!canUpdate)
				{
					TempData[InformationMessage] = "Cannot Cancel this Offer. The Auction is Closed.";
					return RedirectToAction("All", "Bid");
				}




				await offerService.DeleteAsync(id);
				TempData[SuccessMessage] = "Offer Canceled Successfully!";

				return RedirectToAction("All", "Bid");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}
	}
}
