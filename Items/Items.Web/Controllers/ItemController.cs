namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
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
			var model = await itemService.AllPublic();
			return View(model);
		}
	}
}
