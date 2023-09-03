namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Item;
	using static Common.EntityValidationErrorMessages.General;
	using static Common.NotificationMessages;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Items.Web.ViewModels.Base;
	using Items.Services.Data.Models.Item;

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


		
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> All([FromQuery] QueryFilterModel? queryModel = null)
		{
			try
			{
				AllItemServiceModel model;
				// TODO: check the queryModel
				if (User.Identity?.IsAuthenticated ?? false)
				{
					Guid userId = Guid.Parse(User.GetId());
					model = await itemService.GetAllAsync(userId, queryModel);
				}
				else
				{
					model = await itemService.GetAllAsync(null, queryModel);
				}
				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
			
		}

		[HttpGet]
		public async Task<IActionResult> Mine([FromQuery] QueryFilterModel? queryModel = null)
		{
			Guid userId = Guid.Parse(User.GetId());
			try
			{
				// TODO: check the query model
				MineItemServiceModel model = await itemService.GetMineAsync(userId, queryModel);

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
			
		}

		[HttpGet]
		public async Task<IActionResult> Add(int? placeId)
		{
			Guid userId = Guid.Parse(User.GetId());

			try
			{
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
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Add(ItemFormModel model, bool continueAdd)
		{
			try
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
					model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
					model.AvailableCurrencies = await currencyService.AllForSelectAsync();
					model.AvailableUnits = await unitService.AllForSelectAsync();
					model.AvailablePlaces = await placeService.AllForSelectAsync(userId);
					return View(model);
				}

				Guid itemId = await itemService.CreateItemAsync(model, userId);
				TempData[SuccessMessage] = "Item successfully Created!";


				if (continueAdd)
				{
					return RedirectToAction("Add", "Item", new { placeId = model.PlaceId });
				}

				return RedirectToAction("Details", "Item", new { id = itemId });
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAuthorized = await itemService.IsOwnerAsync(id, userId);
				if (!isAuthorized)
				{
					TempData[ErrorMessage] = "You must be owner to edit Item!";
					return RedirectToAction("Mine", "Item");
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
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ItemFormModel model, Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAuthorized = await itemService.IsOwnerAsync(id, userId);
				if (!isAuthorized)
				{
					TempData[ErrorMessage] = "You must be owner to edit Item!";
					return RedirectToAction("Mine", "Item");
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

				await itemService.UpdateItemAsync(model, id);

				return RedirectToAction("Details", "Item", new { id });
			}
			catch (Exception  e)
			{
				return GeneralError(e);
			}
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
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isOwner = await itemService.IsOwnerAsync(id, userId);
				bool isOnMarket = await itemService.IsOnMarketAsync(id);

				bool authorizedToView = isOwner || isOnMarket;
				if (!authorizedToView)
				{
					TempData[ErrorMessage] = "The Item is not Public Anymore!";
					return RedirectToAction("All", "Item");
				}

				ItemViewModel model;

				if (isOwner)
				{
					model = await itemService.GetByIdForViewAsOwnerAsync(id);
				}
				else
				{
					model = await itemService.GetByIdForViewAsync(id);
				}

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAuthorized = await itemService.IsOwnerAsync(id, userId);
				if (!isAuthorized)
				{
					TempData[ErrorMessage] = "Only Owner can Delete!";
					return RedirectToAction("Mine", "Item");
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
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(Guid id, PreDeleteItemViewModel model)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAuthorized = await itemService.IsOwnerAsync(id, userId);
				if (!isAuthorized)
				{
					TempData[ErrorMessage] = "Only Owner can Delete!";
					return RedirectToAction("Mine", "Item");
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
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}



		[HttpGet]
		public async Task<IActionResult> StopSell(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAuthorized = await itemService.IsOwnerAsync(id, userId);
				if (!isAuthorized)
				{
					TempData[ErrorMessage] = "You must be Owner to manage Items!";
					return RedirectToAction("Mine", "Item");
				}

				bool exists = await itemService.ExistAsync(id);
				if (!exists)
				{
					TempData[InformationMessage] = "Item has already been removed!";
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
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpGet]
		public async Task<IActionResult> CreateFromDeal(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isBuyer = await contractService.IsBuyerAsync(id, userId);
				if (!isBuyer)
				{
					TempData[ErrorMessage] = "You must be The Buyer to Create from Deal!";
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
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		
	}
}
