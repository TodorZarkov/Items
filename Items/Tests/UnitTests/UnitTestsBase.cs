namespace Tests.UnitTests
{
    using Tests.Mocks;

    using Items.Data;
    using Items.Data.Models;
    //using static Items.Common.RoleConstants;

    using AutoMapper;
    using Microsoft.AspNetCore.Identity;

    using System;

    public class UnitTestsBase
    {
        protected ItemsDbContext dbContext;
        protected IMapper mapper;
        protected PasswordHasher<ApplicationUser> hasher;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            this.dbContext = DatabaseMock.Instance;
            //this.mapper = MapperMock.Instance;
            this.hasher = new PasswordHasher<ApplicationUser>();

            SeedDatabase();
        }
        public ApplicationUser SuperAdmin { get; private set; }
        public ApplicationUser Admin { get; private set; }
        public ApplicationUser Category1Owner { get; private set; }
        public ApplicationUser Category23Owner { get; private set; }
        public ApplicationUser NoCategoryOwner { get; private set; }


        public IdentityRole<Guid> SuperAdminRole { get; private set; }
        public IdentityRole<Guid> AdminRole { get; private set; }

        public IdentityUserRole<Guid> SuperAdminSuperAdminRole { get; private set; }
        public IdentityUserRole<Guid> AdminAdminRole { get; private set; }


        public Category Category1 { get; private set; }
        public Category Category2 { get; private set; }
        public Category Category3 { get; private set; }
        public Category SuperAdminCategory1 { get; private set; }
        public Category SuperAdminCategory2 { get; private set; }
        public Category AdminCategory { get; private set; }


        private void SeedDatabase()
        {
            SuperAdmin = new ApplicationUser()
            {
                Id = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                UserName = "superadmin@items.bg",
                NormalizedUserName = "SUPERADMIN@ITEMS.BG",
                Email = "superadmin@items.bg",
                NormalizedEmail = "SUPERADMIN@ITEMS.BG",
                SecurityStamp = "VG5NFKHCN2YOVRDWKLO4OC2UC5RDSZC2",
                EmailConfirmed = true,
                ConcurrencyStamp = "c9037b4e-9232-4448-bf59-2e340aac49c6",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0,
            };
            SuperAdmin.PasswordHash = hasher.HashPassword(SuperAdmin, "123456");

            Admin = new ApplicationUser()
            {
                Id = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),
                UserName = "admin@items.com",
                NormalizedUserName = "ADMIN@ITEMS.COM",
                Email = "admin@items.com",
                NormalizedEmail = "ADMIN@ITEMS.COM",
                SecurityStamp = "5NJNYJBBTCG5SWFQT2RSD7PJR746JEMM",
                EmailConfirmed = true,
                ConcurrencyStamp = "5a791e32-6035-4b8f-9100-ef55c918c980",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            Admin.PasswordHash = hasher.HashPassword(Admin, "123456");

            Category1Owner = new ApplicationUser()
            {
                Id = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),
                UserName = "category1owner@items.com",
                NormalizedUserName = "CATEGORY1OWNER@ITEMS.COM",
                Email = "category1owner@items.com",
                NormalizedEmail = "CATEGORY1OWNER@ITEMS.COM",
                SecurityStamp = "JMCTVP5CHQTQAB4TCG25FN2NPAKIWOFB",
                EmailConfirmed = true,
                ConcurrencyStamp = "aea9a9f8-e1bb-40b5-a8d4-48ba39c8e336",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            Category1Owner.PasswordHash = hasher.HashPassword(Category1Owner, "123456");

            Category23Owner = new ApplicationUser()
            {
                Id = Guid.Parse("8BEE3220-A1A1-4502-EFEA-08DB9037BC59"),
                UserName = "category23owner@items.com",
                NormalizedUserName = "CATEGORY23OWNER@ITEMS.COM",
                Email = "category23owner@items.com",
                NormalizedEmail = "CATEGORY23OWNER@ITEMS.COM",
                SecurityStamp = "JNCTVP5CHQTQAB4TCG25FN2NPAKIWOFB",
                EmailConfirmed = true,
                ConcurrencyStamp = "afa9a9f8-e1bb-40b5-a8d4-48ba39c8e336",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            Category23Owner.PasswordHash = hasher.HashPassword(Category23Owner, "123456");

            NoCategoryOwner = new ApplicationUser()
            {
                Id = Guid.Parse("8CEE3220-A1A1-4502-EFEA-08DB9037BC59"),
                UserName = "nocategoryowner@items.com",
                NormalizedUserName = "NOCATEGORYOWNER@ITEMS.COM",
                Email = "nocategoryowner@items.com",
                NormalizedEmail = "NOCATEGORYOWNER@ITEMS.COM",
                SecurityStamp = "JOCTVP5CHQTQAB4TCG25FN2NPAKIWOFB",
                EmailConfirmed = true,
                ConcurrencyStamp = "aga9a9f8-e1bb-40b5-a8d4-48ba39c8e336",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            NoCategoryOwner.PasswordHash = hasher.HashPassword(NoCategoryOwner, "123456");


            SuperAdminRole = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("B8E078AF-5CBC-4360-A99A-0AA387C563E1"),
                Name = Items.Common.RoleConstants.SuperAdmin,
                NormalizedName = Items.Common.RoleConstants.SuperAdmin.ToUpper(),
                ConcurrencyStamp = "8208B486-8D31-4E5C-8BB0-05FF07CF81E0"
            };
            AdminRole = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("07EBFA14-DA6F-471F-A29A-C3232EB436C9"),
                Name = Items.Common.RoleConstants.Admin,
                NormalizedName = Items.Common.RoleConstants.Admin.ToUpper(),
                ConcurrencyStamp = "F4C41BE7-D11A-4DE4-99FB-7C8C0C8C3A26"
            };

            SuperAdminSuperAdminRole = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),//the super admin id
                RoleId = Guid.Parse("B8E078AF-5CBC-4360-A99A-0AA387C563E1")//the super admin role id
            };
            AdminAdminRole = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),//the admin id
                RoleId = Guid.Parse("07EBFA14-DA6F-471F-A29A-C3232EB436C9")//the admin role id
            };




            Category1 = new Category()
            {
                CreatorId = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),
                Id = 1,
                Name = "Category1"
            };
            Category2 = new Category()
            {
                CreatorId = Guid.Parse("8BEE3220-A1A1-4502-EFEA-08DB9037BC59"),
                Id = 2,
                Name = "Category2"
            };
            Category3 = new Category()
            {
                CreatorId = Guid.Parse("8BEE3220-A1A1-4502-EFEA-08DB9037BC59"),
                Id = 3,
                Name = "Category3"
            };

            SuperAdminCategory1 = new Category()
            {
                CreatorId = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                Id = 4,
                Name = "SuperAdminCategory1"
            };
            SuperAdminCategory2 = new Category()
            {
                CreatorId = Guid.Parse("04023B09-A38E-48E1-1082-08DB8D0DB110"),
                Id = 5,
                Name = "SuperAdminCategory2"
            };
            AdminCategory = new Category()
            {
                CreatorId = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),
                Id = 6,
                Name = "AdminCategory"
            };



            dbContext.Users.Add(SuperAdmin);
            dbContext.Users.Add(Admin);
            dbContext.Users.Add(NoCategoryOwner);
            dbContext.Users.Add(Category1Owner);
            dbContext.Users.Add(Category23Owner);

            dbContext.Roles.Add(SuperAdminRole);
            dbContext.Roles.Add(AdminRole);

            dbContext.UserRoles.Add(SuperAdminSuperAdminRole);
            dbContext.UserRoles.Add(AdminAdminRole);

            dbContext.Categories.Add(Category1);
            dbContext.Categories.Add(Category2);
            dbContext.Categories.Add(Category3);
            dbContext.Categories.Add(SuperAdminCategory1);
            dbContext.Categories.Add(SuperAdminCategory2);
            dbContext.Categories.Add(AdminCategory);

            dbContext.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            this.dbContext.Dispose();
        }
    }
}
