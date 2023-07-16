namespace Items.Data.Models
{
    using static Common.EntityValidationConstants.Place;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Place
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength()]
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }

        public Location Location { get; set; } = null!;


    }
}
