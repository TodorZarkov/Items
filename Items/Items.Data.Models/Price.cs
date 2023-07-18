namespace Items.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Price
    {
        [Required]
        public decimal Value { get; set; }


        [Required]
        public Currency Currency { get; set; } = null!;
    }
}
