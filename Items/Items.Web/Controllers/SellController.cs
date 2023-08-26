namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Sell;
	using static Common.NotificationMessages;

	using Microsoft.AspNetCore.Mvc;
	using Items.Web.Infrastructure.Extensions;

	public class SellController : BaseController
	{
		private readonly IItemService itemService;

		public SellController(IItemService itemService)
		{
			this.itemService = itemService;
		}

		public async Task<IActionResult> All()
		{
			Guid userId = Guid.Parse(User.GetId());
			IEnumerable<AllSellViewModel> model = await itemService.MyAllOnMarket(userId);

			return View(model);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isAuthorized = await itemService.IsAuthorizedAsync(id, userId);
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

			bool isOnMarket = await itemService.IsOnMarketAsync(id);
			if (!isOnMarket)
			{
				TempData[InformationMessage] = "Item Is Not On The  Market!";
				return RedirectToAction("Mine", "Item");
			}

			bool isAuction = await itemService.IsAuctionAsync(id);
			if (!isAuction)
			{
				TempData[InformationMessage] = "Is Not An Auction, You Can Edit Regular.";
				return RedirectToAction("Edit", "Item");
			}

			AuctionFormModel model = await itemService.GetForAuctionUpdateAsync(id);


			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> Edit(AuctionFormModel model, Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isAuthorized = await itemService.IsAuthorizedAsync(id, userId);
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

			bool isOnMarket = await itemService.IsOnMarketAsync(id);
			if (!isOnMarket)
			{
				TempData[InformationMessage] = "Item Is Not On The  Market!";
				return RedirectToAction("Mine", "Item");
			}

			bool isAuction = await itemService.IsAuctionAsync(id);
			if (!isAuction)
			{
				TempData[InformationMessage] = "Is Not An Auction, You Can Edit Regular.";
				return RedirectToAction("Edit", "Item");
			}

			//todo: model check

			await itemService.AuctionUpdateAsync(model, id);


			return RedirectToAction("All", "Sell");
		}
	}
}
