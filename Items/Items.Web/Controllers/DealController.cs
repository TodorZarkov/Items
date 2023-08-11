namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Deal;
	using Microsoft.AspNetCore.Mvc;

	public class DealController : BaseController
	{
		private readonly IContractService contractService;

		public DealController(IContractService contractService)
		{
			this.contractService = contractService;
		}

		public async Task<IActionResult> All()
		{
			Guid userId = Guid.Parse(User.GetId());
			IEnumerable<AllDealViewModel> allDealsModel = await contractService.AllAsync(userId);

			return View(allDealsModel);
		}
	}
}
