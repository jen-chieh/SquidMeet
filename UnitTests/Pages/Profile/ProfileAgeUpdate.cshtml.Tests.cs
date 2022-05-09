
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SquidMeet.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// Test for ProfileAgeUpdateModel for onGet, valid and invalid onPost calls.
    /// </summary>
    public class ProfileAgeUpdateTests
    {
        #region TestSetup
        public static ProfileAgeUpdateModel pageModel;

        // Initialize ProfileAgeUpdateModel with TestHelper
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProfileAgeUpdateModel(TestHelper.UserService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        // Verify that the user's name matches to the information from OnGet with a matching user_id
        [Test]
        public void OnGet_Valid_Should_Return_Username()
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
        // Test to verify OnPost updating profile age with valid values keeps valid model state
        [Test]
        public void OnPostAsync_Valid_Should_Return_Profile()
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
            // Ensure user is redirected to Profile page
            Assert.AreEqual(true, result.PageName.Contains("Profile"));
        }

        [Test]
        // Test to verify OnPost updating profile age with invalid values returns invalid model state
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.UserProfile = new UserModel
            {
                user_id = "bogus",
                email = "bogus",
                password = "bogus",
                name = "bogus",
                age = -1,
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
