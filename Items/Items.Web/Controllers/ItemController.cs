namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Item;
	using static Common.EntityValidationErrorMessages.General;
	using static Common.NotificationMessages;
	using Items.Web.ViewModels.Base;
	using Items.Services.Data.Models.Item;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class ItemController : BaseController
	{
		private readonly IItemService itemService;
		private readonly ICategoryService categoryService;
		private readonly IPlaceService placeService;
		private readonly ICurrencyService currencyService;
		private readonly IUnitService unitService;
		private readonly IContractService contractService;
		private readonly ILocationService locationService;
		private readonly IFileService fileService;

		public ItemController(
			  IItemService itemService
			, ICategoryService categoryService
			, IPlaceService placeService
			, ICurrencyService currencyService
			, IUnitService unitService
			, IContractService contractService
			, ILocationService locationService
			, IFileService fileService)

		{
			this.itemService = itemService;
			this.categoryService = categoryService;
			this.placeService = placeService;
			this.currencyService = currencyService;
			this.unitService = unitService;
			this.contractService = contractService;
			this.locationService = locationService;
			this.fileService = fileService;
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
					AvailableLocations = await locationService.GetForSelectAsync(userId)
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
				bool isValidPlaceId = await placeService.IsAllowedIdAsync(model.PlaceId, model.LocationId, userId);
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
					model.AvailableLocations = await locationService.GetForSelectAsync(userId);
					return View(model);
				}

				Guid itemId = await itemService.CreateItemAsync(model, userId);

				// todo: replace all messages with constants from Common
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

				ItemEditFormModel model = await itemService.CopyFromContract(id, userId);

				model.ItemVisibility = new ItemFormVisibilityModel();
				model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
				model.AvailableCurrencies = await currencyService.AllForSelectAsync();
				model.AvailableUnits = await unitService.AllForSelectAsync();
				model.AvailableLocations = await locationService.GetForSelectAsync(userId);
				model.AvailablePlaces = await placeService.AllForSelectAsync(userId);

				return View("Edit", model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateFromDeal(ItemEditFormModel model, Guid id)
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

				bool isValidAsync = true;
				bool isValidUnitId = await unitService.IsValidIdAsync(model.UnitId);
				bool isValidPlaceId = await placeService.IsAllowedIdAsync(model.PlaceId, model.LocationId, userId);
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
					model.AvailableLocations = await locationService.GetForSelectAsync(userId);
					return View(model);
				}


				Guid itemId = await itemService.CreateItemAsync(model, userId);
				await contractService.CopyBuyerContractImagesToItemAsync(id, itemId);

				// todo: replace all messages with constants from Common
				TempData[SuccessMessage] = "Item successfully Created!";

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

				ItemEditFormModel model = await itemService.GetByIdForEditAsync(id);
				model.CurrentImages = await itemService.GetImagesByIdAsync(id);
				model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
				model.AvailableCurrencies = await currencyService.AllForSelectAsync();
				model.AvailableUnits = await unitService.AllForSelectAsync();
				model.AvailablePlaces = await placeService.AllForSelectAsync(userId);
				model.AvailableLocations = await locationService.GetForSelectAsync(userId);

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ItemEditFormModel model, Guid id)
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
				bool isValidMainImage =
					await itemService.IsValidMainImageAsync(model.MainImageId, userId, id);
				bool isValidImagesToDelete =
					await itemService.IsAllowedImagesToDeleteAsync(model.ImagesToDelete, model.MainImageId, userId, id);
				if (!(isValidUnitId && isValidPlaceId && isValidCurrencyId && isValidCategories && isValidMainImage && isValidImagesToDelete))
				{
					isValidAsync = false;
					ModelState.AddModelError("", GeneralFormError);
				}

				if (!(ModelState.IsValid && isValidAsync))
				{
					model.CurrentImages = await itemService.GetImagesByIdAsync(id);
					model.AvailableCategories = await categoryService.AllForSelectAsync(userId);
					model.AvailableCurrencies = await currencyService.AllForSelectAsync();
					model.AvailableUnits = await unitService.AllForSelectAsync();
					model.AvailablePlaces = await placeService.AllForSelectAsync(userId);
					model.AvailableLocations = await locationService.GetForSelectAsync(userId);
					return View(model);
				}

				await itemService.UpdateItemAsync(model, id);

				return RedirectToAction("Details", "Item", new { id });
			}
			catch (Exception e)
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
				bool isAuction = await itemService.IsAuctionAsync(id);
				if (isOnMarket || isAuction)
				{
					TempData[ErrorMessage] = "Item must be removed from The Market first!";
					return RedirectToAction("All", "Sell");
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
				bool isAuction = await itemService.IsAuctionAsync(id);
				if (isOnMarket || isAuction)
				{
					TempData[ErrorMessage] = "Item must be removed from The Market first!";
					return RedirectToAction("All", "Sell");
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


		



	}
}
