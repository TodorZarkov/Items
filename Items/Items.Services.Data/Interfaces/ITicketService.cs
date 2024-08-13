namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.Ticket;

	public interface ITicketService
	{
		Task<AllTicketInfoServiceModel> GetAllAsync(TicketQueryModel? queryModel = null);

		Task<Guid> AddAsync(Guid userId, TicketFormServiceModel model);

		Task<TicketDetailsServiceModel> GetAsync(Guid ticketId,  Guid? userId);

        Task<Guid> ToggleAsync(TicketUpdateServiceModel model, Guid ticketId, Guid userId);

        Task<bool> CanDeleteAsync(Guid? v, Guid ticketId);

        Task DeleteAsync(Guid ticketId);
        Task<TicketUserState> GetStateAsync(Guid ticketId, Guid userId);
        Task EditAsUserAsync(Guid ticketId, TicketEditAsUserServiceModel model);
        Task AssignToSelfAsync(Guid ticketId, Guid userId);
        Task AssignAsync(Guid ticketId, Guid userId, TicketUpdateServiceModel model);
        Task ChangeSeverityStatusTypeAsync(Guid ticketId, TicketUpdateServiceModel model);
    }
}
