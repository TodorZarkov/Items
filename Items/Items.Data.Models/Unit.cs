namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength]
        public string Symbol { get; set; } = null!;

    }
}
