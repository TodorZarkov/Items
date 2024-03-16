namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Deal;
	using Items.Web.Infrastructure.Extensions;
	using static Common.NotificationMessages;
	using static Common.EntityValidationErrorMessages.Item;

	using Microsoft.AspNetCore.Mvc;
	using Items.Web.ViewModels.Base;
	using Items.Services.Data.Models.Contract;
	using Items.Services.Common.Interfaces;

	public class DealController : BaseController
	{
		private readonly IContractService contractService;
		private readonly IItemService itemService;
		private readonly IOfferService offerService;
		private readonly IDateTimeProvider dateTimeProvider;

		public DealController(IContractService contractService
							, IItemService itemService
							, IOfferService offerService
							, IDateTimeProvider dateTimeProvider)
		{
			this.contractService = contractService;
			this.itemService = itemService;
			this.offerService = offerService;
			this.dateTimeProvider = dateTimeProvider;
		}


		[HttpGet]
		public async Task<IActionResult> All([FromQuery] QueryFilterModel? queryModel = null)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				AllContractServiceModel model = await contractService.AllAsync(userId, queryModel);

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}



		[HttpGet]
		public async Task<IActionResult> Add(Guid itemId)
		{
			bool exists = await itemService.ExistAsync(itemId);
			if (!exists)
			{
				TempData[InformationMessage] = "Item has already been removed!";
				return RedirectToAction("All", "Item");
			}

			Guid buyerId = Guid.Parse(User.GetId());
			bool isOwner = await itemService.IsOwnerAsync(itemId, buyerId);
			if (isOwner)
			{
				TempData[ErrorMessage] = "You cannot Buy or Bid for your own item!";
				return RedirectToAction("All", "Item");
			}

			bool isAuction = await itemService.IsAuctionAsync(itemId);
			if (isAuction)
			{
				TempData[WarningMessage] = "The Item is on Auction. Please try in the  Bid panel.";
				return RedirectToAction("All", "Bid");
			}

			bool isOnTheMarket = await itemService.IsOnMarketAsync(itemId);
			if (!isOnTheMarket)
			{
				TempData[InformationMessage] = "Item Is Not On The  Market Anymore!";
				return RedirectToAction("All", "Item");
			}


			ContractFormViewModel model = await contractService.GetForPreviewAsync(itemId, buyerId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Preview(ContractFormViewModel model, Guid id)
		{
			Guid buyerId = Guid.Parse(User.GetId());
			bool isOwner = await itemService.IsOwnerAsync(id, buyerId);
			if (isOwner)
			{
				TempData[ErrorMessage] = "You cannot Buy or Bid for your own item!";
				return RedirectToAction("All", "Item");
			}

			bool exists = await itemService.ExistAsync(id);
			if (!exists)
			{
				TempData[InformationMessage] = "Item has already been removed!";
				return RedirectToAction("All", "Item");
			}

			bool isAuction = await itemService.IsAuctionAsync(id);
			if (isAuction)
			{
				TempData[WarningMessage] = "The Item is on Auction. Please try in the  Bid panel.";
				return RedirectToAction("All", "Bid");
			}

			bool isOnTheMarket = await itemService.IsOnMarketAsync(id);
			if (!isOnTheMarket)
			{
				TempData[InformationMessage] = "Item Is Not On The  Market Anymore!";
				return RedirectToAction("All", "Item");
			}

			ContractFormViewModel previewModel = await contractService.GetForCreateAsync(model, id, buyerId);


			return View(previewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ContractFormViewModel previewModel, Guid id)
		{
			try
			{
				Guid buyerId = Guid.Parse(User.GetId());
				bool isOwner = await itemService.IsOwnerAsync(id, buyerId);
				if (isOwner)
				{
					TempData[ErrorMessage] = "You cannot Buy or Bid for your own item!";
					return RedirectToAction("All", "Deal");
				}

				bool exists = await itemService.ExistAsync(id);
				if (!exists)
				{
					TempData[InformationMessage] = "Item has already been removed!";
					return RedirectToAction("All", "Item");
				}

				bool isAuction = await itemService.IsAuctionAsync(id);
				if (isAuction)
				{
					TempData[WarningMessage] = "The Item is on Auction. Please try in the  Bid panel.";
					return RedirectToAction("All", "Bid");
				}

				bool isOnTheMarket = await itemService.IsOnMarketAsync(id);
				if (!isOnTheMarket)
				{
					TempData[InformationMessage] = "Item Is Not On The  Market Anymore!";
					return RedirectToAction("All", "Item");
				}



				decimal quantityLeft = await itemService.SufficientQuantity(id, previewModel.Quantity);
				if (quantityLeft < 0)
				{
					ModelState.AddModelError("Quantity", string.Format(InsufficientQuantity, quantityLeft + previewModel.Quantity));
				}

				if (!ModelState.IsValid || quantityLeft < 0)
				{
					return View(previewModel);
				}


				try
				{
					await contractService.CreateAsync(previewModel, id, buyerId);

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
		public async Task<IActionResult> AddFromOffer(Guid id)
		{
			bool offerExist = await offerService.ExistAsync(id);
			if (!offerExist)
			{
				return GeneralError();
			}

			Guid buyerId = Guid.Parse(User.GetId());
			bool isMine = await offerService.IsOwnerAsync(id, buyerId);
			if (!isMine)
			{
				return GeneralError();
			}

			bool isWinner = await offerService.IsWinnerAsync(id);
			if (!isWinner)
			{
				return GeneralError();
			}

			bool expired = await offerService.ExpiredAsync(id);
			if (expired)
			{
				TempData[WarningMessage] = "The Offer has expired.";
				return RedirectToAction("All", "Bid");
			}

			Guid itemId = await offerService.GetItemIdFromOfferIdAsync(id);
			bool itemExist = await itemService.ExistAsync(itemId);
			bool isMyItem = await itemService.IsOwnerAsync(itemId, buyerId);
			bool isAuction = await itemService.IsAuctionAsync(itemId);
			bool isEndSellOk = (await itemService.GetEndSellDateTime(itemId)) < dateTimeProvider.GetCurrentDateTime();
			if (!itemExist || isMyItem || !isAuction || !isEndSellOk)
			{
				return GeneralError();
			}
			bool barterExist = await itemService.ExistBarterItemByOfferIdAsync(id);
			if (!barterExist)
			{
				TempData[ErrorMessage] = "Barter Item you have proposed no longer available. Auction cannot be competed.";
				return RedirectToAction("All", "Sell");
			}
			// todo: Lock the barter item until auction is finished. can use PromisedQuantity != 0 to Lock Barter.

			bool validQuantitiesInOffer = await offerService.ValidQuantitiesInOffer(id);
			if (!validQuantitiesInOffer)
			{
				return GeneralError();
			}

			ContractFormViewModel model = await contractService.GetForPreviewAsync(itemId, buyerId, id);

			return View("Add", model);
		}

		[HttpPost]
		public async Task<IActionResult> FromOfferPreview(ContractFormViewModel model, Guid id)
		{
			bool offerExist = await offerService.ExistAsync(id);
			if (!offerExist)
			{
				return GeneralError();
			}

			Guid buyerId = Guid.Parse(User.GetId());
			bool isMine = await offerService.IsOwnerAsync(id, buyerId);
			if (!isMine)
			{
				return GeneralError();
			}

			bool isWinner = await offerService.IsWinnerAsync(id);
			if (!isWinner)
			{
				return GeneralError();
			}

			bool expired = await offerService.ExpiredAsync(id);
			if (expired)
			{
				TempData[WarningMessage] = "The Offer has expired.";
				return RedirectToAction("All", "Bid");
			}

			Guid itemId = await offerService.GetItemIdFromOfferIdAsync(id);
			bool itemExist = await itemService.ExistAsync(itemId);
			bool isMyItem = await itemService.IsOwnerAsync(itemId, buyerId);
			bool isAuction = await itemService.IsAuctionAsync(itemId);
			bool isEndSellOk = (await itemService.GetEndSellDateTime(itemId)) < dateTimeProvider.GetCurrentDateTime();
			if (!itemExist || isMyItem || !isAuction || !isEndSellOk)
			{
				return GeneralError();
			}
			bool barterExist = await itemService.ExistBarterItemByOfferIdAsync(id);
			if (!barterExist)
			{
				TempData[ErrorMessage] = "Barter Item you have proposed no longer available. Auction cannot be competed.";
				return RedirectToAction("All", "Sell");
			}
			// todo: Lock the barter item until auction is finished. can use PromisedQuantity != 0 to Lock Barter.

			bool validQuantitiesInOffer = await offerService.ValidQuantitiesInOffer(id);
			if (!validQuantitiesInOffer)
			{
				return GeneralError();
			}

			ContractFormViewModel previewModel = await contractService.GetForCreateAsync(model, itemId, buyerId, id);

			return View("Preview", previewModel);
		}

		[HttpPost]
		public async Task<IActionResult> AddFromOffer(ContractFormViewModel model, Guid id)
		{	
			//implement copy barter to the seller deal panel
			try
			{


				bool offerExist = await offerService.ExistAsync(id);
				if (!offerExist)
				{
					return GeneralError();
				}

				Guid buyerId = Guid.Parse(User.GetId());
				bool isMine = await offerService.IsOwnerAsync(id, buyerId);
				if (!isMine)
				{
					return GeneralError();
				}

				bool isWinner = await offerService.IsWinnerAsync(id);
				if (!isWinner)
				{
					return GeneralError();
				}

				bool expired = await offerService.ExpiredAsync(id);
				if (expired)
				{
					TempData[WarningMessage] = "The Offer has expired.";
					return RedirectToAction("All", "Bid");
				}

				Guid itemId = await offerService.GetItemIdFromOfferIdAsync(id);
				bool itemExist = await itemService.ExistAsync(itemId);
				bool isMyItem = await itemService.IsOwnerAsync(itemId, buyerId);
				bool isAuction = await itemService.IsAuctionAsync(itemId);
				bool isEndSellOk = (await itemService.GetEndSellDateTime(itemId)) < dateTimeProvider.GetCurrentDateTime();
				if (!itemExist || isMyItem || !isAuction || !isEndSellOk)
				{
					return GeneralError();
				}
				bool barterExist = await itemService.ExistBarterItemByOfferIdAsync(id);
				if (!barterExist)
				{
					TempData[ErrorMessage] = "Barter Item you have proposed no longer available. Auction cannot be competed.";
					return RedirectToAction("All", "Sell");
				}
				// todo: Lock the barter item until auction is finished. can use PromisedQuantity != 0 to Lock Barter.

				bool validQuantitiesInOffer = await offerService.ValidQuantitiesInOffer(id);
				if (!validQuantitiesInOffer)
				{
					return GeneralError();
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				Guid dealId;
				try
				{
					dealId = await contractService.CreateAsync(model, itemId, buyerId, id);
				}
				catch (Exception)
				{
					TempData[ErrorMessage] = "Something Went Wrong! Order Canceled!";
				}



				return RedirectToAction("All", "Deal");//with query for the newly created deal!
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
						model = await contractService.GetForRevise(id, userId);
						return View(model);
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
					// TODO: Implement complain
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
