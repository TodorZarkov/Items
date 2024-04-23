namespace Items.Data.Models
{
    using static Common.EntityValidationConstants.Unit;

    using System.ComponentModel.DataAnnotations;

    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(SymbolMaxLength)]
        public string Symbol { get; set; } = null!;

    }
}
