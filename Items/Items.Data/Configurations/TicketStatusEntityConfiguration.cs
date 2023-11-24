namespace Items.Data.Configurations
{
	using Items.Data.Models;
	using static Items.Common.TicketConstants.Statuses;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class TicketStatusEntityConfiguration : IEntityTypeConfiguration<TicketStatus>
	{
		public void Configure(EntityTypeBuilder<TicketStatus> builder)
		{
			builder.HasData(GenerateStatuses());
		}

		private TicketStatus[] GenerateStatuses()
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
