namespace Items.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class FileIdentifier
	{
		[Key]
        public Guid FileId { get; set; }

		[ForeignKey(nameof(Item))]
        public Guid ItemId { get; set; }
		public Item? Item { get; set; }
    }
}
