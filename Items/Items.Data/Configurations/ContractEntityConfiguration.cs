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

            
        }
    }
}
