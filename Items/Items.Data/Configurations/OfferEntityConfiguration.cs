namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OfferEntityConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder
                .HasOne(e => e.Buyer)
                .WithMany(e => e.Offers)
                .HasForeignKey(e => e.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Item)
                .WithMany(e => e.Offers)
                .HasForeignKey(e => e.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.BarterItem)
                .WithMany(e => e.AsBarterForOffers)
                .HasForeignKey(e => e.BarterItemId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder
                .HasOne(e => e.Currency)
                .WithMany()
                .HasForeignKey(e => e.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
