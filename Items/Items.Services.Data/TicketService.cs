namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.Ticket;
	using static Items.Common.TicketConstants;
	using Items.Data.Models;

	using System;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;
	using Items.Services.Data.Models.File;
	using System.Net.Mime;

	public class TicketService : ITicketService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IFileService fileService;

		public TicketService(ItemsDbContext dbContext, IFileService fileService)
		{
			this.dbContext = dbContext;
			this.fileService = fileService;
		}

		public async Task<Guid> AddAsync(Guid userId, TicketFormServiceModel model)
		{
			TicketStatus openStatus = await dbContext.TicketStatuses
				.FirstAsync(s => s.Name == Statuses.OPEN);

			Ticket ticket = new Ticket
			{
				AuthorId = userId,
				Description = model.Description,
				Title = model.Title,
				TypeId = model.TypeId,
				TicketStatus = openStatus
			};

			if (model.Snapshot != null)
			{
				using (MemoryStream stream = new MemoryStream())
				{
					await model.Snapshot.CopyToAsync(stream);
					var fileModel = new FileServiceModel
					{
						Bytes = stream.ToArray(),
						MimeType = MediaTypeNames.Image.Jpeg
					};
					ticket.SnapshotId = await fileService.AddAsync(fileModel);
				}
			}

			await dbContext.Tickets.AddAsync(ticket);

			await dbContext.SaveChangesAsync();

			return ticket.Id;
		}

		public Task EditAsync(Guid guid, Guid ticketId, TicketEditServiceModel ticketEditModel)
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

		public async Task<TicketDetailsServiceModel> GetAsync(Guid ticketId)
		{
			TicketDetailsServiceModel ticket = await dbContext.Tickets
			.Where(t => t.Id == ticketId)
			.Select(t => new TicketDetailsServiceModel
			{
				Title = t.Title,
				Description = t.Description,
				TicketType = t.TicketType.Name,
				TicketStatus = t.TicketStatus.Name,
				AssigneeId = t.AssigneeId,
				AssigneeName = t.Assignee != null ? t.Assignee.UserName : null,
				AssignerId = t.AssignerId,
				AssignerName = t.Assigner != null ? t.Assigner.UserName : null,
				AuthorId = t.AuthorId,
				AuthorName = t.Author.UserName,
				Snapshot = t.Snapshot != null ? t.Snapshot.Bytes : null
			})
			.FirstAsync();


			return ticket;
		}
	}
}
