namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContractEntityConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder
                .HasOne(e => e.Currency)
                .WithMany()
                .HasForeignKey(e => e.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Unit)
                .WithMany()
                .HasForeignKey(e => e.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(e => e.BarterUnit)
				.WithMany()
				.HasForeignKey(e => e.BarterUnitId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
                .HasOne(e => e.Seller)
                .WithMany(e => e.ContractsAsSeller)
                .HasForeignKey(e => e.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Buyer)
                .WithMany(e => e.ContractsAsBuyer)
                .HasForeignKey(e => e.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
