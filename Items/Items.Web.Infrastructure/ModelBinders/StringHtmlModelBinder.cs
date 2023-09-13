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

			if (!string.IsNullOrEmpty(stringValue))
			{
				stringValue = htmlEncoder.Encode(stringValue);
			}

			bindingContext.Result = ModelBindingResult.Success(stringValue);
			return Task.CompletedTask;
		}
	}
}
