namespace Items.Services.Validator.Interfaces
{
	
	public interface IValidatorErrorMessage
	{
		ICollection<ModelError> ModelErrors { get; }
	}

	public class ModelError
	{
		public string Message { get; set; } = null!;
		public string PropertyName { get; set; } = null!;
	}
}
