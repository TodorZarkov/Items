namespace Items.Services.Validator
{
	using Items.Services.Validator.Interfaces;

	using System.Collections.Generic;

	public class UserValidatorService : IUserValidatorService
	{
		public UserValidatorService()
		{
			this.ModelErrors = new HashSet<ModelError>();
		}
		public ICollection<ModelError> ModelErrors { get; set; }
	}
}
