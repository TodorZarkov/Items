namespace Items.Data.Seeders
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public static class OfferSeeder
    {
        public static ModelBuilder SeedOffers(this ModelBuilder builder)
        {
            builder
                .Entity<Currency>()
                .HasData(GenerateOffers());

            return builder;
        }

        private static Offer[] GenerateOffers()
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
