using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;


namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Unit Tests for onget method for create model
    /// </summary>
    public class CreateTests
    {
        // Data middle tier
        #region TestSetup
        public static CreateModel pageModel;

        // Initialize CreateModel using TestHelper
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        // Create a new location object and verify that the location was successfully added
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount+1, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet
    }
}
