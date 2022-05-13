
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

        // Data middle tier
        public static ReadModel pageModel;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// </summary>
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
