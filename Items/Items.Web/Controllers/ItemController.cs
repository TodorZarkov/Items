namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Item;
	using static Common.NotificationMessages;
	using static Common.EntityValidationErrorMessages.General;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Items.Web.ViewModels.Deal;

	public class ItemController : BaseController
	{
		private readonly IItemService itemService;
		private readonly ICategoryService categoryService;
		private readonly IPlaceService placeService;
		private readonly ICurrencyService currencyService;
		private readonly IUnitService unitService;
		private readonly IContractService contractService;

		public ItemController(IItemService itemService, ICategoryService categoryService, IPlaceService placeService, ICurrencyService currencyService, IUnitService unitService, IContractService contractService)
		{
			this.itemService = itemService;
			this.categoryService = categoryService;
			this.placeService = placeService;
			this.currencyService = currencyService;
			this.unitService = unitService;
			this.contractService = contractService;
		}


		//todo: when with query not to forget [FromQuery] because we pass whole model.
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> All(string? searchTerm = null)
		{
			IEnumerable<AllItemViewModel> model;

			if (User.Identity?.IsAuthenticated ?? false)
			{
				Guid userId = Guid.Parse(User.GetId());
				model = await itemService.All(userId, searchTerm);
			}
			else
			{
				model = await itemService.AllPublic(searchTerm);
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

			bool isValidAsync = true;
			bool isValidUnitId = await unitService.IsValidIdAsync(model.UnitId);
			bool isValidPlaceId = await placeService.IsAllowedIdAsync(model.PlaceId, userId);
			bool isValidCurrencyId = model.CurrencyId == null || await currencyService.ExistsByIdAsync((int)model.CurrencyId);
			bool isValidCategories = await categoryService.IsAllowedIdsAsync(model.CategoryIds, userId);
			if (!(isValidUnitId && isValidPlaceId && isValidCurrencyId && isValidCategories))
			{
				isValidAsync = false;
				ModelState.AddModelError("", GeneralFormError);
			}
			if (!(ModelState.IsValid && isValidAsync))
			{
				//todo:more model async checks 
				model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
				model.AvailableCurrencies = await currencyService.AllForSelectAsync();
				model.AvailableUnits = await unitService.AllForSelectAsync();
				model.AvailablePlaces = await placeService.AllForSelectAsync(userId);
				return View(model);
			}
			//todo: create to return the new id
			await itemService.CreateItemAsync(model, userId);

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

			bool isValidAsync = true;
			bool isValidUnitId = await unitService.IsValidIdAsync(model.UnitId);
			bool isValidPlaceId = await placeService.IsAllowedIdAsync(model.PlaceId, userId);
			bool isValidCurrencyId = model.CurrencyId == null || await currencyService.ExistsByIdAsync((int)model.CurrencyId);
			bool isValidCategories = await categoryService.IsAllowedIdsAsync(model.CategoryIds, userId);
			if (!(isValidUnitId && isValidPlaceId && isValidCurrencyId && isValidCategories))
			{
				isValidAsync = false;
				ModelState.AddModelError("", GeneralFormError);
			}

			if (!(ModelState.IsValid && isValidAsync))
			{
				model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
				model.AvailableCurrencies = await currencyService.AllForSelectAsync();
				model.AvailableUnits = await unitService.AllForSelectAsync();
				model.AvailablePlaces = await placeService.AllForSelectAsync(userId);
				return View(model);
			}
			//todo: try catch all interaction with db and if catch return private IActionResult GeneralError()
			await itemService.UpdateItemAsync(model, id);

			return RedirectToAction("Mine", "Item");
		}


		[HttpGet]
		public IActionResult PutOnMarket(Guid id)
		{
			TempData[InformationMessage] = "You Must Edit The \"Market Section\"";
			return RedirectToAction("Edit", "Item", new { id });
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



		[HttpGet]
		public async Task<IActionResult> StopSell(Guid id)
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
				TempData[InformationMessage] = "Item has already been removed!";
				return RedirectToAction("Mine", "Item");
			}

			bool isOnMarket = await itemService.IsOnMarketAsync(id);
			if (!isOnMarket)
			{
				TempData[InformationMessage] = "Item Is Not On The  Market!";
				return RedirectToAction("Mine", "Item");
			}

			bool isAuction = await itemService.IsAuctionAsync(id);
			if (isAuction)
			{
				TempData[WarningMessage] = "Edit from Sells or Remove From The Market!";
				return RedirectToAction("All", "Sell");
			}


			await itemService.StopSellByItemIdAsync(id);
			TempData[SuccessMessage] = "Item Removed From The  Market!";

			return RedirectToAction("All", "Item");
		}


		[HttpGet]
		public async Task<IActionResult> CreateFromDeal(Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isBuyer = await contractService.IsBuyerAsync(id, userId);
			if (!isBuyer)
			{
				//todo: general error provider
				return RedirectToAction("All", "Item");
			}

			ItemFormModel model = await itemService.CopyFromContract(id, userId);

			model.ItemVisibility = new ItemFormVisibilityModel();
			model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
			model.AvailableCurrencies = await currencyService.AllForSelectAsync();
			model.AvailableUnits = await unitService.AllForSelectAsync();
			model.AvailablePlaces = await placeService.AllForSelectAsync(userId);

			return View("Add", model);
		}
	}
}
