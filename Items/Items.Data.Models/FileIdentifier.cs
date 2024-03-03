namespace Items.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Runtime;

	public class FileIdentifier
	{
		[Key]
        public Guid FileId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public bool IsPublic { get; set; }



        [ForeignKey(nameof(Item))]
        public Guid? ItemId { get; set; }
		public Item? Item { get; set; }


        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
