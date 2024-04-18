namespace Items.Data.Seeders
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public static class CurrencySeeder
    {
        public static ModelBuilder SeedCurrencies(this ModelBuilder builder)
        {
            builder
                .Entity<Currency>()
                .HasData(GenerateCurrencies());

            return builder;
        }

        private static Currency[] GenerateCurrencies()
        {
            List<Currency> currencies = new List<Currency>();

            Currency currency = new Currency
            {
                Id = 1,
                IsoCode = "USD",
                Symbol = "$",
                Name = "United States dollar"
            };
            currencies.Add(currency);

            currency = new Currency
            {
                Id = 2,
                IsoCode = "EUR",
                Symbol = "€",
                Name = "Euro"
            };
            currencies.Add(currency);

            currency = new Currency
            {
                Id = 3,
                IsoCode = "BGN",
                Symbol = "Lev",
                Name = "Bulgarian lev"
            };
            currencies.Add(currency);


            return currencies.ToArray();
        }
    }
}
