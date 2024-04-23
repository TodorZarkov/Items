namespace Items.Services.Data.Models.Unit
{
    using static Items.Common.EntityValidationConstants.Unit;

    using System.ComponentModel.DataAnnotations;

    public class UnitServiceModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(SymbolMaxLength, MinimumLength = SymbolMinLength)]
        public string Symbol { get; set; } = null!;
    }
}
