using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// Unit Test to check for expected values in AttendeeModel
    /// </summary>
    [TestFixture]
    internal class AttendeeModelTests
    {
        // Data middle tier
        private AttendeeModel _attendee;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _attendee = new AttendeeModel();
        }

        /// <summary>
        /// Test to verify model information is accurate
        /// </summary>
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

          // Test to verify model is accurate
        [Test]
        public void attendeeModelTostring_Valid_Test_model_Should_Return_Nonnull()
        {
            // Arrange

            // Act
          

            // Assert
           
          Assert.IsNotNull(_attendee.ToString());
        }
    }
}
