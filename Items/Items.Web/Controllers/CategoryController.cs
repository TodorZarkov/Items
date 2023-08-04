namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Category;
	using Items.Web.ViewModels.Item;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class CategoryController : BaseController
	{
		private readonly IItemService itemService;

		public CategoryController(IItemService itemService)
		{
			this.itemService = itemService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Filtered(
			Dictionary<string, List<CategoryFilterViewModel>> model)
		{
			//todo: check the model!!!

			List<int> categoryIds = new List<int>();

			foreach (var key in model.Keys)
			{
				if (key == "All" || key == "Mine")
				{
					categoryIds.AddRange(model[key].Where(m => m.Selected).Select(m => m.Id));
				}

			}


			IEnumerable<AllItemViewModel> items =
				await itemService.GetByCategoryCombinationAsync(categoryIds.ToArray());



			return View(items);
		}
	}
}
