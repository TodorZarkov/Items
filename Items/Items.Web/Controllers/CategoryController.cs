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
		private readonly ICategoryService categoryService;

		public CategoryController(IItemService itemService, ICategoryService categoryService)
		{
			this.itemService = itemService;
			this.categoryService = categoryService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Filtered(
			Dictionary<string, List<CategoryFilterViewModel>> model, string type)
		{
			if (!ModelState.IsValid)
			{
				return View(new List<AllItemViewModel>());
			}

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

				if (!await categoryService
					.IsAllowedIdsAsync(categoryIds.ToArray(), userId))
				{
					return View(new List<AllItemViewModel>());
				}

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
				if (!await categoryService
					.IsAllowedPublicIdsAsync(categoryIds.ToArray()))
				{
					return View(new List<AllItemViewModel>());
				}

				items = await itemService
					.GetByCategoriesOnSaleItemsAsync(categoryIds.ToArray(), null);
			}
			 
			return View(items);
		}
	}
}
