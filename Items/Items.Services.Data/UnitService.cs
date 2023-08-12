namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Unit;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class UnitService : IUnitService
	{
		private readonly ItemsDbContext dbContext;

		public UnitService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<ForSelectUnitViewModel>> AllForSelectAsync()
		{
			IEnumerable<ForSelectUnitViewModel> forSelectUnits = await dbContext.Units
				.Select(u => new ForSelectUnitViewModel
				{
					UnitId = u.Id,
					UnitSymbol = u.Symbol
				})
				.ToArrayAsync();

			return forSelectUnits;
		}

		public async Task<bool> IsValidId(int unitId)
		{
			Unit? actualUnit = await dbContext.Units.FindAsync(unitId);

			return actualUnit != null;
		}


	}
}
