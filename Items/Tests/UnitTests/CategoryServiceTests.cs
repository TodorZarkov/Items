namespace ServiceTests.UnitTests
{
    using Items.Services.Data;
    using Items.Services.Data.Interfaces;
    using Items.Web.ViewModels.Category;
    using Tests.UnitTests;

    [TestFixture]
    public class CategoryServiceTests : UnitTestsBase
    {
        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void SetUp()
        {
            categoryService = new CategoryService(dbContext);
        }


        [Test]
        public async Task GetAllPublic_ShouldReturnOnlyCategoriesCreatedByAdmins()
        {
            //Arrange: atleast one user with role admin or super admin must be arranged;
            //atleast one category which is created by user in role admin or supper admin 
            //should be created;

            //Act: just invoke the service method
            var adminCategories =
                await categoryService.GetAllPublicAsync();

            //Assert that a correct number of models and the correct ids are in it
        }

    }
}
