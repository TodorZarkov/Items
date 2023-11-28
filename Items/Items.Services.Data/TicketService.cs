namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.Ticket;
	using static Items.Common.TicketConstants;

	using System;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;

	public class TicketService : ITicketService
	{
		private readonly ItemsDbContext dbContext;

		public TicketService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public Task<Guid> AddTicketServiceModel(TicketFormServiceModel model)
		{
			throw new NotImplementedException();
		}

		public Task<AllTicketInfoServiceModel> GetAllAsync(TicketQueryModel? queryModel = null)
		{
			var query = dbContext.Tickets
				.AsNoTracking()
				.AsQueryable()
				.Where(t => t.TicketStatus.Name != Statuses.DELETE);

			if (queryModel is not null)
			{
				string? searchTerm = queryModel.SearchTerm;
				if (searchTerm is not null)
				{
					query = query
					.Where(
						t => t.Title.ToUpper().Contains(searchTerm) ||
							(t.Description != null && t.Description.ToUpper().Contains(searchTerm))
					);
				}




			}
		}
	}
}
