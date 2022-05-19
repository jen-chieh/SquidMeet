using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;


namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Unit Tests for valid onpost method for profile model
    /// </summary>
    public class ProfileTests
    {
        #region TestSetup

        // Data middle tier
        public static ProfileModel pageModel;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProfileModel(TestHelper.UserService)
            {
            };
        }

        #endregion TestSetup

        #region OnPost

        /// <summary>
        /// Test to verify OnPost update meetup with valid values keeps valid model state
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Users()
        {
            // Arrange

            // Act
            pageModel.OnGet("0");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Blanchard Whitehead", pageModel.Product.name);

        }

        #endregion OnPost
    }
}
