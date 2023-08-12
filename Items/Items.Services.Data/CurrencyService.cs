namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Currency;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class CurrencyService : ICurrencyService
	{
		private readonly ItemsDbContext dbContext;

		public CurrencyService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<ForSelectCurrencyViewModel>> AllForSelectAsync()
		{
			IEnumerable<ForSelectCurrencyViewModel> availableCurrencies = await dbContext.Currencies
				.Select(c => new ForSelectCurrencyViewModel
				{
					CurrencyId = c.Id,
					CurrencySymbol = c.Symbol
				})
				.ToArrayAsync();

			return availableCurrencies;
		}

		public async Task<bool> ExistsByIdAsync(int currencyId)
		{
			bool result = await dbContext
				.Currencies
				.AnyAsync(c => c.Id == currencyId);

			return result;
		}
	}
}
