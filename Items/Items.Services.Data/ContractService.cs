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
	

	public class ContractService : IContractService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IDateTimeProvider dateTimeProvider;
		private readonly IHelper helper;

		public ContractService(ItemsDbContext dbContext, IDateTimeProvider dateTimeProvider, IHelper helper)
		{
			this.dbContext = dbContext;
			this.dateTimeProvider = dateTimeProvider;
			this.helper = helper;
		}


		public async Task<IEnumerable<ContractAllViewModel>> AllAsync(Guid userId)
		{
			ContractAllViewModel[] allDeals = await dbContext.Contracts
				.AsNoTracking()
				.Where(c => c.BuyerId == userId || c.SellerId == userId)
				.OrderBy(c => c.BuyerId == userId)
				.ThenByDescending(c => c.ContractDate)
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
					ItemPicture = c.ItemPictureUri,

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

			return allDeals;
		}

		

		public async Task<ContractFormViewModel> GetForPreviewByIdAsync(Guid itemId)
		{
			ContractFormViewModel model = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ContractFormViewModel
				{
					SellerName = i.ItemVisibility.Owner == Public ? i.Owner.UserName : null,
					SellerEmail = i.ItemVisibility.Owner == Public ? i.Owner.Email : null,
					SellerPhone = i.ItemVisibility.Owner == Public ? i.Owner.PhoneNumber : null,

					ItemId = i.Id,
					Price = (decimal)i.CurrentPrice!,
					CurrencySymbol = i.Currency!.Symbol,
					UnitSymbol = i.Unit.Symbol,
					ItemName = i.Name,
					ItemPictureUri = i.MainPictureUri,
					ItemDescription = i.ItemVisibility.Description == Public ? i.Description : null,
					SendDue = dateTimeProvider.GetCurrentDate()
						.AddDays(SendDueDateDaysAfterNow),
					DeliverDue = dateTimeProvider.GetCurrentDate()//todo: automatize according to buyer distance
						.AddDays(SendDueDateDaysAfterNow)
						.AddDays(DeliverDueDateDaysAfterSend),
					SellerComment = SellerDefaultComment,
					//DeliveryAddress = ... todo: get address from new user property Address (if set)

				})
				.SingleAsync();

			return model;
		}

		public async Task<ContractFormViewModel> GetForCreate(ContractFormViewModel model, Guid itemId, Guid buyerId)
		{
			ApplicationUser buyer = dbContext.Users.Single(u => u.Id == buyerId);


			ContractFormViewModel previewModel = await dbContext.Items
				.AsNoTracking()
				.Where(i => !i.Deleted)
				.Where(i => i.Id == itemId)
				.Select(i => new ContractFormViewModel
				{
					SellerName = i.ItemVisibility.Owner == Public ? i.Owner.UserName : null,
					SellerEmail = i.ItemVisibility.Owner == Public ? i.Owner.Email : null,
					SellerPhone = i.ItemVisibility.Owner == Public ? i.Owner.PhoneNumber : null,

					BuyerName = model.ConsentBuyerInfo ? buyer.UserName : null,
					BuyerEmail = model.ConsentBuyerInfo ? buyer.Email : null,
					BuyerPhone = model.ConsentBuyerInfo ? buyer.PhoneNumber : null,

					ItemId = i.Id,
					Price = (decimal)i.CurrentPrice!,
					TotalPrice = (((decimal)i.CurrentPrice!) * model.Quantity).ToString("N2"),
					CurrencySymbol = i.Currency!.Symbol,
					UnitSymbol = i.Unit.Symbol,
					ItemName = i.Name,
					ItemPictureUri = i.MainPictureUri,
					ItemDescription = i.ItemVisibility.Description == Public ? i.Description : null,

					ConsentBuyerInfo = model.ConsentBuyerInfo,
					Quantity = model.Quantity,
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

			item.Quantity = itemQuantity - previewModel.Quantity;

			Contract contract = new Contract
			{
				BuyerOk = true,

				SellerId = item.OwnerId,
				BuyerId = buyerId,

				SellerName = previewModel.SellerName,
				SellerEmail = previewModel.SellerEmail,
				SellerPhone = previewModel.SellerPhone,

				BuyerName = previewModel.ConsentBuyerInfo ? previewModel.BuyerName : null,
				BuyerEmail = previewModel.ConsentBuyerInfo ? previewModel.BuyerEmail : null,
				BuyerPhone = previewModel.ConsentBuyerInfo ? previewModel.BuyerPhone : null,

				ItemId = itemId,
				Price = previewModel.Price,
				CurrencyId = (int)item.CurrencyId!,// todo: observe the risk of changing model currency in the interval between the model check and the save changes!
				UnitId = item.UnitId,// todo: observe the risk of changing model currency in the interval between the model check and the save changes!
				ItemName = previewModel.ItemName,
				ItemPictureUri = previewModel.ItemPictureUri,
				ItemDescription = previewModel.ItemDescription,

				Quantity = previewModel.Quantity,
				SendDue = previewModel.SendDue,
				DeliverDue = previewModel.DeliverDue,
				SellerComment = previewModel.SellerComment,
				BuyerComment = previewModel.BuyerComment,
				DeliveryAddress = previewModel.DeliveryAddress
			};

			dbContext.Contracts.Add(contract);

			await dbContext.SaveChangesAsync();
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
					ItemPictureUri = c.ItemPictureUri,
					ItemDescription = c.ItemDescription,
					SendDue = c.SendDue,
					DeliverDue = c.DeliverDue,

					SellerComment = c.SellerComment,
					BuyerComment = c.BuyerComment,

					DeliveryAddress = c.DeliveryAddress
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
					(c.Id == id && c.SellerId == userId || c.BuyerId == userId) &&
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
					ItemPictureUri = c.ItemPictureUri,
					ItemDescription = c.ItemDescription,
					SendDue = c.SendDue,
					DeliverDue = c.DeliverDue,

					SellerComment = c.SellerComment,
					BuyerComment = c.BuyerComment,

					DeliveryAddress = c.DeliveryAddress
				})
				.SingleAsync();

			return model;
		}

		public async Task CancelAsync(Guid id, Guid userId)
		{
			Contract deal = await dbContext.Contracts
				.SingleAsync(c => c.Id == id && c.SellerId == userId || c.BuyerId == userId);

			deal.BuyerOk = false;
			deal.SellerOk = false;

			Item item = await dbContext.Items
				.Where(i => !i.Deleted)
				.Where(i => i.Id == (Guid)deal.ItemId!)
				.SingleAsync();
			decimal currentItemQuantity = item.Quantity;

			item.Quantity = currentItemQuantity + deal.Quantity;

			//todo: Revise Quantity behaviour according to Seller and Signing
			deal.ItemId = null;

			await dbContext.SaveChangesAsync();
		}

		public async Task SetSignedAsync(Guid id)
		{
			Contract deal = await dbContext.Contracts
				.SingleAsync(c => c.Id == id );

			deal.BuyerOk = true;
			deal.SellerOk = true;
			deal.ContractDate = dateTimeProvider.GetCurrentDateTime();

			await dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(Guid id, ContractFormViewModel model)
		{
			Contract contract = await dbContext.Contracts
				.SingleAsync(c => c.Id == id);

			contract.DeliverDue = model.DeliverDue;
			contract.SendDue = model.SendDue;
			contract.DeliveryAddress = model.DeliveryAddress;


			if ((contract.BuyerComment??string.Empty).Trim() != (model.BuyerComment??string.Empty).Trim())
			{
				contract.BuyerComment = model.BuyerComment;
			}
			else if ((contract.SellerComment ?? string.Empty).Trim() != (model.SellerComment ?? string.Empty).Trim())
			{
				contract.SellerComment = model.SellerComment;
			}

			await dbContext.SaveChangesAsync();
			
		}

		public async Task ChangeReviserAsync(Guid id)
		{
			Contract contract = await dbContext.Contracts
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
			Contract contract = await dbContext.Contracts
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

		public async Task<bool> CanComplainAndReceiveAsync(Guid id, Guid userId)
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
	}
}
