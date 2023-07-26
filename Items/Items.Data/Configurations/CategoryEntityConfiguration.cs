namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasOne(e => e.Creator)
                .WithMany(e => e.Categories)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(GenerateCategories());
        }



        private Category[] GenerateCategories()
        {
            List<Category> categories = new List<Category>();

            Category category = new Category
            {
                CreatorId = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                Id = 1,
                Name = "Various"
            };
            categories.Add(category);

            category = new Category
            {
                CreatorId = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                Id = 2,
                Name = "Toys"
            };
            categories.Add(category);
            
            category = new Category
            {
                CreatorId = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                Id = 3,
                Name = "Cars"
            };
            categories.Add(category);

            category = new Category
            {
                CreatorId = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                Id = 4,
                Name = "Weapons"
            };
            categories.Add(category);
            
            category = new Category
            {
                CreatorId = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                Id = 5,
                Name = "Puzzles"
            };
            categories.Add(category);


            return categories.ToArray();
        }
    }
}
