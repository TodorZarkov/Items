namespace Items.Data
{

    using Items.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ItemsDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options)
            : base(options)
        {
        }
    }
}