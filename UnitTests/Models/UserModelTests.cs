using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// Unit Test to check for expected values in UserModel
    /// </summary>
    [TestFixture]
    internal class UserModelTests
    {
        // Data middle tier
        private UserModel _user;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _user = new UserModel();
        }

        // Test to verify model information is accurate
        [Test]
        public void GetUserId_Valid_Test_Reading_Should_Return_ExpectedValue()
        {
            // Arrange

            // Act
            var expectedValue = "3";

            // Assert
            _user.user_id = expectedValue;
            Assert.AreEqual(expectedValue, _user.user_id);
        }
    }
}
