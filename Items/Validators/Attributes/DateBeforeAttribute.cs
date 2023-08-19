namespace Items.Web.Validators.Attributes
{
	using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
	using System.ComponentModel.DataAnnotations;
	using System.Reflection;

	public class DateBeforeAttribute : ValidationAttribute//, IClientModelValidator
	{
		private readonly string targetProperty;
        public DateBeforeAttribute(string targetProperty)
        {
			this.targetProperty = targetProperty;
        }

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			ErrorMessage = ErrorMessageString;
			DateTime? currentValue = (DateTime?)value;
			if (currentValue == null)
			{
				//throw new ArgumentException($"Property with name {validationContext.DisplayName}  must not be null");
				return ValidationResult.Success; //not care to compare with null
			}



			PropertyInfo? propertyInfo = validationContext.ObjectType.GetProperty(targetProperty);
			if (propertyInfo == null)
			{
				throw new ArgumentException($"Property with name {targetProperty} not found");

			}

			DateTime? propertyValue = (DateTime?)propertyInfo.GetValue(validationContext.ObjectInstance);
			if (propertyValue == null)
			{
				//throw new ArgumentException($"Property with name {targetProperty}  must not be null");
				return ValidationResult.Success; //not care to compare with null
			}

			if (((DateTime)currentValue).Date >= ((DateTime)propertyValue).Date)
			{
				return new ValidationResult(ErrorMessage);
			}



			return ValidationResult.Success;
		}



		//public void AddValidation(ClientModelValidationContext context)
		//{
		//	string? error = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
		//	context.Attributes.Add("data-val", "true");
		//	context.Attributes.Add("data-val-error", error);
		//}
	}
}
