namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Bid;

	public interface IOfferService
	{
		Task<IEnumerable<AllBidViewModel>> AllMineAsync(Guid userId);
		Task<Guid> CreateAsync(BidFormModel model, Guid itemId, Guid userId);
		Task<BidFormModel> GetForCreate(Guid itemId);
		Task<decimal?> GetHighestBidByItemIdAsync(Guid itemId);
	}
}
