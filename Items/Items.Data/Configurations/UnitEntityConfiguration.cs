namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UnitEntityConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder
                .HasData(GenerateUnits());
        }

        private Unit[] GenerateUnits()
        {
            List<Unit> units = new List<Unit>();

            Unit unit = new Unit
            {
                Id = 1,
                Symbol = "pcs",
                Name = "Pieces"
            };
            units.Add(unit);
            
            unit = new Unit
            {
                Id = 2,
                Symbol = "m",
                Name = "Meter"
            };
            units.Add(unit);
            
            unit = new Unit
            {
                Id = 3,
                Symbol = "m2",
                Name = "Square Meter"
            };
            units.Add(unit);
            
            unit = new Unit
            {
                Id = 4,
                Symbol = "kg",
                Name = "Kilogram"
            };
            units.Add(unit);


            return units.ToArray();
        }
    }
}
