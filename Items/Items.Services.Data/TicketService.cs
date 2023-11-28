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

		public async Task<AllTicketInfoServiceModel> GetAllAsync(TicketQueryModel? queryModel = null)
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

				string[]? statusesToInclude = queryModel.IncludeStatuses;
				if (statusesToInclude != null && statusesToInclude.Length > 0)
				{
					query = query
						.Where(t => statusesToInclude.Contains(t.TicketStatus.Name));
				}

				string[]? typesToInclude = queryModel.IncludeTypes;
				if (typesToInclude != null && typesToInclude.Length > 0)
				{
					query = query
						.Where(t => typesToInclude.Contains(t.TicketType.Name));
				}
			}
			int totalCount = await query.CountAsync();


			int hitsPerPage = queryModel?.HitsPerPage ?? Query.HitsPerPage;
			int currentPage = queryModel?.CurrentPage ?? Query.CurrentPage;
			query = query
				.Skip((currentPage - 1) * hitsPerPage)
				.Take(hitsPerPage);

			AllTicketServiceModel[] tickets = await query
				.Select(t => new AllTicketServiceModel
				{
					Id = t.Id,
					Title = t.Title,
					Type = t.TicketType.Name,
					Status = t.TicketStatus.Name
				})
				.ToArrayAsync();


			AllTicketInfoServiceModel result = new AllTicketInfoServiceModel
			{
				Tickets = tickets,
				TotalCount = totalCount
			};

			return result;

		}
	}
}
