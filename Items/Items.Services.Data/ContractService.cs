namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Common.Interfaces;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Deal;
	using static Items.Common.Enums.AccessModifier;
	using static Items.Common.FormatConstants.DateAndTime;
	using static Items.Common.GeneralConstants;

	using Microsoft.EntityFrameworkCore;

	using System;
	using System.Threading.Tasks;

	using Items.Web.ViewModels.Base;
	using Items.Common.Enums;
	using Items.Services.Data.Models.Contract;
	using Items.Services.Data.Models.File;
	using System.Diagnostics.Contracts;

	public class ContractService : IContractService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IDateTimeProvider dateTimeProvider;
		private readonly IHelper helper;
		private readonly IFileService fileService;
		private readonly IFileIdentifierService fileIdentifierService;

		public ContractService(ItemsDbContext dbContext, IDateTimeProvider dateTimeProvider, IHelper helper, IFileService fileService, IFileIdentifierService fileIdentifierService)
		{
			this.dbContext = dbContext;
			this.dateTimeProvider = dateTimeProvider;
			this.helper = helper;
			this.fileService = fileService;
			this.fileIdentifierService = fileIdentifierService;
		}


		public async Task<long> CountCompletedAsync()
		{
			long completedCount = await dbContext.Contracts
				.AsNoTracking()
				.LongCountAsync(c => c.BuyerReceived && c.SellerReceived);

			return completedCount;
		}

		public async Task<AllContractServiceModel> AllAsync(Guid userId, QueryFilterModel? queryModel = null)
		{
			var dealsQuery = dbContext.Contracts
				.AsNoTracking()
				.Where(c => c.BuyerId == userId || c.SellerId == userId)
				.AsQueryable();

			string? searchTerm = queryModel?.SearchTerm;
			if (!string.IsNullOrEmpty(searchTerm))
			{
				dealsQuery = dealsQuery
					.Where(c => c.ItemName.ToLower().Contains(searchTerm.ToLower()) ||
								(c.ItemDescription != null && c.ItemDescription.ToLower().Contains(searchTerm.ToLower())));
			}

			Criteria[]? criteria = queryModel?.Criteria;
			if (criteria != null && criteria.Length > 0)

			{
				if (criteria.Contains(Criteria.Bought) && !criteria.Contains(Criteria.Sold))
				{
					dealsQuery = dealsQuery
					.Where(c => c.BuyerId == userId);
				}
				else if (!criteria.Contains(Criteria.Bought) && criteria.Contains(Criteria.Sold))
				{
					dealsQuery = dealsQuery
						.Where(c => c.SellerId == userId);
				}

			}

			Sorting? sorting = queryModel?.SortBy;
			if (sorting != null)
			{
				if (sorting == Sorting.Name)
				{
					dealsQuery = dealsQuery
						.OrderBy(c => c.ItemName.ToLower());
				}
				else if (sorting == Sorting.PriceDec)
				{
					dealsQuery = dealsQuery
						.OrderByDescending(c => c.Price);
				}
				else if (sorting == Sorting.PriceAsc)
				{
					dealsQuery = dealsQuery
						.OrderBy(c => c.Price);
				}
				else if (sorting == Sorting.Latest)
				{
					dealsQuery = dealsQuery
						.OrderByDescending(c => c.CreatedOn);
				}
				// todo: Map  GetDealStatus or get another solution to sort by status
				else if (sorting == Sorting.Status)
				{
					dealsQuery = dealsQuery
						//.OrderBy(c => helper.GetDealStatus(c.SellerOk, c.BuyerOk, c.SellerReceived, c.BuyerReceived));
						.OrderByDescending(c => c.SellerOk)
						.ThenByDescending(c => c.BuyerOk)
						.ThenByDescending(c => c.SellerReceived)
						.ThenByDescending(c => c.BuyerReceived);
				}
				else if (sorting == Sorting.SendDate)
				{
					dealsQuery = dealsQuery
						.OrderBy(c => c.SendDue);
				}
				else if (sorting == Sorting.DeliveryDate)
				{
					dealsQuery = dealsQuery
						.OrderBy(c => c.DeliverDue);
				}

			}

			var totalContractsCount = dealsQuery.Count();


			int currentPage = queryModel?.CurrentPage ?? DefaultCurrentPage;
			int hitsPerPage = queryModel?.HitsPerPage ?? DefaultHitsPerPage;

			dealsQuery = dealsQuery
				.Skip((currentPage - 1) * hitsPerPage)
				.Take(hitsPerPage);





			ContractAllViewModel[] contracts = await dealsQuery
				.Select(c => new ContractAllViewModel
				{
					Id = c.Id,
					CanComplainAndReceive = c.BuyerOk && c.SellerOk &&
											(!c.BuyerReceived && c.BuyerId == userId) || (!c.SellerReceived && c.SellerId == userId) &&
											c.DeliverDue < dateTimeProvider.GetCurrentDate(),
					IsSeller = c.SellerId == userId,
					RowStatusColor = helper
						.GetDealRowColor(c.SellerOk, c.BuyerOk, c.SellerReceived, c.BuyerReceived, c.SellerId == userId),


					ItemId = c.ItemId,
					ItemName = c.ItemName,
					ItemMainPictureId = c.ItemMainPictureId,

					SellerOk = c.SellerOk,
					BuyerOk = c.BuyerOk,
					BuyerReceived = c.BuyerReceived,
					SellerReceived = c.SellerReceived,
					DealStatus = helper.GetDealStatus(c.SellerOk, c.BuyerOk, c.SellerReceived, c.BuyerReceived),

					BuyerComment = c.BuyerComment,
					SellerComment = c.SellerComment,

					Quantity = c.Quantity.ToString("N2"),
					Unit = c.Unit.Symbol,

					Price = c.Price.ToString("N2"),
					Currency = c.Currency.Symbol,

					ContractDate = c.ContractDate != null ? ((DateTime)c.ContractDate).ToString(ContractDateTime) : string.Empty,
					DeliverDue = c.DeliverDue,
					SendDue = c.SendDue.ToString(ContractDateTime),
					DeliveryAddress = c.DeliveryAddress
				})
				.ToArrayAsync();


			AllContractServiceModel result = new AllContractServiceModel()
			{
				Contracts = contracts,
				TotalContractsCount = totalContractsCount
			};


			return result;
		}



		public async Task<ContractFormViewModel> GetForPreviewAsync(Guid itemId, Guid buyerId)
		{
			var buyerData = await dbContext.Users
				.Where(u => u.Id == buyerId)
				.Select(u => new
				{
					Name = u.UserName,
					Email = u.EmailConfirmed ? u.Email : null,
					Phone = u.PhoneNumberConfirmed ? u.PhoneNumber : null
				})
				.SingleAsync();

			ContractFormViewModel model = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ContractFormViewModel
				{
					SellerName = i.ItemVisibility.Owner == Public ? i.Owner.UserName : null,
					SellerEmail = i.ItemVisibility.Owner == Public ? i.Owner.Email : null,
					SellerPhone = i.ItemVisibility.Owner == Public ? i.Owner.PhoneNumber : null,

					BuyerName = buyerData.Name,
					BuyerEmail = buyerData.Email,
					BuyerPhone = buyerData.Phone,

					ItemId = i.Id,
					Price = (decimal)i.CurrentPrice!,
					CurrencySymbol = i.Currency!.Symbol,
					UnitSymbol = i.Unit.Symbol,
					ItemName = i.Name,
					ItemPictureId = i.MainPictureId,
					ItemDescription = i.ItemVisibility.Description == Public ? i.Description : null,
					SendDue = dateTimeProvider.GetCurrentDate()
						.AddDays(SendDueDateDaysAfterNow),
					DeliverDue = dateTimeProvider.GetCurrentDate()// TODO: automatize according to buyer distance
						.AddDays(SendDueDateDaysAfterNow)
						.AddDays(DeliverDueDateDaysAfterSend),
					SellerComment = SellerDefaultComment,
					//DeliveryAddress = ...  TODO: get address from new user property Address (if set)

				})
				.SingleAsync();

			return model;
		}

		public async Task<ContractFormViewModel> GetForPreviewAsync(Guid itemId, Guid buyerId, Guid offerId)
		{
			var buyerData = await dbContext.Users
				.Where(u => u.Id == buyerId)
				.Select(u => new
				{
					Name = u.UserName,
					Email = u.EmailConfirmed ? u.Email : null,
					Phone = u.PhoneNumberConfirmed ? u.PhoneNumber : null
				})
				.SingleAsync();

			var offerData = await dbContext.Offers
				.AsNoTracking()
				.Where(o => o.Id == offerId)
				.Select(o => new
				{
					o.BarterItemId,
					o.BarterQuantity,
					BarterName = o.BarterItem != null ? o.BarterItem.Name : null,
					BarterUnitSymbol = o.BarterItem != null ? o.BarterItem.Unit.Symbol : null,
					BarterPictureId = o.BarterItem != null ? (Guid?)o.BarterItem.MainPictureId : null,
					BarterDescription = o.BarterItem != null ? o.BarterItem.Description : null,
					MessageFromBuyer = o.Message,
					OfferQuantity = o.Quantity,
					OfferValue = o.Value,
					o.UseBuyerEmail,
					o.UseBuyerName,
					o.UseBuyerPhone
				})
				.SingleAsync();

			ContractFormViewModel model = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ContractFormViewModel
				{
					SellerName = i.ItemVisibility.Owner == Public ? i.Owner.UserName : null,
					SellerEmail = i.ItemVisibility.Owner == Public ? i.Owner.Email : null,
					SellerPhone = i.ItemVisibility.Owner == Public ? i.Owner.PhoneNumber : null,

					BuyerName = offerData.UseBuyerName ? buyerData.Name : null,
					BuyerEmail = offerData.UseBuyerEmail ? buyerData.Email : null,
					BuyerPhone = offerData.UseBuyerPhone ? buyerData.Phone : null,

					ItemId = i.Id,
					Price = offerData.OfferValue,
					Quantity = offerData.OfferQuantity,
					CurrencySymbol = i.Currency!.Symbol,
					UnitSymbol = i.Unit.Symbol,
					ItemName = i.Name,
					ItemPictureId = i.MainPictureId,
					ItemDescription = i.ItemVisibility.Description == Public ? i.Description : null,
					SendDue = dateTimeProvider.GetCurrentDate()
						.AddDays(SendDueDateDaysAfterNow),
					DeliverDue = dateTimeProvider.GetCurrentDate()// TODO: automatize according to buyer distance
						.AddDays(SendDueDateDaysAfterNow)
						.AddDays(DeliverDueDateDaysAfterSend),
					SellerComment = SellerDefaultComment,
					BuyerComment = offerData.MessageFromBuyer,
					BarterId = offerData.BarterItemId,
					BarterName = offerData.BarterName,
					BarterDescription = offerData.BarterDescription,
					BarterPictureId = offerData.BarterPictureId,
					BarterQuantity = offerData.BarterQuantity,
					BarterUnitSymbol = offerData.BarterUnitSymbol,

					OfferId = offerId

					//DeliveryAddress = ...  TODO: get address from new user property Address (if set)

				})
				.SingleAsync();

			return model;
		}

		public async Task<ContractFormViewModel> GetForCreateAsync(ContractFormViewModel model, Guid itemId, Guid buyerId)
		{
			ContractFormViewModel previewModel = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ContractFormViewModel
				{
					SellerName = i.ItemVisibility.Owner == Public ? i.Owner.UserName : null,
					SellerEmail = i.ItemVisibility.Owner == Public ? i.Owner.Email : null,
					SellerPhone = i.ItemVisibility.Owner == Public ? i.Owner.PhoneNumber : null,

					BuyerName = model.ConsentBuyerInfo ? model.BuyerName : null,
					BuyerEmail = model.ConsentBuyerInfo ? model.BuyerEmail : null,
					BuyerPhone = model.ConsentBuyerInfo ? model.BuyerPhone : null,

					ItemId = i.Id,
					Price = (decimal)i.CurrentPrice!,
					TotalPrice = (((decimal)i.CurrentPrice!) * model.Quantity).ToString("N2"),//
					CurrencySymbol = i.Currency!.Symbol,
					UnitSymbol = i.Unit.Symbol,
					ItemName = i.Name,
					ItemPictureId = i.MainPictureId,
					ItemDescription = i.ItemVisibility.Description == Public ? i.Description : null,

					ConsentBuyerInfo = model.ConsentBuyerInfo,
					Quantity = model.Quantity,//
					SendDue = model.SendDue,
					DeliverDue = model.DeliverDue,
					SellerComment = model.SellerComment,
					BuyerComment = model.BuyerComment,
					DeliveryAddress = model.DeliveryAddress
				})
				.SingleAsync();

			return previewModel;
		}

		public async Task<ContractFormViewModel> GetForCreateAsync(ContractFormViewModel model, Guid itemId, Guid buyerId, Guid offerId)
		{
			var buyerData = await dbContext.Users
				.Where(u => u.Id == buyerId)
				.Select(u => new
				{
					Name = u.UserName,
					Email = u.EmailConfirmed ? u.Email : null,
					Phone = u.PhoneNumberConfirmed ? u.PhoneNumber : null
				})
				.SingleAsync();

			var offerData = await dbContext.Offers
				.AsNoTracking()
				.Where(o => o.Id == offerId)
				.Select(o => new
				{
					o.BarterItemId,
					o.BarterQuantity,
					BarterName = o.BarterItem != null ? o.BarterItem.Name : null,
					BarterUnitSymbol = o.BarterItem != null ? o.BarterItem.Unit.Symbol : null,
					BarterPictureId = o.BarterItem != null ? (Guid?)o.BarterItem.MainPictureId : null,
					BarterDescription = o.BarterItem != null ? o.BarterItem.Description : null,
					MessageFromBuyer = o.Message,
					OfferQuantity = o.Quantity,
					OfferValue = o.Value,
					o.UseBuyerEmail,
					o.UseBuyerName,
					o.UseBuyerPhone
				})
				.SingleAsync();

			ContractFormViewModel previewModel = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ContractFormViewModel
				{
					SellerName = i.ItemVisibility.Owner == Public ? i.Owner.UserName : null,
					SellerEmail = i.ItemVisibility.Owner == Public ? i.Owner.Email : null,
					SellerPhone = i.ItemVisibility.Owner == Public ? i.Owner.PhoneNumber : null,


					ItemId = i.Id,
					Price = offerData.OfferValue,
					Quantity = offerData.OfferQuantity,
					CurrencySymbol = i.Currency!.Symbol,
					UnitSymbol = i.Unit.Symbol,
					ItemName = i.Name,
					ItemPictureId = i.MainPictureId,
					ItemDescription = i.ItemVisibility.Description == Public ? i.Description : null,



					BarterId = offerData.BarterItemId,
					BarterName = offerData.BarterName,
					BarterDescription = offerData.BarterDescription,
					BarterPictureId = offerData.BarterPictureId,
					BarterQuantity = offerData.BarterQuantity,
					BarterUnitSymbol = offerData.BarterUnitSymbol,

					OfferId = offerId,

					//DeliveryAddress = ...  TODO: get address from new user property Address (if set)
					BuyerName = model.ConsentBuyerInfo ? model.BuyerName : null,
					BuyerEmail = model.ConsentBuyerInfo ? model.BuyerEmail : null,
					BuyerPhone = model.ConsentBuyerInfo ? model.BuyerPhone : null,
					TotalPrice = (offerData.OfferValue * offerData.OfferQuantity).ToString("N2"),//
					ConsentBuyerInfo = model.ConsentBuyerInfo,

					SendDue = model.SendDue,
					DeliverDue = model.DeliverDue,
					SellerComment = model.SellerComment,
					BuyerComment = model.BuyerComment,
					DeliveryAddress = model.DeliveryAddress

				})
				.SingleAsync();

			return previewModel;
		}

		public async Task CreateAsync(ContractFormViewModel previewModel, Guid itemId, Guid buyerId)
		{
			Item item = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.SingleAsync();

			decimal itemQuantity = item.Quantity;

			item.Quantity = itemQuantity - previewModel.Quantity; // TODO: extract to different service

			Items.Data.Models.Contract contract = new Items.Data.Models.Contract
			{
				BuyerOk = true,

				SellerId = item.OwnerId, // TODO: as long as there's soft delete the item owner can be extracted
				BuyerId = buyerId,

				SellerName = previewModel.SellerName,
				SellerEmail = previewModel.SellerEmail,
				SellerPhone = previewModel.SellerPhone,

				BuyerName = previewModel.ConsentBuyerInfo ? previewModel.BuyerName : null,
				BuyerEmail = previewModel.ConsentBuyerInfo ? previewModel.BuyerEmail : null,
				BuyerPhone = previewModel.ConsentBuyerInfo ? previewModel.BuyerPhone : null,

				ItemId = itemId,
				Price = previewModel.Price,
				CurrencyId = (int)item.CurrencyId!,//  WARNING: observe the risk of changing model currency in the interval between the model check and the save changes! - it's practically zero due to isOnTheMarketCheck and Forbidding to Edit When on market;
				UnitId = item.UnitId,//  WARNING: observe the risk of changing model currency in the interval between the model check and the save changes!- it's practically zero due to isOnTheMarketCheck and Forbidding to Edit When on market;
				ItemName = previewModel.ItemName,

				ItemDescription = previewModel.ItemDescription,

				Quantity = previewModel.Quantity,
				SendDue = previewModel.SendDue,
				DeliverDue = previewModel.DeliverDue,
				SellerComment = previewModel.SellerComment,
				BuyerComment = previewModel.BuyerComment,
				DeliveryAddress = previewModel.DeliveryAddress
			};


			var publicItemImageIds = await fileIdentifierService.PublicFilesByItemIdAsync(itemId);
			var mainItemPictureId = previewModel.ItemPictureId;

			IEnumerable<FileServiceModel> itemFiles =
				await fileService.GetManyAsync(publicItemImageIds.Except(new List<Guid> { mainItemPictureId }));
			var copiedItemImageIds = (await fileService.AddManyAsync(itemFiles)).ToList();

			var itemMainPicture = await fileService.GetAsync(mainItemPictureId);
			var copiedItemMainPictureId = await fileService.AddAsync(itemMainPicture);

			copiedItemImageIds.Add(copiedItemMainPictureId);
			contract.ItemMainPictureId = copiedItemMainPictureId;

			foreach (var copiedItemImageId in copiedItemImageIds)
			{
				FileIdentifier fi = new FileIdentifier
				{
					BuyerContractId = contract.Id,
					FileId = copiedItemImageId,
					OwnerId = contract.SellerId,
					CoOwnerId = contract.BuyerId
				};
				dbContext.FileIdentifiers.Add(fi);
			}

			dbContext.Contracts.Add(contract);



			await fileService.SaveChangesAsync();

			await dbContext.SaveChangesAsync();
		}

		public async Task<Guid> CreateAsync(ContractFormViewModel model, Guid itemId, Guid buyerId, Guid offerId)
		{
			var buyerData = await dbContext.Users
				.Where(u => u.Id == buyerId)
				.Select(u => new
				{
					Name = u.UserName,
					Email = u.EmailConfirmed ? u.Email : null,
					Phone = u.PhoneNumberConfirmed ? u.PhoneNumber : null
				})
				.FirstAsync();


			var offerData = await dbContext.Offers
				.AsNoTracking()
				.Where(o => o.Id == offerId)
				.Select(o => new
				{
					o.BarterItemId,
					o.BarterQuantity,
					BarterName = o.BarterItem != null ? o.BarterItem.Name : null,
					BarterUnitSymbol = o.BarterItem != null ? o.BarterItem.Unit.Symbol : null,
					BarterPictureId = o.BarterItem != null ? (Guid?)o.BarterItem.MainPictureId : null,
					BarterDescription = o.BarterItem != null ? o.BarterItem.Description : null,
					MessageFromBuyer = o.Message,
					OfferQuantity = o.Quantity,
					OfferValue = o.Value,
					o.UseBuyerEmail,
					o.UseBuyerName,
					o.UseBuyerPhone
				})
				.FirstAsync();
			Offer offer = (await dbContext.Offers.FindAsync(offerId))!;

			Item item = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.FirstAsync();
			Item? barterItem = null;
			if (offerData.BarterItemId != null)
			{
				barterItem = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == offerData.BarterItemId)
				.FirstAsync();

				barterItem.Quantity -= (decimal)offerData.BarterQuantity!;
				barterItem.PromisedQuantity -= (decimal)offerData.BarterQuantity!;
			}


			item.Quantity -= offerData.OfferQuantity; // TODO: extract to different service
			item.PromisedQuantity -= offerData.OfferQuantity;


			dbContext.Offers.Remove(offer);

			Items.Data.Models.Contract contract = new Items.Data.Models.Contract
			{
				BuyerOk = true,

				SellerId = item.OwnerId, // TODO: as long as there's soft delete the item owner can be extracted
				BuyerId = buyerId,

				SellerName = model.SellerName,
				SellerEmail = model.SellerEmail,
				SellerPhone = model.SellerPhone,

				BuyerName = model.ConsentBuyerInfo ? model.BuyerName : null,
				BuyerEmail = model.ConsentBuyerInfo ? model.BuyerEmail : null,
				BuyerPhone = model.ConsentBuyerInfo ? model.BuyerPhone : null,

				ItemId = itemId,
				Price = offerData.OfferValue,
				CurrencyId = (int)item.CurrencyId!,//  WARNING: observe the risk of changing model currency in the interval between the model check and the save changes! - it's practically zero due to isOnTheMarketCheck and Forbidding to Edit When on market;
				UnitId = item.UnitId,//  WARNING: observe the risk of changing model currency in the interval between the model check and the save changes!- it's practically zero due to isOnTheMarketCheck and Forbidding to Edit When on market;
				ItemName = model.ItemName,

				ItemDescription = model.ItemDescription,

				Quantity = model.Quantity,
				SendDue = model.SendDue,
				DeliverDue = model.DeliverDue,
				SellerComment = model.SellerComment,
				BuyerComment = model.BuyerComment,
				DeliveryAddress = model.DeliveryAddress,

				BarterId = offerData.BarterItemId,
				BarterDescription = offerData.BarterDescription,
				BarterName = offerData.BarterName,
				BarterQuantity = offerData.BarterQuantity??0,
				BarterUnitId = barterItem?.UnitId,

			};


			//--------copy item images to contract-----------
			var publicItemImageIds = await fileIdentifierService.PublicFilesByItemIdAsync(itemId);
			var mainItemPictureId = model.ItemPictureId;

			IEnumerable<FileServiceModel> itemFiles =
				await fileService.GetManyAsync(publicItemImageIds.Except(new List<Guid> { mainItemPictureId }));
			var copiedItemImageIds = (await fileService.AddManyAsync(itemFiles)).ToList();

			var itemMainPicture = await fileService.GetAsync(mainItemPictureId);
			var copiedItemMainPictureId = await fileService.AddAsync(itemMainPicture);

			copiedItemImageIds.Add(copiedItemMainPictureId);
			contract.ItemMainPictureId = copiedItemMainPictureId;

			foreach (var copiedItemImageId in copiedItemImageIds)
			{
				FileIdentifier fi = new FileIdentifier
				{
					BuyerContractId = contract.Id,
					FileId = copiedItemImageId,
					OwnerId = contract.SellerId,
					CoOwnerId = contract.BuyerId
				};
				dbContext.FileIdentifiers.Add(fi);
			}
			//------------copy barter images to  contract------------
			if (barterItem != null)
			{
				var publicBarterImageIds = await fileIdentifierService.PublicFilesByItemIdAsync(barterItem.Id);
				var mainBarterPictureId = (Guid)offerData.BarterPictureId!;

				IEnumerable<FileServiceModel> barterFiles =
					await fileService.GetManyAsync(publicBarterImageIds.Except(new List<Guid> { mainBarterPictureId }));
				var copiedBarterImageIds = (await fileService.AddManyAsync(barterFiles)).ToList();

				var barterMainPicture = await fileService.GetAsync(mainBarterPictureId);
				var copiedBarterMainPictureId = await fileService.AddAsync(barterMainPicture);

				copiedBarterImageIds.Add(copiedBarterMainPictureId);
				contract.BarterMainPictureId = copiedBarterMainPictureId;

				foreach (var copiedBarterImageId in copiedBarterImageIds)
				{
					FileIdentifier fi = new FileIdentifier
					{
						SellerContractId = contract.Id,
						FileId = copiedBarterImageId,
						OwnerId = contract.BuyerId,
						CoOwnerId = contract.SellerId
					};
					dbContext.FileIdentifiers.Add(fi);
				}
			}
			
			//-----------------------------

			dbContext.Contracts.Add(contract);



			await fileService.SaveChangesAsync();

			await dbContext.SaveChangesAsync();
			return contract.Id;
		}

		public async Task<ContractViewModel> GetForDetailsAsync(Guid contractId)
		{
			ContractViewModel model = await dbContext.Contracts
				.AsNoTracking()
				.Where(c => c.Id == contractId)
				.Select(c => new ContractViewModel
				{

					SellerName = c.SellerName,
					SellerEmail = c.SellerName,
					SellerPhone = c.SellerPhone,

					BuyerName = c.BuyerName,
					BuyerEmail = c.BuyerEmail,
					BuyerPhone = c.BuyerPhone,

					TotalPrice = (c.Price * c.Quantity).ToString("N2"),

					Price = c.Price,
					CurrencySymbol = c.Currency.Symbol,
					Quantity = c.Quantity,
					UnitSymbol = c.Unit.Symbol,
					ItemName = c.ItemName,
					ItemMainPictureId = c.ItemMainPictureId,
					ItemDescription = c.ItemDescription,
					SendDue = c.SendDue,
					DeliverDue = c.DeliverDue,

					SellerComment = c.SellerComment,
					BuyerComment = c.BuyerComment,

					DeliveryAddress = c.DeliveryAddress,

					BarterId = c.BarterId,
					BarterPictureId = c.BarterMainPictureId,
					BarterDescription = c.BarterDescription,
					BarterName = c.BarterName,
					BarterQuantity = c.BarterQuantity,
					BarterUnitSymbol = c.BarterUnit!.Symbol
				})
				.SingleAsync();

			return model;
		}

		public async Task<bool> SellerOrBuyerAsync(Guid contractId, Guid userId)
		{
			bool result = await dbContext.Contracts
				.AnyAsync(c => c.Id == contractId && c.BuyerId == userId || c.SellerId == userId);

			return result;
		}

		public async Task<bool> CanReviseAsync(Guid id, Guid userId)
		{
			bool result = await dbContext.Contracts
				.AnyAsync(c =>
					(c.Id == id && (c.SellerId == userId || c.BuyerId == userId)) &&
					((c.SellerOk && !c.BuyerOk && c.BuyerId == userId) ||
					(!c.SellerOk && c.BuyerOk && c.SellerId == userId)));

			return result;
		}

		public async Task<bool> IsSellerAsync(Guid id, Guid userId)
		{
			bool result = await dbContext.Contracts
				.AnyAsync(c => c.Id == id && c.SellerId == userId);

			return result;
		}

		public async Task<ContractFormViewModel> GetForRevise(Guid id, Guid userId)
		{
			ContractFormViewModel model = await dbContext.Contracts
				.AsNoTracking()
				.Where(c => c.Id == id)
				.Select(c => new ContractFormViewModel
				{
					Id = id,
					IsSeller = c.SellerId == userId,

					SellerName = c.SellerName,
					SellerEmail = c.SellerName,
					SellerPhone = c.SellerPhone,

					BuyerName = c.BuyerName,
					BuyerEmail = c.BuyerEmail,
					BuyerPhone = c.BuyerPhone,

					TotalPrice = (c.Price * c.Quantity).ToString("N2"),

					Price = c.Price,
					CurrencySymbol = c.Currency.Symbol,
					Quantity = c.Quantity,
					UnitSymbol = c.Unit.Symbol,
					ItemName = c.ItemName,
					ItemPictureId = c.ItemMainPictureId,
					ItemDescription = c.ItemDescription,
					SendDue = c.SendDue,
					DeliverDue = c.DeliverDue,

					SellerComment = c.SellerComment,
					BuyerComment = c.BuyerComment,

					DeliveryAddress = c.DeliveryAddress,

					BarterId = c.BarterId,
					BarterPictureId = c.BarterMainPictureId,
					BarterDescription = c.BarterDescription,
					BarterName = c.BarterName,
					BarterQuantity = c.BarterQuantity,
					BarterUnitSymbol = c.BarterUnit!.Symbol
				})
				.SingleAsync();

			return model;
		}

		public async Task CancelAsync(Guid id, Guid userId)
		{
			Items.Data.Models.Contract contract = await dbContext.Contracts
				.Include(c => c.Item)
				.Include(c => c.Barter)
				.FirstAsync(c => c.Id == id);//&& c.SellerId == userId || c.BuyerId == userId);

			contract.BuyerOk = false;
			contract.SellerOk = false;

			// TODO: move this block to separate service method!
			try
			{
				Item item = contract.Item!;
				item.Quantity += contract.Quantity;

				Item? barter = contract.Barter;
				if (barter != null)
				{
					barter.Quantity += contract.BarterQuantity;
				}



				contract.ItemId = null;
				contract.BarterId = null;
			}
			catch (Exception e)
			{
				// TODO: message to  the seller and/or add to  log
			}

			await dbContext.SaveChangesAsync();
		}

		public async Task SetSignedAsync(Guid id)
		{
			Items.Data.Models.Contract deal = await dbContext.Contracts
				.SingleAsync(c => c.Id == id);

			deal.BuyerOk = true;
			deal.SellerOk = true;
			deal.ContractDate = dateTimeProvider.GetCurrentDateTime();

			await dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(Guid id, ContractFormViewModel model)
		{
			Items.Data.Models.Contract contract = await dbContext.Contracts
				.SingleAsync(c => c.Id == id);

			contract.DeliverDue = model.DeliverDue;
			contract.SendDue = model.SendDue;
			contract.DeliveryAddress = model.DeliveryAddress;

			bool isBuyerReviser = !contract.BuyerOk;

			if (isBuyerReviser && (contract.BuyerComment ?? string.Empty).Trim() != (model.BuyerComment ?? string.Empty).Trim())
			{
				contract.BuyerComment = model.BuyerComment;
			}
			else if (
				!isBuyerReviser &&
				(contract.SellerComment ?? string.Empty).Trim() != (model.SellerComment ?? string.Empty).Trim())
			{
				contract.SellerComment = model.SellerComment;
			}

			await dbContext.SaveChangesAsync();

		}

		public async Task ChangeReviserAsync(Guid id)
		{
			Items.Data.Models.Contract contract = await dbContext.Contracts
				.SingleAsync(c => c.Id == id);

			contract.BuyerOk = !contract.BuyerOk;
			contract.SellerOk = !contract.SellerOk;

			await dbContext.SaveChangesAsync();
		}

		public async Task<bool> SignedAsync(Guid id)
		{
			bool result = await dbContext.Contracts
				.AnyAsync(c => c.Id == id && c.BuyerOk && c.SellerOk);

			return result;
		}

		public async Task CompleteAsync(Guid id, Guid userId)
		{
			Items.Data.Models.Contract contract = await dbContext.Contracts
				.SingleAsync(c => c.Id == id);

			if (contract.SellerId == userId)
			{
				contract.SellerReceived = true;
			}
			else if (contract.BuyerId == userId)
			{
				contract.BuyerReceived = true;
			}

			await dbContext.SaveChangesAsync();
		}

		public async Task<bool> CanComplainAsync(Guid id, Guid userId)
		{
			bool result = await dbContext.Contracts
				.AnyAsync(c => c.Id == id &&
				c.BuyerOk && c.SellerOk &&
				(!c.BuyerReceived && c.BuyerId == userId) || (!c.SellerReceived && c.SellerId == userId) &&
				c.DeliverDue < dateTimeProvider.GetCurrentDate());

			return result;
		}

		public async Task<bool> IsBuyerAsync(Guid dealId, Guid userId)
		{
			bool result = await dbContext.Contracts
				.AnyAsync(c => c.Id == dealId && c.BuyerId == userId);

			return result;
		}

		public async Task CopyBuyerContractImagesToItemAsync(Guid contractId, Guid itemId, IEnumerable<Guid> imagesToDelete, Guid mainImageId)
		{
			var item = await dbContext.Items
				.FindAsync(itemId) ?? throw new ArgumentNullException("Item id doesn't exist!");

			var contractItemImageIds = await dbContext.FileIdentifiers
				.Where(fi => fi.BuyerContractId == contractId && !imagesToDelete.Contains(fi.FileId))
				.Select(fi => fi.FileId)
				.ToArrayAsync();
			var contractItemImages = await fileService.GetManyAsync(contractItemImageIds);

			var copiedItemImageIds = await fileService.AddManyAsync(contractItemImages);

			foreach (var copiedItemImageId in copiedItemImageIds)
			{
				FileIdentifier fi = new FileIdentifier
				{
					IsPublic = false,
					OwnerId = item.OwnerId,
					CoOwnerId = null,
					ItemId = item.Id,
					FileId = copiedItemImageId
				};
				await dbContext.FileIdentifiers.AddAsync(fi);
			}
			item.MainPictureId = mainImageId;

			await fileService.SaveChangesAsync();
			await dbContext.SaveChangesAsync();

		}


	}
}
