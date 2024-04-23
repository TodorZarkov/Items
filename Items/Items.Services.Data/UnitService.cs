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

        /// <summary>
        /// DbUpdateException if the unit with the specified unitId is already used in Item or Contract due to on delete restrict behavior.
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"> if the unitId doesn't exist</exception>
        /// <exception cref="DbUpdateException"  ></exception>
        public async Task DeleteByIdAsync(int unitId)
        {
            Unit unit = await dbContext.Units.FindAsync(unitId) 
                ?? throw new ArgumentNullException("Can not find Unit with specified unitId.");

            dbContext.Units.Remove(unit);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByNameAsync(string unitName)
        {
            bool result = await dbContext.Units
                .AnyAsync(u => u.Name.ToLower() == unitName.ToLower());

            return result;
        }

        public async Task<UnitServiceModel> GetByIdAsync(int unitId)
        {

            Unit unit = await dbContext.Units.FindAsync(unitId) 
                ?? throw new ArgumentNullException("No unit with the specified id.");

            UnitServiceModel model = new UnitServiceModel()
            {
                Id = unit.Id,
                Name = unit.Name,
                Symbol = unit.Symbol
            };

            return model;
        }

        public async Task<bool> IsValidIdAsync(int unitId)
		{

			Unit? actualUnit = await dbContext.Units.FindAsync(unitId);

			return actualUnit != null;
		}


	}
}
