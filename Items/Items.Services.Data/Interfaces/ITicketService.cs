namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.Ticket;

	public interface ITicketService
	{
		Task<AllTicketInfoServiceModel> GetAllAsync(TicketQueryModel? queryModel = null);

		Task<Guid> AddAsync(Guid userId, TicketFormServiceModel model);
		Task EditAsync(Guid guid, Guid ticketId, TicketEditServiceModel ticketEditModel);
		Task<TicketDetailsServiceModel> GetAsync(Guid ticketId,  Guid? userId);
        Task<Guid> UpdateAsync(TicketUpdateServiceModel model, Guid ticketId, Guid userId);
    }
}
