namespace Items.Data.Configurations
{
	using Items.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class FileIdentifierEntityConfiguration : IEntityTypeConfiguration<FileIdentifier>
	{
		public void Configure(EntityTypeBuilder<FileIdentifier> builder)
		{
			builder
				.HasOne(fi => fi.BuyerContract)
				.WithMany(c => c.ItemImages)
				.HasForeignKey(fi => fi.BuyerContractId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(fi => fi.SellerContract)
				.WithMany(c => c.BarterImages)
				.HasForeignKey(fi => fi.SellerContractId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
