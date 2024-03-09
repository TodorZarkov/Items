namespace Items.Web.ViewModels.Item
{
	using Microsoft.AspNetCore.Http;

	public class ItemEditFormModel : ItemFormModel
	{
        public ItemEditFormModel()
        {
            ImagesToDelete = new HashSet<Guid>();
            CurrentImages = new HashSet<Guid>();
            Images = new HashSet<IFormFile>();
        }
        public Guid MainImageId { get; set; } //io

        public ICollection<Guid> CurrentImages { get; set; } //o

        public ICollection<Guid> ImagesToDelete { get; set; } //i

        
	}
}
