namespace Tests.UnitTests
{
    using AutoMapper;
    using Items.Data;
    using Items.Data.Models;
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
        public ApplicationUser SuperAdmin { get; set; }

        public ApplicationUser Category1Owner { get; set; }
        public ApplicationUser Category23Owner { get; set; }

        public ApplicationUser NoCategoryOwner { get; set; }

        public Category Category1 { get; set; }

        public Category Category2 { get; set; }

        public Category Category3 { get; set; }

        public Category AdminCategory1 { get; set; }

        public Category AdminCategory2 { get; set; }


        private void SeedDatabase()
        {
            throw new NotImplementedException();
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            this.dbContext.Dispose();
        }
    }
}
