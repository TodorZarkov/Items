namespace Items.Data.Models
{
    using static Common.EntityValidationConstants.Place;

    using System.ComponentModel.DataAnnotations;

    public class Place
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
