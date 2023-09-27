namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.Offer;
	using Items.Web.ViewModels.Base;
	using Items.Web.ViewModels.Bid;

	public interface IOfferService
	{
		Task AcceptOfferAsync(Guid id);
		Task<AllOfferServiceModel> AllByItemIdAsync(Guid id, QueryFilterModel? queryModel);
		Task<AllBidServiceModel> AllMineAsync(Guid userId, QueryFilterModel? queryModel = null);
		Task<bool> CanPromiseQuantityAsync(Guid itemId, Guid offerId);
		Task<bool> CanUpdate(Guid id);
		Task<Guid> CreateAsync(AddBidFormModel model, Guid itemId, Guid userId);
		Task DeleteAsync(Guid id);
		Task EditAsync(Guid id, EditBidFormModel model);
		Task<bool> ExistAsync(Guid id);
		Task<bool> ExistByItemIdUserId(Guid itemId, Guid userId);
		Task<bool> ExpiredAsync(Guid id);
		Task<AddBidFormModel> GetForCreate(Guid itemId);
		Task<decimal?> GetHighestBidByItemIdAsync(Guid itemId);
		Task<decimal?> GetHighestBidByOfferIdAsync(Guid id);
		Task<Guid> GetItemIdFromOfferIdAsync(Guid id);
		Task<bool> IsOwnerAsync(Guid id, Guid userId);
		Task<bool> IsWinnerAsync(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns>Offers count after the removing.</returns>
		Task<int> RemoveExpiredByItemId(Guid itemId);
		Task<decimal> SufficientQuantity(Guid id, decimal quantity);
	}
}
