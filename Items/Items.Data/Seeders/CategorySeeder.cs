namespace Items.Data.Seeders
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public static class CategorySeeder
    {
        public static ModelBuilder SeedCategories(this ModelBuilder builder)
        {

            builder
                .Entity<Category>()
                .HasData(GenerateCategories());

            return builder;
        }

        private static Category[] GenerateCategories()
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

            category = new Category
            {
                CreatorId = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),
                Id = 6,
                Name = "Instruments"
            };
            categories.Add(category);


            return categories.ToArray();
        }
    }
}
