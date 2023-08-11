namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Deal;
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

		public async Task<IEnumerable<AllDealViewModel>> AllAsync(Guid userId)
		{
			AllDealViewModel[] allDeals = await dbContext.Contracts
				.Where(c => c.BuyerId == userId || c.SellerId == userId)
				.OrderBy(c => c.BuyerId == userId)
				.ThenByDescending(c => c.ContractDate)
				.Select(c => new AllDealViewModel
				{
					
				})
				.ToArrayAsync();

			return allDeals;
		}
	}
}
