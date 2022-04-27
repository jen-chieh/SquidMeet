using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    [TestFixture]
    internal class AttendeeTests
    {
        private Attendee _attendee;

        [SetUp]
        public void SetUp()
        {
            _attendee = new Attendee();
        }

        [Test]
        public void GetUserId_Valid_Test_Reading_Should_Return_ExpectedValue()
        {
            // Arrange

            // Act
            var expectedValue = "3";

            // Assert
            _attendee.UserId = expectedValue;
            Assert.AreEqual(expectedValue, _attendee.UserId);
        }
    }
}
