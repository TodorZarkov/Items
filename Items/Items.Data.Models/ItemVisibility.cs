namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Enums;

    public class ItemVisibility
    {
        public ItemVisibility()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public AccessModifier Name { get; set; }

        public AccessModifier Quantity { get; set; }
        
        public AccessModifier Description { get; set; }
        
        public AccessModifier AcquiredPrice { get; set; }
        
        public AccessModifier AcquiredDate { get; set; }
        
        public AccessModifier AcquireDocument { get; set; }
        
        public AccessModifier Owner { get; set; }
        
        public AccessModifier Location { get; set; }
        
        public AccessModifier Offers { get; set; }


        //[ForeignKey(nameof(Item))]
        //public Guid ItemId { get; set; }

        [Required]
        public Item Item { get; set; } = null!;
    }
}
