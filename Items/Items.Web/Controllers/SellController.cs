namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Sell;
	using static Common.NotificationMessages;

	using Microsoft.AspNetCore.Mvc;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Base;
	using Items.Services.Data.Models.Item;

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
	}
}
