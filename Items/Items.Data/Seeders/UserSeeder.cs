namespace Items.Data.Seeders
{
    using Items.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class UserSeeder
    {
        public static ModelBuilder SeedUsers(this ModelBuilder builder)
        {
            builder
                .Entity<ApplicationUser>()
                .HasData(GenerateUsers());
            
            return builder;
        }

        private static ApplicationUser[] GenerateUsers()
        {
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> users = new List<ApplicationUser>();

            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                UserName = "superadmin@items.bg",
                NormalizedUserName = "SUPERADMIN@ITEMS.BG",
                Email = "superadmin@items.bg",
                NormalizedEmail = "SUPERADMIN@ITEMS.BG",
                SecurityStamp = "VG5NFKHCN2YOVRDWKLO4OC2UC5RDSZC2",
                EmailConfirmed = false,
                ConcurrencyStamp = "c9037b4e-9232-4448-bf59-2e340aac49c6",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            user.PasswordHash = hasher.HashPassword(user, "123456");
            users.Add(user);

            user = new ApplicationUser
            {
                Id = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),
                UserName = "pesho@items.com",
                NormalizedUserName = "PESHO@ITEMS.COM",
                Email = "pesho@items.com",
                NormalizedEmail = "PESHO@ITEMS.COM",
                SecurityStamp = "JMCTVP5CHQTQAB4TCG25FN2NPAKIWOFB",
                EmailConfirmed = false,
                ConcurrencyStamp = "aea9a9f8-e1bb-40b5-a8d4-48ba39c8e336",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            user.PasswordHash = hasher.HashPassword(user, "123456");
            users.Add(user);

            user = new ApplicationUser
            {
                Id = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),
                UserName = "stamat@items.com",
                NormalizedUserName = "STAMAT@ITEMS.COM",
                Email = "stamat@items.com",
                NormalizedEmail = "STAMAT@ITEMS.COM",
                SecurityStamp = "5NJNYJBBTCG5SWFQT2RSD7PJR746JEMM",
                EmailConfirmed = false,
                ConcurrencyStamp = "5a791e32-6035-4b8f-9100-ef55c918c980",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            user.PasswordHash = hasher.HashPassword(user, "123456");
            users.Add(user);


            return users.ToArray();
        }
    }
}
