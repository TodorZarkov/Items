namespace Items.Web.Validators.Attributes
{
	using Items.Services.Common.Interfaces;
	using System.ComponentModel.DataAnnotations;

	public class AfterOrEqualCurrentDateTime : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			ErrorMessage = ErrorMessageString;

			DateTime? currentValue = (DateTime?)value;
			if (!currentValue.HasValue)
			{
				return ValidationResult.Success;
			}

			IDateTimeProvider? dateTimeProvider = (IDateTimeProvider?)validationContext.GetService(typeof(IDateTimeProvider));
			if (dateTimeProvider == null)
			{
				throw new ArgumentNullException(nameof(validationContext));
			}

			DateTime currentDateTime = dateTimeProvider.GetCurrentDateTime();
			if (currentValue < currentDateTime)
			{
				return new ValidationResult(ErrorMessage);
			}

			return ValidationResult.Success;
		}
	}
}
