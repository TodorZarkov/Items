﻿namespace Items.Data.Configurations
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
                .HasOne(e => e.OfferedPrice)
                .WithMany()
                .HasForeignKey(e => e.OfferedPriceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
