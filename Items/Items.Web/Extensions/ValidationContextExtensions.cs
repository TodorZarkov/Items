namespace Items.Web.Extensions
{
	using System.ComponentModel.DataAnnotations;

	public static class ValidationContextExtensions
	{
		public static T? GetService<T>(this ValidationContext validationContext)
		{
			return (T?)validationContext.GetService(typeof(T));
		}
	}
}
