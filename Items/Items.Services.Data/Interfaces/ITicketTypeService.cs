namespace Items.Services.Data.Interfaces
{
    using Items.Services.Data.Models.TicketType;

    public interface ITicketTypeService
    {
        Task<IEnumerable<AllTicketTypesServiceModel>> AllAsync();
    }
}
