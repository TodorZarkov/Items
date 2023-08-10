namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Sell;
	using Microsoft.AspNetCore.Mvc;

	public class SellController : Controller
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
	}
}
