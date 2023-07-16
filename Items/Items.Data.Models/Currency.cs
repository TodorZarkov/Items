namespace Items.Data.Models
{
    using static Common.EntityValidationConstants.Currency;

    using System.ComponentModel.DataAnnotations;

    public class Currency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(IsoCodeMaxLength)]
        public string IsoCode { get; set; } = null!;

        [MaxLength(NameMaxLength)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(SymbolMaxLength)]
        public string Symbol { get; set; } = null!;
    }
}
