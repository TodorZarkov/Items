namespace Items.Data.Seeders
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static Items.Common.TicketConstants.Types;

    public static class TicketTypeSeeder
    {
        public static ModelBuilder SeedTicketTypes(this ModelBuilder builder)
        {
            builder
                .Entity<TicketType>()
                .HasData(GenerateTicketTypes());

            return builder;
        }

        private static TicketType[] GenerateTicketTypes()
        {
            TicketType[] types = new[]
            {
                new TicketType
                {
                    Id = 1,
                    Name = BUG
                },
                new TicketType
                {
                    Id = 2,
                    Name = NEW_CATEGORY
                },
                new TicketType
                {
                    Id = 3,
                    Name = NEW_CURRENCY
                },
                new TicketType
                {
                    Id = 4,
                    Name = NEW_UNIT
                }
            };

            return types;
        }
    }
}
