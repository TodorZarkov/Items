namespace Items.Services.Data.Models.Ticket
{

	public class AllTicketInfoServiceModel
	{
		public IEnumerable<AllTicketServiceModel> Tickets { get; set; } = null!;

        public int TotalCount { get; set; }
    }
}
