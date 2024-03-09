namespace Items.Web.Validators.Attributes
{
	using System.ComponentModel.DataAnnotations;

	public class CannotContainAttribute : ValidationAttribute 
	{
		private readonly string forbiddenGuidProperty;
		public CannotContainAttribute(string forbiddenProperty, string errorMessage) : base(errorMessage)
		{
			this.forbiddenGuidProperty = forbiddenProperty;
		}
		 

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return ValidationResult.Success;
			}

			object? property = validationContext.ObjectType
				.GetProperty(forbiddenGuidProperty)?
				.GetValue(validationContext.ObjectInstance);
			if (property == null)
			{
				return ValidationResult.Success;
			}

			if (property.GetType() != typeof(Guid))
			{
				throw new ArgumentException("The Attribute accepts only properties of type Guid.");
			}

			Guid forbiddenValue = (Guid)property;

			Type valueType = value.GetType();
			if (valueType.IsAssignableTo(typeof(IEnumerable<Guid>)))
			{
				IEnumerable<Guid> valueCollection = (IEnumerable<Guid>)value;
				if (valueCollection.Contains(forbiddenValue))
				{
					return new ValidationResult(this.ErrorMessage);
				}
			}
			else if (valueType.IsInstanceOfType(typeof(Guid)))
			{
				Guid valueGuid = (Guid)value;
				if (valueGuid == forbiddenValue)
				{
					return new ValidationResult(this.ErrorMessage);
				}
			}
			return ValidationResult.Success;

		}
	}
}
