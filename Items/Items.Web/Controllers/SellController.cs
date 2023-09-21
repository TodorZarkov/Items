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

	public class SellController : BaseController
	{
		private readonly IItemService itemService;

		public SellController(IItemService itemService)
		{
			this.itemService = itemService;
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
					RedirectToAction("All", "Sell");
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
	}
}
