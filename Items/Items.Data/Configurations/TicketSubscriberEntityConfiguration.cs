namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TicketSubscriberEntityConfiguration
        : IEntityTypeConfiguration<TicketSubscriber>
    {
        public void Configure(EntityTypeBuilder<TicketSubscriber> builder)
        {
            builder.HasKey(ts => new { ts.TicketId, ts.SubscriberId });

            builder.HasOne(ts => ts.Ticket)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ts => ts.Subscriber)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
