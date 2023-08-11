namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Deal;

	public interface IContractService
	{
		public Task<IEnumerable<AllDealViewModel>> AllAsync(Guid userId);

	}
}
