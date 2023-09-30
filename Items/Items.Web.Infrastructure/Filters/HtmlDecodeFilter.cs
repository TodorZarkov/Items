namespace Items.Web.Infrastructure.Filters
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;
	using Microsoft.AspNetCore.Mvc.ModelBinding;

	public class HtmlDecodeFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			//todo: implement -  to decode already encoded data in the db. The default Razor Engine encoding cannot be disabled so the data is encoded twice!!!
			//get all string properties of the model
			//decode them 
			//put them back in the model
			//if an api is used instead of mvc, or another view engine with no default encoding, the filter must be disabled!

			base.OnActionExecuted(context);
		}

	}
}
