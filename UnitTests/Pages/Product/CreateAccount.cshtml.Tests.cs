using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Test for CreateAccount.cshtml and CreateUserModelModel with valid and invalid onPost calls
    /// </summary>
    public class CreateAccountTests
    {
        #region TestSetup
        public static CreateUserModelModel pageModel;

        // Create new CreateUserModel
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateUserModelModel(TestHelper.UserService)
            {
            };

        }

        #endregion TestSetup

        // Create new user and update user count
        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Return_Users()
        {

            // Arrange
            pageModel.User = new UserModel
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
            var result = pageModel.OnPost(pageModel.User) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        [Test]
        // Test to verify OnPost adding new account with invalid values results in invalid model state
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.User = new UserModel
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
            var result = pageModel.OnPost(pageModel.User) as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}
