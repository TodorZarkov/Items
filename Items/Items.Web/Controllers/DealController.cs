namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Deal;
	using Microsoft.AspNetCore.Mvc;
	using static Common.NotificationMessages;

	public class DealController : BaseController
	{
		private readonly IContractService contractService;
		private readonly IItemService itemService;

		public DealController(IContractService contractService, IItemService itemService)
		{
			this.contractService = contractService;
			this.itemService = itemService;
		}

		public async Task<IActionResult> All()
		{
			Guid userId = Guid.Parse(User.GetId());
			IEnumerable<ContractAllViewModel> allDealsModel = await contractService.AllAsync(userId);

			return View(allDealsModel);
		}


		[HttpGet]
		public async Task<IActionResult> Add(Guid itemId)
		{
			Guid buyerId = Guid.Parse(User.GetId());
			bool isOwner = await itemService.IsOwnerAsync(itemId, buyerId);
			if (isOwner)
			{
				//todo: error provider
				return RedirectToAction("All", "Item");
			}

			bool exists = await itemService.ExistAsync(itemId);
			if (!exists)
			{
				TempData[InformationMessage] = "Item has already been removed!";
				return RedirectToAction("All", "Item");
			}

			bool isOnTheMarket = await itemService.IsOnMarketAsync(itemId);
			if (!isOnTheMarket)
			{
				TempData[InformationMessage] = "Item Is Not On The  Market Anymore!";
				RedirectToAction("All", "Item");
			}



			ContractFormViewModel model = await contractService.GetForPreviewByIdAsync(itemId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Preview(ContractFormViewModel model, Guid itemId)
		{
			Guid buyerId = Guid.Parse(User.GetId());
			bool isOwner = await itemService.IsOwnerAsync(itemId, buyerId);
			if (isOwner)
			{
				//todo: error provider
				return RedirectToAction("All", "Item");
			}

			bool exists = await itemService.ExistAsync(itemId);
			if (!exists)
			{
				TempData[InformationMessage] = "Item has already been removed!";
				return RedirectToAction("All", "Item");
			}

			bool isOnTheMarket = await itemService.IsOnMarketAsync(itemId);
			if (!isOnTheMarket)
			{
				TempData[InformationMessage] = "Item Is Not On The  Market Anymore!";
				RedirectToAction("All", "Item");
			}

			if (!ModelState.IsValid)
			{
				model.ItemId = itemId;
				//todo: fill model more?
				return View(model);
			}
			//todo: async model check

			//check if meanwhile item hash changed  if changed - notification "Alarm Buyer for change"

			ContractFormViewModel previewModel = await contractService.GetForCreate(model, itemId, buyerId);

			return View(previewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ContractFormViewModel previewModel, Guid itemId)
		{
			Guid buyerId = Guid.Parse(User.GetId());
			bool isOwner = await itemService.IsOwnerAsync(itemId, buyerId);
			if (isOwner)
			{
				//todo: error provider
				return RedirectToAction("All", "Item");
			}

			bool exists = await itemService.ExistAsync(itemId);
			if (!exists)
			{
				TempData[InformationMessage] = "Item has already been removed!";
				return RedirectToAction("All", "Item");
			}

			bool isOnTheMarket = await itemService.IsOnMarketAsync(itemId);
			if (!isOnTheMarket)
			{
				TempData[InformationMessage] = "Item Is Not On The  Market Anymore!";
				RedirectToAction("All", "Item");
			}

			if (!ModelState.IsValid)
			{
				//todo: general error provider (at this point if model is wrong this is due to intentional violation

				return RedirectToAction("All", "Item");
			}

			bool isQuantitySufficient = await itemService.SufficientQuantity(itemId, previewModel.Quantity);
			if (!isQuantitySufficient)
			{
				TempData[ErrorMessage] = "Insufficient Item Quantity! Try reduce order Quantity.";
				RedirectToAction("All", "Item");
			}

			//todo: check if meanwhile item hash changed  if changed - notification "Alarm Buyer for change"

			try
			{
				await contractService.CreateAsync(previewModel, itemId, buyerId);

				TempData[SuccessMessage] = "The Order has been sent. Observe status!";
			}
			catch (Exception)
			{
				TempData[ErrorMessage] = "Something Went Wrong! Order Canceled!";
			}



			return RedirectToAction("All", "Deal");
		}


		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			bool isSellerOrBuyer = await contractService.SellerOrBuyerAsync(id, userId);
			if (!isSellerOrBuyer)
			{
				//todo: General error provider
				return RedirectToAction("All", "Item");
			}

			ContractViewModel model = await contractService.GetForDetailsAsync(id);


			return View(model);
		}


		[HttpGet]
		public async Task<IActionResult> Revise(Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());
			
			bool canRevise = await contractService.CanReviseAsync(id, userId);
			if (!canRevise)
			{
				//todo: General error provider
				return RedirectToAction("All", "Item");
			}

			ContractFormViewModel model = await contractService.GetForRevise(id, userId);

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Off(Guid id)
		{
			Guid userId = Guid.Parse(User.GetId());

			bool canRevise = await contractService.CanReviseAsync(id, userId);
			if (!canRevise)
			{
				//todo: General error provider
				return RedirectToAction("All", "Item");
			}

			try
			{
				await contractService.Cancel(id, userId);
				TempData[SuccessMessage] = "The Deal Is Off!";
			}
			catch (Exception)
			{
				//todo: general error provider
				return RedirectToAction("All", "Item");
			}

			return RedirectToAction("All", "Deal");
		}
	}
}
