namespace Items.Data.Models
{
    using static Common.EntityValidationConstants.Place;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Place
    {
        public Place()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }


        [ForeignKey(nameof(Location))]
        public Guid LocationId { get; set; }

        [Required]
        public Location Location { get; set; } = null!;


        public ICollection<Item> Items { get; set; }
    }
}
