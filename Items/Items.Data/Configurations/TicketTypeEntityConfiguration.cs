namespace Items.Data.Configurations
{
	using Items.Data.Models;
	using static Items.Common.TicketConstants.Types;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	internal class TicketTypeEntityConfiguration : IEntityTypeConfiguration<TicketType>
	{
		public void Configure(EntityTypeBuilder<TicketType> builder)
		{
			builder.HasData(GenerateTypes());
		}

		private TicketType[] GenerateTypes()
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
				}
			};

			return types;
		}
	}
}
