using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{       
        /// <summary>
        /// Unit Test to check for expected values in MeetupModel
        /// </summary>
    [TestFixture]
    internal class MeetupModelTests
    {
        // Data middle tier
        private MeetupModel _meetup;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _meetup = new MeetupModel();
        }

        // Test to verify model information is accurate
        [Test]
        public void GetMeetupId_Valid_Test_Reading_Should_Return_ExpectedValue()
        {
            // Arrange

            // Act
            var expectedValue = "625f11684b4cc8608a5ad58e";

            // Assert
            _meetup.meetup_id = expectedValue;
            Assert.AreEqual(expectedValue, _meetup.meetup_id);
        }
    }
}
