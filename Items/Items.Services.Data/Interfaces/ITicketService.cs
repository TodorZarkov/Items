namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.Ticket;

	public interface ITicketService
	{
		Task<AllTicketInfoServiceModel> GetAllAsync(TicketQueryModel? queryModel = null);

		Task<Guid> AddAsync(Guid userId, TicketFormServiceModel model);

		Task<TicketDetailsServiceModel> GetAsync(Guid ticketId,  Guid? userId);

        Task<Guid> UpdateAsync(TicketUpdateServiceModel model, Guid ticketId, Guid userId);

        Task<bool> CanDeleteAsync(Guid? v, Guid ticketId);

        Task DeleteAsync(Guid ticketId);
        Task<TicketUserState> GetStateAsync(Guid ticketId, Guid userId);
        Task EditAsUserAsync(Guid ticketId, TicketEditAsUserServiceModel model);
    }
}
