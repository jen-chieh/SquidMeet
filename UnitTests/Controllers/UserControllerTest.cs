using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;

namespace UnitTests.Controllers
{
    class UserControllerTest
    {
        #region TestSetup

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

        }

        #endregion TestSetup

        #region GetUserController

        /// <summary>
        /// Test to verify Controller Get returns all Users
        /// </summary>
        [Test]
        public void OnGet_Controller_Should_Return_All_Users()
        {
            // Arrange
            var controller = new UserController(TestHelper.UserService);
            // Act
            var result = controller.Get().ToList();

            // Assert
            Assert.AreEqual(12, result.Count());
            Assert.AreEqual("Blanchard Whitehead", result[0].name);

        }
        #endregion GetUserController
    }
}
