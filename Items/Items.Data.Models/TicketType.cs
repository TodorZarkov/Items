namespace Items.Data.Models
{
    using static Items.Common.EntityValidationConstants.TicketType;

	using System.ComponentModel.DataAnnotations;

	public class TicketType
	{
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(NameMax)]
        public string Name { get; set; } = null!;
    }
}
