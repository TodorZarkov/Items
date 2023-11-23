namespace Items.Services.Validator.Interfaces
{
	using Items.Data.Models;
	using Items.Services.Data.Models.User;

	public interface IUserValidatorService : IValidatorErrorMessage
	{
		Task<bool> CanAssign(Guid userId, string roleName);
	}
}
