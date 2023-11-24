namespace Items.Services.Data.Models.Ticket
{
	using static Items.Common.EntityValidationConstants;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

	public class AllTicketServiceModel
	{
		public Guid Id { get; set; }

		
		public string Type { get; set; } = null!;


		public string Title { get; set; } = null!;


		public string Status { get; set; } = null!;


	}
}
