namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Bid;

	public interface IOfferService
	{
		Task<IEnumerable<AllBidViewModel>> AllMineAsync(Guid userId);
		Task<bool> CanUpdate(Guid id);
		Task<Guid> CreateAsync(AddBidFormModel model, Guid itemId, Guid userId);
		Task EditAsync(Guid id, EditBidFormModel model);
		Task<bool> ExistByItemIdUserId(Guid itemId, Guid userId);
		Task<AddBidFormModel> GetForCreate(Guid itemId);
		Task<decimal?> GetHighestBidByItemIdAsync(Guid itemId);
		Task<decimal?> GetHighestBidByOfferIdAsync(Guid id);
		Task<bool> IsOwnerAsync(Guid id, Guid userId);
		Task<decimal> SufficientQuantity(Guid id, decimal quantity);
	}
}
