namespace Items.Web.ViewModels.Category
{
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

	using static Items.Common.EntityValidationConstants.Category;

	public class CategoryFormViewModel
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(maximumLength: NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;



	}
}
