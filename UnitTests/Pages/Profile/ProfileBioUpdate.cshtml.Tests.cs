﻿
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using SquidMeet.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// Test for ProfileBioUpdateModel for onGet, valid and invalid onPost calls.
    /// </summary>
    public class ProfileBioUpdateTests
    {
        #region TestSetup
        public static ProfileBioUpdateModel pageModel;

        // Initialize ProfileBioUpdateModel with TestHelper
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProfileBioUpdateModel(TestHelper.UserService)
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
        // Test to verify OnPost updating profile bio with valid values keeps valid model state
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
                bio = "valid bio saying hello"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Ensure user is redirected to Profile page
            Assert.AreEqual(true, result.PageName.Contains("Profile"));
        }

        [Test]
        // Test to verify OnPost updating profile bio with invalid values returns invalid model state
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
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPostAsync
    }
}