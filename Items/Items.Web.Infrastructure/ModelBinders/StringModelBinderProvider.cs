namespace Items.Web.Infrastructure.ModelBinders
{
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using System.Text.Encodings.Web;

	public class StringModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder? GetBinder(ModelBinderProviderContext context)
		{
			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			if (context.Metadata.ModelType == typeof(string))
			{
				HtmlEncoder? encoder = (HtmlEncoder?)context.Services.GetService(typeof(HtmlEncoder));
				if (encoder is null)
				{
					throw new ArgumentNullException(nameof(encoder), "The DI container must contain HtmlEncoder.");
				}

				return new StringModelBinder(encoder);
			}

			return null;
		}
	}
}
