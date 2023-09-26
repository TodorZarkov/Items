namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.Offer;
	using Items.Web.ViewModels.Base;
	using Items.Web.ViewModels.Bid;

	public interface IOfferService
	{
		Task<AllOfferServiceModel> AllByItemIdAsync(Guid id, QueryFilterModel? queryModel);
		Task<AllBidServiceModel> AllMineAsync(Guid userId, QueryFilterModel? queryModel = null);
		Task<bool> CanUpdate(Guid id);
		Task<Guid> CreateAsync(AddBidFormModel model, Guid itemId, Guid userId);
		Task DeleteAsync(Guid id);
		Task EditAsync(Guid id, EditBidFormModel model);
		Task<bool> ExistByItemIdUserId(Guid itemId, Guid userId);
		Task<AddBidFormModel> GetForCreate(Guid itemId);
		Task<decimal?> GetHighestBidByItemIdAsync(Guid itemId);
		Task<decimal?> GetHighestBidByOfferIdAsync(Guid id);
		Task<bool> IsOwnerAsync(Guid id, Guid userId);
		Task<int> RemoveExpiredByItemId(Guid itemId);
		Task<decimal> SufficientQuantity(Guid id, decimal quantity);
	}
}
