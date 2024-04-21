namespace ServiceTests.UnitTests
{
    using Items.Data.Models;
    using Items.Services.Data;
    using Items.Services.Data.Interfaces;
    using Items.Web.ViewModels.Category;
    using Tests.UnitTests;

    [TestFixture]
    public class CategoryServiceTests : UnitTestsBase
    {
        private ICategoryService categoryService;

        [SetUp]
        public void SetUp()
        {
            base.SetUpBase();
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
            Assert.That(forSelectCategories.Select(c => c.Id).Intersect(new int[] { 2, 3, 6, 4, 5 }).Count(), Is.EqualTo(5)
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

        [Test]
        public async Task GetAllIdsAsync_ShouldReturnAllExistingCategoryIds()
        {
            var categoryIds =
               await categoryService.GetAllIdsAsync();


            Assert.That(categoryIds.Count, Is.EqualTo(6)
                , "Checks the number of all existing category ids.");

            Assert.That(categoryIds.Intersect(new int[] { 1, 2, 3, 6, 4, 5 }).Count(), Is.EqualTo(6), "Checks whether the expected category ids 1, 2, 3, 6, 4, 5 are actually these.");
        }

        [Test]
        public async Task GetForSelectAsync_ShouldReturnJustTheSpecifiedUserCategories()
        {
            var forSelectCategories =
                await categoryService.GetForSelectAsync(Category23Owner.Id);

            Assert.That(forSelectCategories.Count, Is.EqualTo(2)
                , "Checks the number of the user and admin's(public) categories.");
            Assert.That(forSelectCategories.Select(c => c.Id).Intersect(new int[] { 2, 3}).Count(), Is.EqualTo(2)
                , "Checks whether the expected category ids 2, 3 are actually these.");
        }

        [Test]
        public async Task GetForSelectAsyncWithNullUser_ShouldReturnAllTheAdminCategories()
        {
            var forSelectCategories =
                await categoryService.GetForSelectAsync();

            Assert.That(forSelectCategories.Count, Is.EqualTo(3)
                , "Checks the number of the admin's(public) categories.");
            Assert.That(forSelectCategories.Select(c => c.Id).Intersect(new int[] {6, 4, 5 }).Count(), Is.EqualTo(3)
                , "Checks whether the expected category ids 6 , 4 , 5 are actually these.");
        }

        [Test]
        public async Task AddAsync_ShouldCreateNewCategory()
        {
            CategoryFormViewModel theNewCategory = new CategoryFormViewModel()
            {
                Name = "TheNewCategory"
            };

            int theNewCategoryId = 
                await categoryService.AddAsync(theNewCategory, NoCategoryOwner.Id);

            Assert.That(theNewCategoryId, Is.EqualTo(7), "Asserts that the new category id is equal to the next available integer id - 7");

            var createdCategory =
                (await categoryService.GetMineAsync(NoCategoryOwner.Id)).FirstOrDefault();
            Assert.That(createdCategory, Is.Not.EqualTo(null), "Ensures the category is created");
            Assert.That(createdCategory.Name, Is.EqualTo("TheNewCategory"), "Ensures the newly created category is the same with name TheNewCategory");

        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteTheCategoryWithTheSpecifiedId()
        {
            var categoryId = Category1.Id;
            await categoryService.DeleteAsync(categoryId);

            var userCategories =
                await categoryService.GetMineAsync(Category1Owner.Id);

            Assert.That(userCategories.Count, Is.EqualTo(0)
                , "Checks the number of the user categories left.");

        }

        [Test]
        public async Task IsAllowedIdsAsync_ShouldCheckIfTheUserIsAllowedToSelectTheseCategories()
        {
            var selectedCategories = new int[] { 2, 3, 6 };
            var allowed = await categoryService
                .IsAllowedIdsAsync(selectedCategories, Category23Owner.Id);
            Assert.True(allowed,"Is allowed to select his won ids(2,3) and the admin's ones 6)");

            selectedCategories = new int[] { 1 };
            allowed = await categoryService
               .IsAllowedIdsAsync(selectedCategories, Category23Owner.Id);
            Assert.False(allowed, "Is Not allowed to select other user's category ids (1)");

            selectedCategories = new int[] { 50 , 51 };
            allowed = await categoryService
               .IsAllowedIdsAsync(selectedCategories, Category23Owner.Id);
            Assert.False(allowed, "Is Not allowed to select not existing ids (50 , 51)");
        }

        [Test]
        public async Task IsAllowedPublicIdsAsync_ShouldCheckWetherTheSpecifiedIdsAreAllPublic()
        {
            var selectedCategories = new int[] { 4, 5, 6 };
            var allowed = await categoryService
                .IsAllowedPublicIdsAsync(selectedCategories);
            Assert.True(allowed, "Is allowed to select  admin ids (4 , 5 , 6)");

            selectedCategories = new int[] { 3, 4, 5, 6 };
            allowed = await categoryService
                .IsAllowedPublicIdsAsync(selectedCategories);
            Assert.False(allowed
                , "Is not allowed to select  admin plus user ids (3, 4 , 5 , 6)");
        }

        [Test]
        public async Task ExistNameAsync_ShouldCheckWhetherTheGivenCategoryNameIsTaken()
        {
            string categoryName = Category1.Name;
            bool isTaken = await categoryService.ExistNameAsync(categoryName, Category23Owner.Id);
            Assert.False(isTaken, "The Category1 is not category of Category23Owner neither is admin's category, so it should give negative result.");

            categoryName = Category2.Name;
            isTaken = await categoryService.ExistNameAsync(categoryName, Category23Owner.Id);
            Assert.True(isTaken, "The Category2 is category of Category23Owner, so it should give positive result.");

            categoryName = SuperAdminCategory1.Name;
            isTaken = await categoryService.ExistNameAsync(categoryName, Category23Owner.Id);
            Assert.True(isTaken, "The SuperAdminCategory1 is category of an admin, so it should give positive result.");
        }

        [Test]
        public async Task IsOwnerAsync_ShoudCheckWhetherTheGivenUserIsTheOwnerOfTheGivenCategory()
        {
            bool isOwner = await categoryService.IsOwnerAsync(Category1Owner.Id, Category1.Id);
            Assert.True(isOwner, "The Category1Owner should be owner of Category1.");

            isOwner = await categoryService.IsOwnerAsync(Category1Owner.Id, AdminCategory.Id);
            Assert.False(isOwner, "The Category1Owner should NOT be owner of the AdminCategory.");
        }


        [Test]
        public async Task ExistAsync_ShoudReturnPositiveIfTheGivenCategoryIdExist()
        {
            bool exist = await categoryService.ExistAsync(Category1.Id);
            Assert.True(exist, "Should be positive when checked Category1's id");

            exist = await categoryService.ExistAsync(50);
            Assert.False(exist, "Should be negative when checked id = 50");
        }

        [Test]
        public async Task CountReferencesAsync_ShouldCountAllItemsThatHasTheGivenCategory()
        {
            var relationsCount = await categoryService.CountReferencesAsync(Category2.Id);
            Assert.That(relationsCount, Is.EqualTo(1), "The Category2 should have one item that has it.");

            relationsCount = await categoryService.CountReferencesAsync(Category1.Id);
            Assert.That(relationsCount, Is.EqualTo(0), "The Category1 should have NO item that has it.");
        }

        [TearDown]
        public void TearDown()
        {
            base.TearDownBase();
        }

    }
}
