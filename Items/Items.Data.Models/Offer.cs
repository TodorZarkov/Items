namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Offer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Buyer))]
        public Guid UserId { get; set; }

        public ApplicationUser Buyer { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Item))]
        public Guid ItemId { get; set; }

        public Item Item { get; set; }


        [Required]
        public Price OfferedPrice { get; set; } = null!;

        public Location? BuyerLocation { get; set; }

        public Item? Barter { get; set; }
    }
}
