namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
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
			Dictionary<string, List<CategoryFilterViewModel>> model, string type)
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

			IEnumerable<AllItemViewModel> items;
			
			if (User.Identity?.IsAuthenticated ?? false)
			{
				//todo: can userId be null here???
				Guid userId = Guid.Parse(User.GetId());
				if (type == "Mine")
				{
					items = await itemService
						.GetByCategoriesMineItemsAsync(categoryIds.ToArray(), userId);
				}
				else if (type == "All")
				{
					items = await itemService
						.GetByCategoriesAllItemsAsync(categoryIds.ToArray(), userId);
				}
				else
				{
					items = await itemService
						.GetByCategoriesOnSaleItemsAsync(categoryIds.ToArray(), userId);
				}
			}
			else
			{
				items = await itemService
					.GetByCategoriesOnSaleItemsAsync(categoryIds.ToArray(), null);
			}
			 
			return View(items);
		}
	}
}
