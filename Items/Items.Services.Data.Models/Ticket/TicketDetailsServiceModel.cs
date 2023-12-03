namespace Items.Services.Data.Models.Ticket
{
	public class TicketDetailsServiceModel
	{
		public string TicketType { get; set; } = null!;


		public string Title { get; set; } = null!;


		public string? Description { get; set; }

		//formfile?
		public byte[]? Snapshot { get; set; }


		
		public string TicketStatus { get; set; } = null!;


		public Guid AuthorId { get; set; }
		public string AuthorName { get; set; } = null!;



		public Guid? AssignerId { get; set; }
		public string? AssignerName { get; set; }


		public Guid? AssigneeId { get; set; }
		public string? AssigneeName { get; set; }
	}
}
