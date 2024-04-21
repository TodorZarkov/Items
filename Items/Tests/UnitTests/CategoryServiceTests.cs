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
        public async Task GetAllPublicAsync_ShouldReturnOnlyCategoriesCreatedByAdmins()
        {
            //Arrange: atleast one user with role admin or super admin must be arranged;
            //atleast one category which is created by user in role admin or supper admin 
            //should be created;

            //Act: just invoke the service method
            var adminCategories =
                await categoryService.GetAllPublicAsync();

            //Assert that a correct number of models and the correct ids are in it
            Assert.That(adminCategories.Count, Is.EqualTo(3), "Checks the number of admin categories.");

            //Assert that a correct ids are in the result
            Assert.That(adminCategories.Select(ac => ac.Id).Intersect(new int[] { 6, 4, 5 }).Count(), Is.EqualTo(3), "Checks whether the expected category ids 4,5,6 are actually these.");
        }

        [Test]
        public async Task GetMineAsync_ShouldReturnOnlyTheSpecifiedUserCategories()
        {
            var userCategories =
                await categoryService.GetMineAsync(Category23Owner.Id);

            Assert.That(userCategories.Count, Is.EqualTo(2)
                , "Checks the number of the user categories.");
            Assert.That(userCategories.Select(uc => uc.Id).Intersect(new int[] { 2, 3}).Count(), Is.EqualTo(2)
                , "Checks whether the expected category ids 2,3 are actually these.");
        }

        [Test]
        public async Task AllForSelectAsync_ShouldReturnAllTheSpecifiedUserCategoriesAndAllTheAdminCategories()
        {
            var forSelectCategories =
                await categoryService.AllForSelectAsync(Category23Owner.Id);

            Assert.That(forSelectCategories.Count, Is.EqualTo(5)
                , "Checks the number of the user and admin's(public) categories.");
            Assert.That(forSelectCategories.Select(c => c.Id).Intersect(new int[] { 2, 3, 6 , 4 , 5 }).Count(), Is.EqualTo(5)
                , "Checks whether the expected category ids 2, 3, 6 , 4 , 5 are actually these.");
        }

        [Test]
        public async Task GetAllPublicIdsAsync_ShouldReturnOnlyCategoryIdsCreatedByAdmins()
        {
            var adminCategoryIds =
               await categoryService.GetAllPublicIdsAsync();


            Assert.That(adminCategoryIds.Count, Is.EqualTo(3), "Checks the number of admin category ids.");

            Assert.That(adminCategoryIds.Intersect(new int[] { 6, 4, 5 }).Count(), Is.EqualTo(3), "Checks whether the expected category ids 4,5,6 are actually these.");
        }

    }
}
