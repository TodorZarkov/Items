namespace Items.Services.Validator.Interfaces
{
	using Items.Services.Data.Models.User;

	public interface IUserValidatorService : IValidatorErrorMessage
	{
		Task<bool> IsRegisterAdminModelValid(RegisterAdminServiceModel model);
	}
}
