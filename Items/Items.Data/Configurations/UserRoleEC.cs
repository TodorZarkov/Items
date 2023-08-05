namespace Items.Data.Configurations
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class UserRoleEC// : IEntityTypeConfiguration<IdentityUserRole<Guid>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
		{
			builder
				.HasData(GenerateUserRoles());
		}

		private IdentityUserRole<Guid>[] GenerateUserRoles()
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
