namespace Items.Web.Validators.Attributes
{
	using System.ComponentModel.DataAnnotations;
	using System.Reflection;

	public class RequiredIfNotPresentAttribute : ValidationAttribute
	{
		private readonly string[] notRequireds;

		public RequiredIfNotPresentAttribute(params string[] notRequireds)
		{
			this.notRequireds = notRequireds;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			
			List<object?> props = new List<object?>();
			foreach (var notRequired in notRequireds)
			{
				PropertyInfo? propertyInfo = validationContext.ObjectType.GetProperty(notRequired);
				if (propertyInfo == null)
				{
					throw new ArgumentException($"Property with name {notRequired} not found");

				}
				object? prop = propertyInfo.GetValue(validationContext.ObjectInstance);
				props.Add(prop);
			}


			bool hasNulls = props.Any(p => p == null);


			if (hasNulls && value == null)
			{
				return new ValidationResult(ErrorMessage);
			}
			else
			{
				return ValidationResult.Success;
			}
		}
	}
}
