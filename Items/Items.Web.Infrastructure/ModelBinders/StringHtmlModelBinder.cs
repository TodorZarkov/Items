namespace Items.Web.Infrastructure.ModelBinders
{
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using System.Text.Encodings.Web;
	using System.Threading.Tasks;

	public class StringHtmlModelBinder : IModelBinder
	{
		private readonly HtmlEncoder htmlEncoder;

		public StringHtmlModelBinder(HtmlEncoder htmlEncoder)
		{
			this.htmlEncoder = htmlEncoder;
		}

		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext
				.ValueProvider
				.GetValue(bindingContext.ModelName);

			string? stringValue = valueResult.FirstValue;

			if (stringValue != null && !string.IsNullOrEmpty(stringValue))
			{
				//todo: This is workaround. Cannot disable the default escaping of 'enter' and + or other potential security risk characters!!
				//If we want to keep the db safe from xss and see no double encoding to the final html. the decoder filter must be applied
				//to every ViewResult.
				if (stringValue.Contains('+') || stringValue.Contains((char)10) || stringValue.Contains((char)13))
				{
					stringValue = htmlEncoder.Encode(stringValue);
					stringValue = stringValue.Replace("&#x2B;", "+");
					stringValue = stringValue.Replace("&#xD;", ((char)13).ToString());
					stringValue = stringValue.Replace("&#xA;", ((char)10).ToString());
				}
				else
				{
					stringValue = htmlEncoder.Encode(stringValue);
				}
			}
			if (string.IsNullOrEmpty(stringValue))
			{
				stringValue = null;
			}

			bindingContext.Result = ModelBindingResult.Success(stringValue);
			return Task.CompletedTask;
		}
	}
}
