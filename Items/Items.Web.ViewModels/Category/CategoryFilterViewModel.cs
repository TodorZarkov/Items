namespace Items.Web.ViewModels.Category
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Category;

	public class CategoryFilterViewModel
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int Id { get; set; }

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[Required]
		public bool Selected { get; set; }
	}
}
