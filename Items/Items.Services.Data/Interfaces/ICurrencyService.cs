namespace Items.Services.Data.Interfaces
{
	using Items.Web.ViewModels.Currency;

	public interface ICurrencyService
	{
		Task<IEnumerable<ForSelectCurrencyViewModel>> AllForSelectAsync();

		Task<bool> ExistsByIdAsync(int currencyId);
	}
}
