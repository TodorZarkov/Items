    namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using System;

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

            builder
                .HasData(GenerateOffers());
        }

		private Offer[] GenerateOffers()
		{
            List<Offer> offers = new List<Offer>();

            Offer offer = new Offer
            {
                Id = Guid.Parse("71F73811-33DC-45A8-A3FE-A7D5A2363833"),
                ItemId = Guid.Parse("70AB6375-3DA7-41CB-B80C-DCEE2BA4FBBB"),//pesho's mustang
                BuyerId = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),//stamat
                CurrencyId = 1, //usd
                Expires = DateTime.Parse("01-08-2024"), //it's the item endSell date by Architecture
                Quantity = 1m,
                Value = 60m,
                BarterItemId = null,
                BarterQuantity = null
			};
            offers.Add(offer);
            
            return offers.ToArray();
		}
	}
}
