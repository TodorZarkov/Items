namespace Items.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Offer;

    public class Offer
    {
        [Key]
        public Guid Id { get; set; }

        public bool Win { get; set; }


        [MaxLength(MessageMaxLength)]
        public string? Message { get; set; }




        [Required]
        [ForeignKey(nameof(Buyer))]
        public Guid BuyerId { get; set; }

        [Required]
        public ApplicationUser Buyer { get; set; } = null!;

		[ForeignKey(nameof(BuyerLocation))]
		public Guid? LocationId { get; set; }

		public Location? BuyerLocation { get; set; }

        public bool UseBuyerName { get; set; }
        public bool UseBuyerEmail { get; set; }
        public bool UseBuyerPhone { get; set; }



        [Required]
        [ForeignKey(nameof(Item))]
        public Guid ItemId { get; set; }

        [Required]
        public Item Item { get; set; } = null!;


        [Precision(QuantityPrecision, QuantityScale)]
        public decimal Quantity { get; set; }


		


		[Required]
        public DateTime Expires { get; set; }


        [Precision(ValuePrecision, ValueScale)]
        public decimal Value { get; set; }


        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; } = null!;



		[ForeignKey(nameof(BarterItem))]
		public Guid? BarterItemId { get; set; }

		public Item? BarterItem { get; set; }


		[Precision(QuantityPrecision, QuantityScale)]
		public decimal? BarterQuantity { get; set; }





		

    }
}
