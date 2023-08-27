namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Bid;

	public interface IOfferService
	{
		Task<IEnumerable<AllBidViewModel>> AllMineAsync(Guid userId);
	}
}
