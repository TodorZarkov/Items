namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
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

		[HttpPost]
		public async Task<IActionResult> All(AllBidViewModel model)
		{

			return RedirectToAction("All", "Bid");
		}

		[HttpGet]
		public async Task<IActionResult> Add(Guid itemId)
		{
			Guid userId = Guid.Parse(User.GetId());

			// TODO: implement

			return RedirectToAction("All", "Bid");
		}
	}
}
