using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    [TestFixture]
    internal class UserModelTests
    {
        private UserModel _user;

        [SetUp]
        public void SetUp()
        {
            _user = new UserModel();
        }

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
