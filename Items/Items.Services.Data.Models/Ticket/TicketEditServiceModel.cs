namespace Items.Services.Data.Models.Ticket
{
	using System.ComponentModel.DataAnnotations;

	public class TicketEditServiceModel
	{
		[Required]
		public int TypeId { get; set; }


		[Required]
		public int StatusId { get; set; }


		public Guid? AssigneeId { get; set; }
	}
}
