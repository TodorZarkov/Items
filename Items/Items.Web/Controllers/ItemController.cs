namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Item;
	using static Common.NotificationMessages;

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
		public async Task<IActionResult> Add(int? placeId)
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
			if (placeId.HasValue)
			{
				model.PlaceId = (int)placeId;
			}
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ItemFormModel model, bool continueAdd)
		{
			Guid userId = Guid.Parse(User.GetId());
			await itemService.CreateItemAsync(model, userId);
			if (!ModelState.IsValid)
			{
				//todo:more model async checks 
				model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
				model.AvailableCurrencies = await currencyService.AllForSelectAsync();
				model.AvailableUnits = await unitService.AllForSelectAsync();
				model.AvailablePlaces = await placeService.AllForSelectAsync(userId);
				return View(model);
			}
			

			if (continueAdd)
			{
				return RedirectToAction("Add", "Item", new { placeId = model.PlaceId });
			}

			return RedirectToAction("Mine", "Item");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isAuthorized = await itemService.IsAuthorizedAsync(id, userId);
			if (!isAuthorized)
			{
				return RedirectToAction("All", "Item");
			}

			bool isAuction = await itemService.IsAuctionAsync(id);
			if (isAuction)
			{
				TempData[WarningMessage] = "Edit from Sells or Remove From The Market!";
				return RedirectToAction("All", "Sell");
			}

			ItemFormModel model = await itemService.GetByIdForEditAsync(id);
			model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
			model.AvailableCurrencies = await currencyService.AllForSelectAsync();
			model.AvailableUnits = await unitService.AllForSelectAsync();
			model.AvailablePlaces = await placeService.AllForSelectAsync(userId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ItemFormModel model, Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isAuthorized = await itemService.IsAuthorizedAsync(id, userId);
			if (!isAuthorized)
			{
				return RedirectToAction("All", "Item");
			}

			bool isAuction = await itemService.IsAuctionAsync(id);
			if (isAuction)
			{
				TempData[WarningMessage] = "Edit from Sells or Remove From The Market!";
				return RedirectToAction("All", "Sell");
			}

			if (!ModelState.IsValid)
			{
				//todo:more model async checks 
				model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
				model.AvailableCurrencies = await currencyService.AllForSelectAsync();
				model.AvailableUnits = await unitService.AllForSelectAsync();
				model.AvailablePlaces = await placeService.AllForSelectAsync(userId);
				return View(model);
			}

			await itemService.UpdateItemAsync(model, id);

			return RedirectToAction("Mine", "Item");
		}

		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());

			bool authorizedToView = await itemService.IsAuthorizedToViewAsync(id, userId);
			if (!authorizedToView)
			{
				return RedirectToAction("All", "Item");
			}

			ItemViewModel model;

			bool authorizedToEdit = await itemService.IsAuthorizedAsync(id, userId);
			if (authorizedToEdit)
			{
				model = await itemService.GetByIdForViewAsOwnerAsync(id);
			}
			else
			{
				model = await itemService.GetByIdForViewAsync(id);
			}

			return View(model);
		}


		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isAuthorized = await itemService.IsAuthorizedAsync(id, userId);
			if (!isAuthorized)
			{
				return RedirectToAction("All", "Item");
			}

			bool exists = await itemService.ExistAsync(id);
			if (!exists)
			{
				TempData[ErrorMessage] = "Item has already been removed!";
				return RedirectToAction("Mine", "Item");
			}

			bool isOnMarket = await itemService.IsOnMarketAsync(id);
			if (isOnMarket)
			{
				TempData[ErrorMessage] = "Item must be removed from The Market first!";
				return RedirectToAction("Mine", "Item");
			}

			PreDeleteItemViewModel model = await itemService.GetForDeleteByIdAsync(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(Guid id, PreDeleteItemViewModel model)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isAuthorized = await itemService.IsAuthorizedAsync(id, userId);
			if (!isAuthorized)
			{
				return RedirectToAction("All", "Item");
			}

			bool exists = await itemService.ExistAsync(id);
			if (!exists)
			{
				TempData[ErrorMessage] = "Item has already been removed!";
				return RedirectToAction("Mine", "Item");
			}

			bool isOnMarket = await itemService.IsOnMarketAsync(id);
			if (isOnMarket)
			{
				TempData[ErrorMessage] = "Item must be removed from The Market first!";
				return RedirectToAction("Mine", "Item");
			}

			await itemService.DeleteByIdAsync(id);

			TempData[SuccessMessage] = "Item was Deleted Successfully!";

			return RedirectToAction("Mine", "Item");
		}
	}
}
