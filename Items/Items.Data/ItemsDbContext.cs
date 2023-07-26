namespace Items.Data
{

    using System.Reflection;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Items.Data.Models;

    public class ItemsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Currency> Currencies { get; set; } = null!;

        public DbSet<Document> Documents { get; set; } = null!;

        public DbSet<Item> Items { get; set; } = null!;

        public DbSet<ItemCategory> ItemsCategories { get; set; } = null!;

        public DbSet<ItemVisibility> ItemVisibilities { get; set; } = null!;

        public DbSet<Location> Locations { get; set; } = null!;

        public DbSet<LocationVisibility> LocationVisibilities { get; set; } = null!;

        public DbSet<Offer> Offers { get; set; } = null!;

        public DbSet<Picture> Pictures { get; set; } = null!;

        public DbSet<Place> Places { get; set; } = null!;


        public DbSet<Unit> Units { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Assembly configAssembly = Assembly.GetAssembly(typeof(ItemsDbContext)) ??
                Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);
        }
    }
}