namespace Items.Services.Data.Models.User
{
	using System.ComponentModel.DataAnnotations;
	using static Items.Common.EntityValidationConstants.User;

	public class LoginUserServiceModel
	{
		[Required(AllowEmptyStrings = false)]
		[EmailAddress]
		[StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
		public string Email { get; set; } = null!;

		[Required(AllowEmptyStrings = false)]
		public string Password { get; set; } = null!;
    }
}
