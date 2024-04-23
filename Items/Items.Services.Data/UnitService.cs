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

        public async Task<AllUnitInfoServiceModel> AllAsync()
        {
            IEnumerable<AllUnitServiceModel> serviceModel = await dbContext.Units
                .Select(u => new AllUnitServiceModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    Symbol = u.Symbol
                })
                .ToArrayAsync();


            AllUnitInfoServiceModel infoModel = new AllUnitInfoServiceModel()
            {
                Units = serviceModel,
                TotalCount = serviceModel.Count()
            };
            return infoModel;
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

        public async Task<long> CountRelationsAsync(int unitId)
        {
            long relatedItems = await dbContext.Items
                .LongCountAsync(i => i.UnitId == unitId);

            long relatedContracts = await dbContext.Contracts
                .LongCountAsync(c => c.UnitId == unitId || c.BarterUnitId == unitId);


            return relatedItems + relatedContracts;
        }

        public async Task<int> CreateAsync(UnitServiceModel unitModel)
        {
            Unit unit = new Unit()
            {
                Name = unitModel.Name,
                Symbol = unitModel.Symbol
            };

            await dbContext.Units.AddAsync(unit);

            await dbContext.SaveChangesAsync();

            return unit.Id;
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
