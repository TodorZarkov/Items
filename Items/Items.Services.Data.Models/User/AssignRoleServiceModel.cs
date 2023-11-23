namespace Items.Services.Data.Models.User
{
	using static Items.Common.EntityValidationConstants.User;

	using System.ComponentModel.DataAnnotations;

	public class AssignRoleServiceModel
	{
		[Required]
		[EmailAddress]
		[StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
		public string Email { get; set; } = null!;

		[Required]
		[StringLength(UserRoleMaxLength, MinimumLength = UserRoleMinLength)]
		public string Role { get; set; } = null!;
    }
}
