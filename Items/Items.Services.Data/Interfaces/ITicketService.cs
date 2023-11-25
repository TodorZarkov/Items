namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.Ticket;

	public interface ITicketService
	{
		Task<AllTicketInfoServiceModel> GetAllAsync(TicketQueryModel? queryModel = null);

		Task<Guid> AddTicketServiceModel(TicketFormServiceModel model);
	}
}
