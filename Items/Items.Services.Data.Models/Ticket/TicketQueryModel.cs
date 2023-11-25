namespace Items.Services.Data.Models.Ticket
{
	public class TicketQueryModel
	{
        public string? SearchTerm { get; set; }

        public string[]? IncludeStatuses { get; set; }

        public string[]? IncludeTypes { get; set; }

        public int HitsPerPage { get; set; }

        public int CurrentPage { get; set; }

    }
}
