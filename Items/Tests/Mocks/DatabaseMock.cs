namespace Tests.Mocks
{
    using Items.Data;
    using Microsoft.EntityFrameworkCore;

    public static class DatabaseMock
    {
        public static ItemsDbContext Instance 
        {
            get
            {
                DbContextOptions<ItemsDbContext> opt = new DbContextOptionsBuilder<ItemsDbContext>()
                    .UseInMemoryDatabase($"ItemsInMemoryDB{DateTime.Now.Ticks}")
                    .Options;

                return new ItemsDbContext(options: opt, seed: false);
            }
        }
    }
}
