namespace Items.Data.Models
{
	using static Items.Common.EntityValidationConstants.TicketStatus;

	using System.ComponentModel.DataAnnotations;

	public class TicketStatus
	{
		[Key]
		public int Id { get; set; }


		[Required]
		[MaxLength(NameMax)]
		public string Name { get; set; } = null!;
	}
}
