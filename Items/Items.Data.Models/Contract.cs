namespace Items.Data.Models
{
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
	using Items.Common.Enums;
	using Microsoft.EntityFrameworkCore;

    using static Common.EntityValidationConstants.Contract;

    public class Contract
    {
        public Contract()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
		}


        [Key]
        public Guid Id { get; set; }



        [ForeignKey(nameof(Buyer))]
        [Required]
        public Guid BuyerId { get; set; }

        [ForeignKey(nameof(Seller))]
        [Required]
        public Guid SellerId { get; set; }

        [Required]
        public ApplicationUser Buyer { get; set; } = null!;

        [Required]
        public ApplicationUser Seller { get; set; } = null!;



        //the data is internal and it is checked in the identity
		public string? SellerName { get; set; } 
		public string? SellerEmail { get; set; }
		public string? SellerPhone { get; set; }
                                                                                       
		public string? BuyerName { get; set; }
		public string? BuyerEmail { get; set; }
		public string? BuyerPhone { get; set; }
         


		[Precision(ValuePrecision, ValueScale)]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }

        [Required]
        public Currency Currency { get; set; } = null!;


        
        [ForeignKey(nameof(Item))]
        public Guid? ItemId { get; set; }

        
        public Item? Item { get; set; }


        [Precision(QuantityPrecision, QuantityScale)]
        public decimal Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }
        [Required]
        public Unit Unit { get; set; } = null!;


        //Original item data when the contract is made
        //This data must be made available to both sides to  copy from and create new Item
        [Required]
        [MaxLength(ItemNameMaxLength)]
        public string ItemName { get; set; } = null!;

        [Required]
        [MaxLength(UriMaxLength)]
        public string ItemPictureUri { get; set; } = null!;

        [MaxLength(ItemDescriptionMaxLength)]
        public string? ItemDescription { get; set; }
        //AcquiredDate - contract date
        //AcquiredPrice - contract price
        //Quantity - contract quantity
        //Unit - contract unit




        public DateTime CreatedOn { get; set; }
        public DateTime SendDue { get; set; }// seller set after reads the address of the buyer, NEGOTIABLE
        public DateTime DeliverDue { get; set; }//seller default - 1 day after contract createdOn, NEGOTIABLE 
        public DateTime? ContractDate { get; set; } // DateTime when both sides are 'Ok'


        public bool SellerOk { get; set; }//when both sides are finally ok -  deal is on
        public bool BuyerOk { get; set; }
        public bool BuyerReceived { get; set; }//when item is delivered byer set to true. if buyer leaves it null 14 days  after delivery due - gets true by itself. after buyer confirmation the item can be copied from buyer in order to create own Item. The button is visible to the buyer after both are 'Ok'! (no need to wait deliveryDue date, on his responsibility-TO BE NOTED)
        public bool SellerReceived { get; set; }//when above is all true and seller gets the payment . After the contract is fulfilled the relation to the original Item STAIS for sake of the "Sold" statistic.


        [MaxLength(CommentMaxLength)]
        public string? SellerComment { get; set; }

        [MaxLength(CommentMaxLength)]
        public string? BuyerComment { get; set; }



        [MaxLength(DeliveryAddressMaxLength)]
        public string DeliveryAddress { get; set; } = null!;


        
        public DealStatus? Status { get; set; }
    }
}
