﻿namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Deal;

	public interface IContractService
	{
		public Task<IEnumerable<ContractAllViewModel>> AllAsync(Guid userId);
		Task CancelAsync(Guid id, Guid userId);
		Task<bool> CanComplainAndReceiveAsync(Guid id, Guid userId);
		Task<bool> CanReviseAsync(Guid id, Guid userId);
		Task ChangeReviserAsync(Guid id);
		Task CompleteAsync(Guid id, Guid userId);
		Task CreateAsync(ContractFormViewModel previewModel, Guid itemId, Guid buyerId);
		Task<ContractFormViewModel> GetForCreate(ContractFormViewModel model, Guid itemId, Guid buyerId);
		Task<ContractViewModel> GetForDetailsAsync(Guid contractId);
		Task<ContractFormViewModel> GetForPreviewByIdAsync(Guid itemId);
		Task<ContractFormViewModel> GetForRevise(Guid id, Guid userId);
		Task<bool> IsBuyerAsync(Guid dealId, Guid userId);
		Task<bool> IsSellerAsync(Guid id, Guid userId);
		Task<bool> SellerOrBuyerAsync(Guid contractId, Guid userId);
		Task SetSignedAsync(Guid id);
		Task<bool> SignedAsync(Guid id);
		Task UpdateAsync(Guid id, ContractFormViewModel model);
	}
}
