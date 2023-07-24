namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using static Common.EntityValidationConstants.Price;

    public class Price
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Precision(ValuePrecision,  ValueScale)]
        public decimal Value { get; set; }


        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }

        [Required]
        public Currency Currency { get; set; } = null!;

    }
}
