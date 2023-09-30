namespace Items.Services.Data.Interfaces
{
	using Items.Services.Data.Models.Item;
	using Items.Web.ViewModels.Base;
	using Items.Web.ViewModels.Home;
	using Items.Web.ViewModels.Item;
	using Items.Web.ViewModels.Sell;

	public interface IItemService
	{
		Task<IEnumerable<IndexViewModel>> LastPublicItemsAsync(int numberOfItems);


		

		Task<AllItemServiceModel> GetAllAsync(Guid? userId = null, QueryFilterModel? queryModel = null);


		Task<MineItemServiceModel> GetMineAsync(Guid userId, QueryFilterModel? queryModel = null);


		Task<IEnumerable<ItemForBarterViewModel>> MyAvailableForBarterAsync(Guid userId);

		Task<AllSellServiceModel> MyAllOnMarketAsync(Guid userId, QueryFilterModel? queryModel = null);

		Task<IEnumerable<OnRotationViewModel>> GetDailyRotationsAsync(Guid userId);

		Task SetDailyRotationsAsync(Guid userId, int numberOfItems);



		Task<Guid> CreateItemAsync(ItemFormModel itemFormViewModel, Guid userId);

		Task<ItemFormModel> GetByIdForEditAsync(Guid itemId);

		Task<ItemViewModel> GetByIdForViewAsync(Guid itemId);
		Task<ItemViewModel> GetByIdForViewAsOwnerAsync(Guid itemId);
		Task<DateTime?> GetEndSellDateTime(Guid itemId);
		Task<int?> GetCurrencyIdAsync(Guid itemId);


		Task<bool> IsOwnerAsync(Guid itemId, Guid userId);


		Task UpdateItemAsync(ItemFormModel model, Guid itemId);
		Task<bool> IsOnMarketAsync(Guid id);
		Task<PreDeleteItemViewModel> GetForDeleteByIdAsync(Guid id);
		Task DeleteByIdAsync(Guid id);
		Task<bool> ExistAsync(Guid id);
		Task<bool> IsAuctionAsync(Guid id);
		Task StopSellByItemIdAsync(Guid id);
		Task<AuctionFormModel> GetForAuctionUpdateAsync(Guid id);
		Task AuctionUpdateAsync(AuctionFormModel model, Guid id);
		
		Task<bool> HasQuantity(Guid id);
		Task<decimal> SufficientQuantity(Guid itemId, decimal quantity);
		Task<ItemFormModel> CopyFromContract(Guid id, Guid userId);
		Task<bool> IsValidBarterAsync(Guid? barterItemId, decimal? barterQuantity, Guid userId);

		/// <summary>
		/// In case the barter item is included in the offer, checks if the barter item exists in db.
		/// </summary>
		/// <param name="offerId"></param>
		/// <returns>True if an item is not included.True if an item is included and it is present in db. False if is included in the offer
		/// but is not present in db.</returns>
		Task<bool> ExistBarterItemByOfferIdAsync(Guid offerId);
	}
}
