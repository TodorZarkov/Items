namespace Items.Web.Validators.Attributes
{
	using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
	using System.ComponentModel.DataAnnotations;

	public class AfterOrEqualDateTimeAttribute : ValidationAttribute, IClientModelValidator
	{
		DateTime dateTime;

		public AfterOrEqualDateTimeAttribute(DateTime dateTime)
		{
			this.dateTime = dateTime;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			ErrorMessage = ErrorMessageString;

			DateTime? currentValue = (DateTime?)value;
			if (currentValue == null)
			{
				return ValidationResult.Success; //not care to compare with null
			}

			if (currentValue <= dateTime)
			{
				return new ValidationResult(ErrorMessage);
			}

			return ValidationResult.Success;
		}

		public void AddValidation(ClientModelValidationContext context)
		{
			string? error = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
			context.Attributes.Add("data-val", "true");
			context.Attributes.Add("data-val-error", error);
		}
	}
}
