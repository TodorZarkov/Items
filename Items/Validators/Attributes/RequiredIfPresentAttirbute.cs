namespace Items.Web.Validators.Attributes
{
	using System.ComponentModel.DataAnnotations;
	using System.Reflection;

	public class RequiredIfPresentAttribute : ValidationAttribute
	{
		private readonly string[] requireds;

		public RequiredIfPresentAttribute(params string[] requireds)
		{
			this.requireds = requireds;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return ValidationResult.Success;
			}

			List<object?> props = new List<object?>();
			foreach (var required in requireds)
			{
				PropertyInfo? propertyInfo = validationContext.ObjectType.GetProperty(required);
				if (propertyInfo == null)
				{
					throw new ArgumentException($"Property with name {required} not found");

				}
				object? prop = propertyInfo.GetValue(validationContext.ObjectInstance);
				props.Add(prop);
			}


			bool hasNulls = props.Any(p => p == null);


			if (hasNulls)
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
