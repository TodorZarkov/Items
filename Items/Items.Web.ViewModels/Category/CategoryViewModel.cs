namespace Items.Web.ViewModels.Category
{
	using System.ComponentModel.DataAnnotations;

	public class CategoryViewModel
	{
		public int Id { get; set; }


		public string Name { get; set; } = null!;
	}
}
