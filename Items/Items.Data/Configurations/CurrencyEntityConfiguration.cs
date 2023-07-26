namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CurrencyEntityConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder
                .HasData(GenerateCurrencies());
        }

        private Currency[] GenerateCurrencies()
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
