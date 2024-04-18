namespace Items.Data.Seeders
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class UserRoleSeeder
    {
        public static ModelBuilder SeedUsersRoles(this ModelBuilder builder)
        {
            builder
                .Entity<IdentityUserRole<Guid>>()
                .HasData(GenerateUsersRoles());

            return builder;
        }

        private static IdentityUserRole<Guid>[] GenerateUsersRoles()
        {
            List<IdentityUserRole<Guid>> userRoles = new List<IdentityUserRole<Guid>>();

            IdentityUserRole<Guid> userRole = new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                RoleId = Guid.Parse("B8E078AF-5CBC-4360-A99A-0AA387C563E1")
            };
            userRoles.Add(userRole);

            return userRoles.ToArray();
        }
    }
}
