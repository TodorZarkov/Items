namespace Items.Web.ViewModels.Item
{
	public class ItemEditFormModel : ItemFormModel
	{
        public ItemEditFormModel()
        {
            ImagesToDelete = new HashSet<Guid>();
            CurrentImages = new HashSet<Guid>();
        }
        public Guid MainImageId { get; set; } //io

        public ICollection<Guid> CurrentImages { get; set; } //o

        public ICollection<Guid> ImagesToDelete { get; set; } //i


    }
}
