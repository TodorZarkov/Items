namespace Items.Services.Data.Models.Unit
{
    using System.Collections.Generic;

    public class AllUnitInfoServiceModel
    {
        public IEnumerable<AllUnitServiceModel> Units { get; set; } = null!;

        public int TotalCount { get; set; }
    }
}
