using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

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

        #region OnGet

        /// <summary>
        /// Test to verify OnPost update meetup with valid values keeps valid model state
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Users()
        {
            // Arrange

            // Act
            pageModel.OnGet("0");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Blanchard Whitehead", pageModel.Product.name);

        }
        /// <summary>
        /// Test to verify OnPost update meetup with valid values keeps valid model state
        /// </summary>
        [Test]
        public void OnGet_inValid_Should_Return_Homepage()
        {
            // Arrange

            // Act

            var result = pageModel.OnGet("1230123") as RedirectToPageResult;

            // Assert

            Assert.AreEqual(false, result.PageName.Contains("Index"));
        }

        #endregion OnGet
    }
}
