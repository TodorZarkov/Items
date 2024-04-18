namespace Items.Data.Seeders
{
    using static Common.RoleConstants;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;


    //todo: Remove ids in production seed!
    public static class RoleSeeder
    {
        public static ModelBuilder SeedRoles(this ModelBuilder builder)
        {
            builder
                .Entity<IdentityRole<Guid>>()
                .HasData(GenerateRoles());

            return builder;
        }


        private static IdentityRole<Guid>[] GenerateRoles()
        {
            List<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>();

            IdentityRole<Guid> role = new IdentityRole<Guid>
            {
                Id = Guid.Parse("B8E078AF-5CBC-4360-A99A-0AA387C563E1"),
                Name = SuperAdmin,
                NormalizedName = SuperAdmin.ToUpper(),
                ConcurrencyStamp = "8208B486-8D31-4E5C-8BB0-05FF07CF81E0"
            };
            roles.Add(role);

            role = new IdentityRole<Guid>
            {
                Id = Guid.Parse("07EBFA14-DA6F-471F-A29A-C3232EB436C9"),
                Name = Admin,
                NormalizedName = Admin.ToUpper(),
                ConcurrencyStamp = "F4C41BE7-D11A-4DE4-99FB-7C8C0C8C3A26"
            };
            roles.Add(role);

            return roles.ToArray();
        }
    }
}
