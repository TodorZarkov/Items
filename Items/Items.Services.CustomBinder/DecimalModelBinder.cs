namespace Items.Services.CustomBinder
{
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using System.Globalization;
	using System.Threading.Tasks;

	//todo: move it in infrastructure folder .Web.Infrastructure (binders, extensions...)
	//todo: override the jQuery front end number validation to accept comma and dot
	//or it is culture related and it changes when the os culture is changed?
	public class DecimalModelBinder : IModelBinder
	{

		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider
				.GetValue(bindingContext.ModelName);

			decimal? actualValue = null;
			bool success = false;

			if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
			{
				try
				{
					string decValue = valueResult.FirstValue;
					if (decValue.Count(c => c.Equals(',')) > 1)
					{
						decValue = decValue.Replace(",", string.Empty);
						decValue = decValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
					}
					else if (decValue.Count(c => c.Equals('.')) > 1)
					{
						decValue = decValue.Replace(".", string.Empty);
						decValue = decValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
					}
					actualValue = decimal.Parse(decValue, CultureInfo.CurrentCulture);
					success = true;
				}
				catch (FormatException e)
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName, e, bindingContext.ModelMetadata);
				}
			}
			else
			{
				if (bindingContext.ModelMetadata.ModelType == typeof(decimal?))
				{
					success = true;
				}
			}

			if (success)
			{
				bindingContext.Result = ModelBindingResult.Success(actualValue);
				return Task.CompletedTask;
			}

			return Task.CompletedTask;
		}
	}
}