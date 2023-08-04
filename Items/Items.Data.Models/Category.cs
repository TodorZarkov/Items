namespace Items.Data.Models
{
    using static Common.EntityValidationConstants.Category;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            ItemsCategories = new HashSet<ItemCategory>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }

        [Required]
        public ApplicationUser Creator { get; set; } = null!;

       
        public ICollection<ItemCategory> ItemsCategories { get; set; } = null!;
    }
}
