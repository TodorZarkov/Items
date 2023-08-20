namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Bid;
	using Items.Web.ViewModels.Item;
	using Microsoft.AspNetCore.Mvc;

	public class BidController : BaseController
	{
		private readonly IOfferService offerService;
		private readonly IItemService itemService;

		public BidController(IOfferService offerService, IItemService itemService)
		{
			this.offerService = offerService;
			this.itemService = itemService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			Guid userId = Guid.Parse(User.GetId());

			IEnumerable<AllBidViewModel> myBids =
				await offerService.AllMine(userId);

			IEnumerable<ItemForBarterViewModel> itemsFitForBarter =
				await itemService.MyAvailableForBarter(userId);

			var model = new DataBidViewModel
			{
				Bids = myBids,
				ItemsFitForBarter = itemsFitForBarter
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> All(AllBidViewModel model)
		{

			return RedirectToAction("All", "Bid");
		}

		[HttpGet]
		public async Task<IActionResult> Add(Guid itemId)
		{
			Guid userId = Guid.Parse(User.GetId());

			//todo: implement

			return RedirectToAction("All", "Bid");
		}
	}
}
