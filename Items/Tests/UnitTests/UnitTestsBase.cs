namespace Tests.UnitTests
{
    using AutoMapper;
    using Items.Data;
    using System;
    using Tests.Mocks;

    public class UnitTestsBase
    {
        protected ItemsDbContext dbContext;
        protected IMapper mapper;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            this.dbContext = DatabaseMock.Instance;
            //this.mapper = MapperMock.Instance;

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
