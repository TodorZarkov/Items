namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Category;
	using Items.Web.ViewModels.Item;
	using static Common.EntityValidationErrorMessages.Category;
	using static Common.NotificationMessages;

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


		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			bool exist = await categoryService.ExistAsync(id);
			if (!exist)
			{
				return StatusCode(StatusCodes.Status404NotFound);
			}

			Guid userId = Guid.Parse(User.GetId());
			bool isOwner = await categoryService.IsOwnerAsync(userId, id);
			if (!isOwner)
			{
				return StatusCode(StatusCodes.Status403Forbidden);
			}

			long numberOfReferences = await categoryService.CountReferencesAsync(id);
			if (numberOfReferences > 0)
			{
				TempData[ErrorMessage] = string.Format(CategoryHasItems, numberOfReferences);
				return RedirectToAction("All", "Item");
			}

			await categoryService.DeleteAsync(id);

			return RedirectToAction("All", "Item");
		}
	}
}
