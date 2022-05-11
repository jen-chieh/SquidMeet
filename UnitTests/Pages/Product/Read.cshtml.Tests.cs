
using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    /// <summary>
    /// Unit tests for onget method for read Model
    /// </summary>
    public class ReadTests
    {
        #region TestSetup
        // Initialize ReadModel
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        // Test to verify model state is valid and provides the correct data for a given id
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("0");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Mr. West Cafe Bar - Downtown", pageModel.Product.name);
        }
        #endregion OnGet
    }
}
