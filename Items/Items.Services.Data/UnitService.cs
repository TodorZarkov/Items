namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
    using Items.Services.Data.Models.Unit;
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

        public Task<AllUnitInfoServiceModel> AllAsync()
        {
            throw new NotImplementedException();
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

        public Task<long> CountRelationsAsync(int unitId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(UnitServiceModel unitModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int unitId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistByNameAsync(string unitName)
        {
            throw new NotImplementedException();
        }

        public Task<UnitServiceModel> GetByIdAsync(int unitId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsValidIdAsync(int unitId)
		{

			Unit? actualUnit = await dbContext.Units.FindAsync(unitId);

			return actualUnit != null;
		}


	}
}
