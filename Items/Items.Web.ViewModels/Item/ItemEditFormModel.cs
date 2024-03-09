namespace Items.Web.ViewModels.Item
{
	using Items.Web.Validators.Attributes;
	using Microsoft.AspNetCore.Http;
	using System.ComponentModel.DataAnnotations;

	public class ItemEditFormModel : ItemFormModel
	{
        public ItemEditFormModel()
        {
            ImagesToDelete = new HashSet<Guid>();
            CurrentImages = new HashSet<Guid>();
            Images = new HashSet<IFormFile>();
        }

        [Required]
        public Guid MainImageId { get; set; } //io

        public IEnumerable<Guid> CurrentImages { get; set; } //o

        [CannotContain(nameof(MainImageId),"Cannot delete the current image!")]
        public IEnumerable<Guid> ImagesToDelete { get; set; } //i

        
	}
}
