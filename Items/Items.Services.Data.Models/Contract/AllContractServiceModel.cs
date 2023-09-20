namespace Items.Services.Data.Models.Contract
{
	using Items.Web.ViewModels.Deal;

	public class AllContractServiceModel
	{
		public AllContractServiceModel()
		{
			Contracts = new HashSet<ContractAllViewModel>();
		}

		public IEnumerable<ContractAllViewModel> Contracts { get; set; }

		public int TotalContractsCount { get; set; }
	}
}
