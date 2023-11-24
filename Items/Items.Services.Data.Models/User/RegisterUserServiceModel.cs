namespace Items.Services.Data.Models.User
{
	using static Items.Common.EntityValidationConstants.User;

	using System.ComponentModel.DataAnnotations;

	public class RegisterUserServiceModel
	{
		[Required]
		[EmailAddress]
		[StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
		public string Email { get; set; } = null!;

		//todo: where to validate password according to appsettings.json settings
		[Required]
		public string Password { get; set; } = null!;
    }
}
