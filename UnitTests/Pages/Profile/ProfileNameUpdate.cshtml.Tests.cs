using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using SquidMeet.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// Test for ProfileNameUpdateModel for onGet, valid and invalid onPost calls.
    /// </summary>
    public class ProfileNameUpdateTests
    {
        #region TestSetup

        // Data middle tier
        public static ProfileNameUpdateModel pageModel;

        /// <summary>
        /// Default Constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProfileNameUpdateModel(TestHelper.UserService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// </summary>
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

        /// <summary>
        /// Test to verify OnGet returns a redirect to profile page with an invalid id
        /// </summary>
        [Test]
        public void OnGet_InValid_Should_Return_ProfilePage()
        {

            // Arrange

            // Act
            var httpcontextDefault = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpcontextDefault, Mock.Of<ITempDataProvider>());
            tempData["user"] = "user";
            pageModel.TempData = tempData;
            var result = pageModel.OnGet("1000") as RedirectToPageResult;

            // Assert
           
            Assert.AreEqual(true, result.PageName.Contains("Profile"));
        }

        #endregion OnGet

        #region OnPostAsync

        /// <summary>
        /// Test to verify OnPost update meetup with valid values keeps valid model state
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Profile()
        {
            // Arrange
            pageModel.UserProfile = new UserModel
            {
                user_id = "22",
                email = "username@squid.com",
                password = "validpassword",
                name = "username",
                age = 30,
                gender = "female",
                bio = "hello"
            };
            var httpcontextDefault = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpcontextDefault, Mock.Of<ITempDataProvider>());
            tempData["user"] = "user";
            pageModel.TempData = tempData;
            // Act
            var result = pageModel.OnPost(pageModel.UserProfile) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Ensure user is redirected to Profile page
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
                name = null,
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
