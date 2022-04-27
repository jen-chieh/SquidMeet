using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    [TestFixture]
    internal class MeetupTest
    {
        private Meetup _meetup;

        [SetUp]
        public void SetUp()
        {
            _meetup = new Meetup();
        }

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
