namespace Items.Services.Data
{
    using Items.Data;
    using Items.Services.Data.Interfaces;
    using Items.Services.Data.Models.TicketType;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TicketTypeService : ITicketTypeService
    {
        private readonly ItemsDbContext dbContext;

        public TicketTypeService(ItemsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllTicketTypesServiceModel>> AllAsync()
        {
            AllTicketTypesServiceModel[] allTypes = await dbContext.TicketTypes
                .Select(tt => new AllTicketTypesServiceModel
                {
                    Id = tt.Id,
                    Name = tt.Name
                })
                .ToArrayAsync();

            return allTypes;
        }
    }
}
