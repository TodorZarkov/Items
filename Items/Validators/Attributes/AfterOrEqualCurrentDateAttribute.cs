namespace Items.Web.Validators.Attributes
{
	using Items.Services.Common.Interfaces;
	using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
	using System.ComponentModel.DataAnnotations;

	public class AfterOrEqualCurrentDateAttribute : ValidationAttribute //, IClientModelValidator
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

			DateTime currentDate = dateTimeProvider.GetCurrentDate();
			if (currentValue < currentDate)
			{
				return new ValidationResult(ErrorMessage);
			}

			return ValidationResult.Success;
		}

		//public void AddValidation(ClientModelValidationContext context)
		//{
		//	string? error = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
		//	context.Attributes.Add("data-val", "true");
		//	context.Attributes.Add("data-val-cannotbepast", error);
		//}
	}
}
