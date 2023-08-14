namespace Items.Web.Controllers
{
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Item;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class ItemController : BaseController
	{
		private readonly IItemService itemService;
		private readonly ICategoryService categoryService;
		private readonly IPlaceService placeService;
		private readonly ICurrencyService currencyService;
		private readonly IUnitService unitService;

		public ItemController(IItemService itemService, ICategoryService categoryService, IPlaceService placeService, ICurrencyService currencyService, IUnitService unitService)
		{
			this.itemService = itemService;
			this.categoryService = categoryService;
			this.placeService = placeService;
			this.currencyService = currencyService;
			this.unitService = unitService;
		}

		[HttpGet]
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

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			Guid userId = Guid.Parse(User.GetId());
			IEnumerable<MyItemViewModel> model = await itemService.Mine(userId);

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			Guid userId = Guid.Parse(User.GetId());

			ItemFormModel model = new ItemFormModel
			{
				ItemVisibility = new ItemFormVisibilityModel(),
				AvailableCategories = await categoryService.AllForSelectAsync(userId),
				AvailableCurrencies = await currencyService.AllForSelectAsync(),
				AvailableUnits = await unitService.AllForSelectAsync(),
				AvailablePlaces = await placeService.AllForSelectAsync(userId),
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ItemFormModel model, bool continueAdd)
		{
			//todo: check the model!!!!!
			Guid userId = Guid.Parse(User.GetId());
			await itemService.CreateItemAsync(model, userId);

			if (continueAdd)
			{
				return RedirectToAction("Add", "Item");//todo: fill appropriate model with some of the previous choices
			}

			return RedirectToAction("Mine", "Item");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isAuthorized = await itemService.IsAuthorized(id, userId);
			if (!isAuthorized)
			{
				return RedirectToAction("All", "Item");
			}

			ItemFormModel model = await itemService.GetByIdAsync(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ItemFormModel model, Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isAuthorized = await itemService.IsAuthorized(id, userId);
			if (!isAuthorized)
			{
				return RedirectToAction("All", "Item");
			}
			//todo: check model

			//await itemService.UpdateItemAsync(model);

			return RedirectToAction("Mine", "Item");
		}
	}
}
