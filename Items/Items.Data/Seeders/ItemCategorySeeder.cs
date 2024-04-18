namespace Items.Data.Seeders
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public static class ItemCategorySeeder
    {
        public static ModelBuilder SeedItemsCategories(this ModelBuilder builder)
        {
            builder
                .Entity<ItemCategory>()
                .HasData(GenerateItemsCategories());

            return builder;
        }

        private static ItemCategory[] GenerateItemsCategories()
        {
            List<ItemCategory> itemsCategories = new List<ItemCategory>();

            ItemCategory itemCategory = new ItemCategory
            {
                CategoryId = 2,
                ItemId = Guid.Parse("70AB6375-3DA7-41CB-B80C-DCEE2BA4FBBB"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 3,
                ItemId = Guid.Parse("70AB6375-3DA7-41CB-B80C-DCEE2BA4FBBB"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 2,
                ItemId = Guid.Parse("E4D2697E-8EDF-49F5-BAC0-BC76DFBB43EE"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 3,
                ItemId = Guid.Parse("E4D2697E-8EDF-49F5-BAC0-BC76DFBB43EE"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 2,
                ItemId = Guid.Parse("EA486471-25CA-40C5-BDCE-C7C4157EB1B0"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 3,
                ItemId = Guid.Parse("EA486471-25CA-40C5-BDCE-C7C4157EB1B0"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 2,
                ItemId = Guid.Parse("2AA8B934-59F3-473B-842E-3DF2A3590B92"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 3,
                ItemId = Guid.Parse("2AA8B934-59F3-473B-842E-3DF2A3590B92"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 2,
                ItemId = Guid.Parse("7EC3D946-D2EF-4D54-A98E-00EA2B2E8B45"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 3,
                ItemId = Guid.Parse("7EC3D946-D2EF-4D54-A98E-00EA2B2E8B45"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 2,
                ItemId = Guid.Parse("EA9141C8-8C5B-4126-9A30-7A82796E922C"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 3,
                ItemId = Guid.Parse("EA9141C8-8C5B-4126-9A30-7A82796E922C"),
            };
            itemsCategories.Add(itemCategory);



            itemCategory = new ItemCategory
            {
                CategoryId = 2,
                ItemId = Guid.Parse("CC1A92FF-E773-4D37-8D66-DDB31AB612B2"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 5,
                ItemId = Guid.Parse("CC1A92FF-E773-4D37-8D66-DDB31AB612B2"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 3,
                ItemId = Guid.Parse("CC1A92FF-E773-4D37-8D66-DDB31AB612B2"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 2,
                ItemId = Guid.Parse("A0F0C44B-1BA4-484D-9C36-498579B61D37"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 5,
                ItemId = Guid.Parse("A0F0C44B-1BA4-484D-9C36-498579B61D37"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 3,
                ItemId = Guid.Parse("A0F0C44B-1BA4-484D-9C36-498579B61D37"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 2,
                ItemId = Guid.Parse("A676AF29-2FD2-4E17-918D-73EC948CDC73"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 5,
                ItemId = Guid.Parse("A676AF29-2FD2-4E17-918D-73EC948CDC73"),
            };
            itemsCategories.Add(itemCategory);

            itemCategory = new ItemCategory
            {
                CategoryId = 3,
                ItemId = Guid.Parse("A676AF29-2FD2-4E17-918D-73EC948CDC73"),
            };
            itemsCategories.Add(itemCategory);


            return itemsCategories.ToArray();
        }
    }
}
