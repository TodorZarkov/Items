namespace Items.Data.Configurations
{
	using Items.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasOne(e => e.Owner)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Location)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Place)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.PlaceId)
                .OnDelete(DeleteBehavior.Restrict);

             builder
                .HasOne(e => e.AcquireDocument)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(e => e.Unit)
                .WithMany()
                .HasForeignKey(e => e.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.Currency)
                .WithMany()
                .HasForeignKey(i => i.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.ItemVisibility)
                .WithOne(iv => iv.Item)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasMany(i => i.Contracts)
                .WithOne(c => c.Item)
                .HasForeignKey(c => c.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(i => i.ItemPictures)
                .WithOne(f => f.Item)
                .HasForeignKey(f => f.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
