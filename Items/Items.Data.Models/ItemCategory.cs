namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ItemCategory
    {
        [Required]
        [ForeignKey(nameof(Item))]
        public Guid ItemId { get; set; }
        public Item Item { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
