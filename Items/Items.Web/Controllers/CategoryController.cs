namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Category;
	using Items.Web.ViewModels.Item;
	using static Common.EntityValidationErrorMessages.Category;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Http.Extensions;
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
		public IActionResult Add()
		{
			CategoryFormViewModel model = new CategoryFormViewModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CategoryFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			Guid userId = Guid.Parse(User.GetId());
			bool existName = await categoryService.ExistNameAsync(model.Name, userId);
			if (existName)
			{
				ModelState.AddModelError(nameof(model.Name), ExistingCategory);
				return View(model);
			}

			int categoryId = await categoryService.AddAsync(model, userId);

			return RedirectToAction("Mine", "Item");

		}
	}
}
