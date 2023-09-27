namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Sell;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Base;
	using Items.Services.Data.Models.Item;
	using static Common.EntityValidationErrorMessages.Auction;
	using static Common.NotificationMessages;

	using Microsoft.AspNetCore.Mvc;
	using Items.Services.Common.Interfaces;
	using Items.Services.Data.Models.Offer;

	public class SellController : BaseController
	{
		private readonly IItemService itemService;
		private readonly IDateTimeProvider dateTimeProvider;
		private readonly IOfferService offerService;

		public SellController(IItemService itemService, IDateTimeProvider dateTimeProvider, IOfferService offerService)
		{
			this.itemService = itemService;
			this.dateTimeProvider = dateTimeProvider;
			this.offerService = offerService;
		}

		public async Task<IActionResult> All(QueryFilterModel? queryModel = null)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				AllSellServiceModel model = await itemService.MyAllOnMarketAsync(userId, queryModel);

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAuthorized = await itemService.IsOwnerAsync(id, userId);
				if (!isAuthorized)
				{
					return RedirectToAction("All", "Item");
				}

				bool exists = await itemService.ExistAsync(id);
				if (!exists)
				{
					TempData[InformationMessage] = "Item has already been removed!";
					return RedirectToAction("Mine", "Item");
				}

				bool isAuction = await itemService.IsAuctionAsync(id);
				if (!isAuction)
				{
					TempData[InformationMessage] = "Is Not An Auction, You Can Edit Regular.";
					return RedirectToAction("Edit", "Item", new { id });
				}

				bool isOnMarket = await itemService.IsOnMarketAsync(id);
				if (!isOnMarket && isAuction)
				{
					TempData[ErrorMessage] = "Please, finish the Auction First.";
					return RedirectToAction("All", "Sell");
				}


				AuctionFormModel model = await itemService.GetForAuctionUpdateAsync(id);


				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpPost]
		public async Task<IActionResult> Edit(AuctionFormModel model, Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAuthorized = await itemService.IsOwnerAsync(id, userId);
				if (!isAuthorized)
				{
					TempData[ErrorMessage] = "You must be owner to edit!";
					return RedirectToAction("Mine", "Item");
				}

				bool exists = await itemService.ExistAsync(id);
				if (!exists)
				{
					TempData[InformationMessage] = "Item has already been removed!";
					return RedirectToAction("Mine", "Item");
				}


				bool isAuction = await itemService.IsAuctionAsync(id);
				if (!isAuction)
				{
					TempData[InformationMessage] = "Is Not An Auction, You Can Edit Regular.";
					return RedirectToAction("Edit", "Item", new { id });
				}

				bool isOnMarket = await itemService.IsOnMarketAsync(id);
				if (!isOnMarket && isAuction)
				{
					TempData[ErrorMessage] = "Please, finish the Auction First.";
					return RedirectToAction("All", "Sell");
				}

				AuctionFormModel oldModel = await itemService.GetForAuctionUpdateAsync(id);
				if (model.EndSell.Date < oldModel.EndSell.Date)
				{
					ModelState.AddModelError(nameof(model.EndSell), string.Format(InvalidEndAuctionDate, oldModel.EndSell));
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				await itemService.AuctionUpdateAsync(model, id);


				return RedirectToAction("All", "Sell");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpGet]
		public async Task<IActionResult> Stop(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAuthorized = await itemService.IsOwnerAsync(id, userId);
				if (!isAuthorized)
				{
					return RedirectToAction("All", "Item");
				}

				bool exists = await itemService.ExistAsync(id);
				if (!exists)
				{
					TempData[InformationMessage] = "Item has already been removed!";
					return RedirectToAction("Mine", "Item");
				}

				

				await itemService.StopSellByItemIdAsync(id);
				TempData[InformationMessage] = "Sell stopped successfully.";
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}

			return RedirectToAction("All", "Sell");
		}


		[HttpGet]
		public async Task<IActionResult> Offers(Guid id, QueryFilterModel? queryModel = null)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAuthorized = await itemService.IsOwnerAsync(id, userId);
				if (!isAuthorized)
				{
					return RedirectToAction("All", "Item");
				}

				bool exists = await itemService.ExistAsync(id);
				if (!exists)
				{
					TempData[InformationMessage] = "Item has already been removed!";
					return RedirectToAction("Mine", "Item");
				}

				bool isAuction = await itemService.IsAuctionAsync(id);
				DateTime? endSell = await itemService.GetEndSellDateTime(id);
				if (!isAuction || !endSell.HasValue)
				{
					TempData[InformationMessage] = "The Item is not on Auction any longer.";
					return RedirectToAction("All", "Sell");
				}

				if ((DateTime)endSell >= dateTimeProvider.GetCurrentDateTime())
				{
					TempData[InformationMessage] = "The  Auction is not finished yet.";
					return RedirectToAction("All", "Sell");
				}
				
				int offersLeft = await offerService.RemoveExpiredByItemId(id);
				if (offersLeft <= 0)
				{
					await itemService.StopSellByItemIdAsync(id);
					TempData[InformationMessage] = "All Offers has expired. Auction Stopped!";
					return RedirectToAction("All", "Sell");
				}

				AllOfferServiceModel model = await offerService.AllByItemIdAsync(id, queryModel);


				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}

		}

		[HttpGet]
		public async Task<IActionResult> Accept(Guid id)
		{

			return RedirectToAction("Offers", "Sell", new { id = TempData["itemId"] });
		}
	}
}
