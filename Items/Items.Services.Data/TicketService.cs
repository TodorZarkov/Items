namespace Items.Services.Data
{
    using Items.Data;
    using Items.Services.Data.Interfaces;
    using Items.Services.Data.Models.Ticket;
    using static Items.Common.TicketConstants;
    using static Items.Common.FormatConstants.DateAndTime;
    using Items.Data.Models;

    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Items.Services.Data.Models.File;
    using System.Net.Mime;
    using static Items.Common.EntityValidationConstants;
    using Items.Services.Common.Interfaces;

    public class TicketService : ITicketService
    {
        private readonly ItemsDbContext dbContext;
        private readonly IFileService fileService;
        private readonly IDateTimeProvider dateTimeProvider;

        public TicketService(
            ItemsDbContext dbContext,
            IFileService fileService,
            IDateTimeProvider dateTimeProvider)
        {
            this.dbContext = dbContext;
            this.fileService = fileService;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task<Guid> AddAsync(Guid userId, TicketFormServiceModel model)
        {
            Items.Data.Models.TicketStatus openStatus = await dbContext.TicketStatuses
                .FirstAsync(s => s.Name == Statuses.OPEN);

            Items.Data.Models.Ticket ticket = new Items.Data.Models.Ticket
            {
                AuthorId = userId,
                Description = model.Description,
                Title = model.Title,
                TypeId = model.TypeId,
                TicketStatus = openStatus,
                Created = dateTimeProvider.GetCurrentDateTime(),
                Modified = dateTimeProvider.GetCurrentDateTime()
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
            await fileService.SaveChangesAsync();
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
                    Status = t.TicketStatus.Name,
                    Created = t.Created.ToString(TicketDatetimeFormat),
                    Severity = t.Severity,
                    WithSameProblem = t.WithSameProblem
                        .Where(wp => wp.TicketId == t.Id)
                        .LongCount(),
                    SnapShot = null,
                    SnapshotId = t.SnapshotId
                })
                .ToArrayAsync();

            foreach (var ticket in tickets)
            {
                if (ticket.SnapshotId == null) continue;

                ticket.SnapShot = (await fileService.GetAsync((Guid)ticket.SnapshotId)).Bytes;
            }

            AllTicketInfoServiceModel result = new AllTicketInfoServiceModel
            {
                Tickets = tickets,
                TotalCount = totalCount
            };

            return result;

        }

        public async Task<TicketDetailsServiceModel> GetAsync(Guid ticketId)
        {
            var ticket = await dbContext.Tickets
                .Include(t => t.TicketType)
                .Include(t => t.TicketStatus)
                .Include(t => t.Assignee)
                .Include(t => t.Assigner)
                .Include(t => t.Author)
                .Include(t => t.WithSameProblem)
                .FirstAsync(t => t.Id == ticketId) ??
                throw new ArgumentNullException(nameof(ticketId), "The ticket id doesn't match any Ticket.");


            TicketDetailsServiceModel ticketModel =
                new TicketDetailsServiceModel
                {
                    Title = ticket.Title,
                    Description = ticket.Description,
                    TicketType = ticket.TicketType.Name,
                    TicketStatus = ticket.TicketStatus.Name,
                    AssigneeId = ticket.AssigneeId,
                    AssigneeName = ticket.Assignee?.UserName,
                    AssignerId = ticket.AssignerId,
                    AssignerName = ticket.Assigner?.UserName,
                    AuthorId = ticket.AuthorId,
                    AuthorName = ticket.Author.UserName,
                    Created = ticket.Created.ToString(TicketDatetimeFormat),
                    Severity = ticket.Severity,
                    WithSameProblem = ticket.WithSameProblem
                        .Where(wp => wp.TicketId == ticket.Id)
                        .LongCount(),
                    SnapShot = null,
                    SnapshotId = ticket.SnapshotId,
                    Modified = ticket.Modified.ToString(TicketDatetimeFormat)
                };

            if (ticket.SnapshotId != null)
            {
                FileServiceModel snapshot =
                    await fileService.GetAsync((Guid)ticket.SnapshotId);
                ticketModel.SnapShot = snapshot.Bytes;
            }


            return ticketModel;
        }
    }
}
