using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;


namespace UnitTests.Pages.Product.Create
{
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
            var oldCount = TestHelper.UserService.GetUsers().Count();

            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, TestHelper.UserService.GetUsers().Count());
        }
        #endregion OnPost
    }
}
