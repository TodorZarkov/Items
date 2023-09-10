namespace Items.Web.Infrastructure.Extensions
{
	using Microsoft.AspNetCore.Mvc.Filters;
	using System.ComponentModel.DataAnnotations;

	public static class ActionContextExtensions
	{
		public static T? GetService<T>(this ActionExecutingContext actionContext)
		{
			T? service = (T?)actionContext.HttpContext.RequestServices.GetService(typeof(T));
			return service;
		}
	}
}
