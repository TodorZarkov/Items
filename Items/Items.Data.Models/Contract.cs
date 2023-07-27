namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using static Common.EntityValidationConstants.Contract;

    public class Contract
    {
        public Contract()
        {
            Id = Guid.NewGuid();
            UsersContracts = new HashSet<UserContract>();
        }

        [Key]
        public Guid Id { get; set; }


        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public Guid BuyerId { get; set; }


        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public Guid SellerId { get; set; }


        public ICollection<UserContract> UsersContracts { get; set; }


        [Precision(ValuePrecision, ValueScale)]
        public decimal Price { get; set; }


        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }

        [Required]
        public Currency Currency { get; set; } = null!;


        [Precision(QuantityPrecision, QuantityScale)]
        public decimal Quantity { get; set; }


        public DateTime SendDue { get; set; }

        public DateTime DeliverDue { get; set; }

        public DateTime ContractDate { get; set; }

        public bool SellerOk { get; set; }

        public bool BuyerOk { get; set; }

        public bool Fulfilled { get; set; }

        [MaxLength(CommentMaxLength)]
        public string? SellerComment { get; set; }

        [MaxLength(CommentMaxLength)]
        public string? BuyerComment { get; set; }

        public bool BuyerConfirm { get; set; }
    }
}
