using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SquidMeet.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Unit tests for profile update Model with valid and invalid onPost calls and
    /// the onget method
    /// </summary>
    public class ProfileUpdateTests
    {
        #region TestSetup

        // Data middle tier
        public static ProfileUpdateModel pageModel;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProfileUpdateModel(TestHelper.UserService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Users()
        {
            // Arrange

            // Act
            pageModel.OnGet("0");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Blanchard Whitehead", pageModel.UserProfile.name);

        }
        #endregion OnGet

        #region OnPostAsync

        [Test]
        /// <summary>
        /// Test to verify OnPost update meetup with valid values keeps valid model state
        /// </summary>
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.UserProfile = new UserModel
            {
                user_id = "22",
                email = "username@squid.com",
                password = "password",
                name = "test name",
                age = 30,
                gender = "female",
                bio = "hello"
            };

            // Act
            var result = pageModel.OnPost(pageModel.UserProfile) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Profile"));
        }

        [Test]
        /// <summary>
        /// Test to verify OnPost update meetup with invalid values keeps invalid model state
        /// </summary>
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.UserProfile = new UserModel
            {
                user_id = "bogus",
                email = "bogus",
                password = "bogus",
                name = "bogus",
                age = 30,
                gender = "bogus",
                bio = "bogus"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost(pageModel.UserProfile) as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPostAsync
    }
}
