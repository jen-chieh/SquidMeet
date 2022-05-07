using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Login
{
    /// <summary>
    /// Test for CreateAccount.cshtml and CreateUserModelModel with valid and invalid onPost calls
    /// </summary>
    public class LoginTests
    {
        #region TestSetup
        public static LoginModel pageModel;

        // Create new CreateUserModel
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new LoginModel(TestHelper.UserService)
            {
            };

        }

        #endregion TestSetup

        // Create new user and update user count
        #region OnPost
      
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
