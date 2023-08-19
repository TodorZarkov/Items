namespace Items.Web.Validators.Attributes
{
	using Items.Services.Common.Interfaces;
	using System.ComponentModel.DataAnnotations;

	public class EqualCurrentDateAttribute : ValidationAttribute
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
			if (((DateTime)currentValue).Date < ((DateTime)currentDate).Date  || ((DateTime)currentValue).Date > ((DateTime)currentDate).Date)
			{
				return new ValidationResult(ErrorMessage);
			}

			return ValidationResult.Success;
		}
	}
}
