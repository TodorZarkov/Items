namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using static Common.EntityValidationConstants.Account;

    public class Account
    {
        public Account()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }


        [Precision(ValuePrecision, ValueScale)]
        public decimal Balance { get; set; }


        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }

        [Required]
        public Currency Currency { get; set; } = null!;


        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; } = null!;
    }
}
