namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserContractConfiguration : IEntityTypeConfiguration<UserContract>
    {
        public void Configure(EntityTypeBuilder<UserContract> builder)
        {
            builder
                .HasKey(e => new { e.UserId, e.ContractId });

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.UsersContracts)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Contract)
                .WithMany(e => e.UsersContracts)
                .HasForeignKey(e => e.ContractId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
