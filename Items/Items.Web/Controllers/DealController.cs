namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Deal;
	using Items.Web.Infrastructure.Extensions;
	using static Common.NotificationMessages;
	using static Common.EntityValidationErrorMessages.Item;

	using Microsoft.AspNetCore.Mvc;

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
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				IEnumerable<ContractAllViewModel> allDealsModel = await contractService.AllAsync(userId);

				return View(allDealsModel);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpGet]
		public async Task<IActionResult> Add(Guid itemId)
		{
			Guid buyerId = Guid.Parse(User.GetId());
			bool isOwner = await itemService.IsOwnerAsync(itemId, buyerId);
			if (isOwner)
			{
				TempData[ErrorMessage] = "You cannot Buy or Bid for your own item!";
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
				TempData[ErrorMessage] = "You cannot Buy or Bid for your own item!";
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
				return RedirectToAction("All", "Item");
			}

			ContractFormViewModel previewModel = await contractService.GetForCreate(model, itemId, buyerId);


			return View(previewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ContractFormViewModel previewModel, Guid itemId)
		{
			try
			{
				Guid buyerId = Guid.Parse(User.GetId());
				bool isOwner = await itemService.IsOwnerAsync(itemId, buyerId);
				if (isOwner)
				{
					TempData[ErrorMessage] = "You cannot Buy or Bid for your own item!";
					return RedirectToAction("All", "Deal");
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



				bool isQuantitySufficient = await itemService.SufficientQuantity(itemId, previewModel.Quantity);
				if (!isQuantitySufficient)
				{
					ModelState.AddModelError("Quantity", InsufficientQuantity);
				}

				if (!ModelState.IsValid || !isQuantitySufficient)
				{
					return View(previewModel);
				}


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
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isSellerOrBuyer = await contractService.SellerOrBuyerAsync(id, userId);
				if (!isSellerOrBuyer)
				{
					TempData[ErrorMessage] = "You must be Seller or Buyer to see the Contract!";
					return RedirectToAction("All", "Deal");
				}

				ContractViewModel model = await contractService.GetForDetailsAsync(id);

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpGet]
		public async Task<IActionResult> Revise(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());

				bool canRevise = await contractService.CanReviseAsync(id, userId);
				if (!canRevise)
				{
					TempData[ErrorMessage] = "You cannot Revise this Deal!";
					return RedirectToAction("All", "Deal");
				}

				ContractFormViewModel model = await contractService.GetForRevise(id, userId);

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Revise(Guid id, ContractFormViewModel model)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());

				bool canRevise = await contractService.CanReviseAsync(id, userId);
				if (!canRevise)
				{
					TempData[ErrorMessage] = "You cannot Revise this Deal!";
					return RedirectToAction("All", "Deal");
				}

				ContractViewModel beforeRevise = await contractService.GetForDetailsAsync(id);
				if (model.Equals(beforeRevise))
				{
					await contractService.SetSignedAsync(id);
				}
				else
				{
					if (!ModelState.IsValid)
					{
						return View(model); //todo: test it
					}

					await contractService.UpdateAsync(id, model);
					await contractService.ChangeReviserAsync(id);
				}

				return RedirectToAction("All", "Deal");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}



		[HttpGet]
		public async Task<IActionResult> Off(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());

				bool canRevise = await contractService.CanReviseAsync(id, userId);
				if (!canRevise)
				{
					TempData[ErrorMessage] = "You cannot Cancel this deal!";
					return RedirectToAction("All", "Deal");
				}

				await contractService.CancelAsync(id, userId);
				TempData[SuccessMessage] = "The Deal Is Off!";

				return RedirectToAction("All", "Deal");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Received(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isBuyer = await contractService.IsBuyerAsync(id, userId);
				bool isSeller = await contractService.IsSellerAsync(id, userId);
				bool isSigned = await contractService.SignedAsync(id);
				if (!isSigned || !(isSeller || isBuyer))
				{
					TempData[ErrorMessage] = "Cannot receive at this moment. Ether you are not in the contract or the contract is not signed!";
					return RedirectToAction("All", "Item");
				}

				await contractService.CompleteAsync(id, userId);
				TempData[InformationMessage] = "The Deal Status was Updated!";

				return RedirectToAction("All", "Deal");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpGet]
		public async Task<IActionResult> Complain(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool canComplainAndReceive = await contractService.CanComplainAsync(id, userId);
				if (canComplainAndReceive)
				{
					//todo: Implement complain
					TempData[InformationMessage] = "Complain Sent!";

				}
				else
				{
					TempData[ErrorMessage] = "Cannot Complain! The Delivery Date is not Reached Yet.";
				}
				return RedirectToAction("All", "Deal");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

	}
}
