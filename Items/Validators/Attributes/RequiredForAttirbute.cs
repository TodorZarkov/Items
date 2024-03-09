namespace Items.Web.Validators.Attributes
{
	using System.ComponentModel.DataAnnotations;

	public class RequiredForAttribute : ValidationAttribute
	{
		private readonly Type classType;

		public RequiredForAttribute(Type classType)
		{
			this.classType = classType;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var instanceType = validationContext.ObjectInstance.GetType();
			if (instanceType.Equals(classType))
			{
				RequiredAttribute requiredAttribute = new RequiredAttribute();
				if (requiredAttribute.IsValid(value))
				{
					return ValidationResult.Success;
				}

				return new ValidationResult("At least one image file is required.");
			}
			return ValidationResult.Success;
		}
	}
}
