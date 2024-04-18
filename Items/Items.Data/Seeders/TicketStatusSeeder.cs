namespace Items.Data.Seeders
{
    using Items.Data.Models;
    using static Items.Common.TicketConstants.Statuses;

    using Microsoft.EntityFrameworkCore;

    public static class TicketStatusSeeder
    {
        public static ModelBuilder SeedTicketStatuses(this ModelBuilder builder)
        {
            builder
                .Entity<TicketStatus>()
                .HasData(GenerateTicketStatuses());

            return builder;
        }


        private static TicketStatus[] GenerateTicketStatuses()
        {
            TicketStatus[] statuses = new[]
            {
                new TicketStatus
                {
                    Id = 1,
                    Name = OPEN
                },
                new TicketStatus
                {
                    Id = 2,
                    Name = ASSIGN
                },
                new TicketStatus
                {
                    Id = 3,
                    Name = CLOSE
                },
                new TicketStatus
                {
                    Id = 4,
                    Name = DELETE
                }
            };

            return statuses;
        }
    }
}
