namespace Items.AdminApi.Infrastructure.Extensions
{
	using System.Security.Claims;

	public static class ClaimsPrincipalExtensions
	{
		public static Guid? GetId(this ClaimsPrincipal user)
		{
			string? stringId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (stringId == null)
			{
				return null;
			}
			return Guid.Parse(stringId);
		}
	}
}
