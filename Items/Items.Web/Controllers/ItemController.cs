namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Item;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class ItemController : BaseController
	{
		private readonly IItemService itemService;

		public ItemController(IItemService itemService)
		{
			this.itemService = itemService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			IEnumerable<AllItemViewModel> model;

			if (User.Identity?.IsAuthenticated ?? false)
			{
				Guid userId = Guid.Parse(User.GetId());
				model = await itemService.All(userId);
			}
			else
			{
				model = await itemService.AllPublic();
			}
			return View(model);
		}

		public async Task<IActionResult> Mine()
		{
			Guid userId = Guid.Parse(User.GetId());
			IEnumerable<MyItemViewModel> model = await itemService.Mine(userId);

			return View(model);
		}
	}
}
