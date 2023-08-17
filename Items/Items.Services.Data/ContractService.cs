namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Deal;
	using static Items.Common.FormatConstants.DateAndTime;

	using Microsoft.EntityFrameworkCore;

	using System;
	using System.Threading.Tasks;

	public class ContractService : IContractService
	{
		private readonly ItemsDbContext dbContext;

		public ContractService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<ContractAllViewModel>> AllAsync(Guid userId)
		{
			ContractAllViewModel[] allDeals = await dbContext.Contracts
				.Where(c => c.BuyerId == userId || c.SellerId == userId)
				.OrderBy(c => c.BuyerId == userId)
				.ThenByDescending(c => c.ContractDate)
				.Select(c => new ContractAllViewModel
				{
					ItemId = c.ItemId,
					ItemName = c.Item.Name,
					ItemPicture = c.Item.MainPictureUri,

					SellerOk = c.SellerOk,
					BuyerOk = c.BuyerOk,
					BuyerConfirm = c.BuyerConfirm,
					Fulfilled = c.Fulfilled,
					ContractStatus = ContractStatus(c.SellerOk, c.BuyerOk, c.BuyerConfirm, c.Fulfilled),

					BuyerComment = c.BuyerComment,
					SellerComment = c.SellerComment,

					Quantity = c.Quantity.ToString("N2"),
					Unit = c.Item.Unit.Symbol,

					Price = c.Price.ToString("N2"),
					Currency = c.Currency.Symbol,

					ContractDate = c.ContractDate.ToString(ContractDateTime),
					DeliverDue = c.DeliverDue,
					SendDue = c.SendDue.ToString(ContractDateTime),
					DeliveryAddress = c.DeliveryAddress
				})
				.ToArrayAsync();

			return allDeals;
		}

		private static string ContractStatus(bool sellerOk, bool buyerOk, bool? buyerConfirm, bool fulfilled)
		{
			string result;
			if (!fulfilled && !buyerConfirm.HasValue)
			{
				if (sellerOk && buyerOk )
				{
					result = "On Delivery";
				}
				else if (sellerOk && !buyerOk)
				{
					result = "Buyer Attention";
				}
				else if (!sellerOk && buyerOk)
				{
					result = "Seller Attention";
				}
				else
				{
					result = "No Deal!";

				}
			}
			else if (fulfilled && !buyerConfirm.HasValue)
			{
				result = "Auto Fulfilled!";
			}
			else if (fulfilled && buyerConfirm.HasValue && (bool)buyerConfirm)
			{
				result = "Buyer Received";
			}
			else if (!fulfilled && buyerConfirm.HasValue && !(bool)buyerConfirm)
			{
				result = "Bad Deal";
			}
			else
			{
				result = "ERROR!";
			}

			return result;
		}
	}
}
