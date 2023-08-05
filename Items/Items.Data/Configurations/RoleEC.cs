namespace Items.Data.Configurations
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class RoleEC// : IEntityTypeConfiguration<IdentityRole<Guid>>
	{
		public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
		{
			builder
				.HasData(GenerateRoles());
		}

		private IdentityRole<Guid>[] GenerateRoles()
		{
			List<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>();

			IdentityRole<Guid> role = new IdentityRole<Guid>
			{
				Id = Guid.Parse("B8E078AF-5CBC-4360-A99A-0AA387C563E1"),
				Name = "Admin",
				NormalizedName = "ADMIN",
				ConcurrencyStamp = "8208B486-8D31-4E5C-8BB0-05FF07CF81E0"
			};
			roles.Add(role);

			return roles.ToArray();
		}
	}
}
