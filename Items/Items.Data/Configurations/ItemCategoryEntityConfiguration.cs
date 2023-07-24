namespace Items.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Items.Data.Models;

    public class ItemCategoryEntityConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder
                .HasKey(e => new { e.CategoryId, e.ItemId });

            builder
                .HasOne(e => e.Item)
                .WithMany(e => e.ItemsCategories)
                .HasForeignKey(e => e.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Category)
                .WithMany(e => e.ItemsCategories)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
