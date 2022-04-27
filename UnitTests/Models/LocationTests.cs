using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    [TestFixture]
    internal class LocationTests
    {
        private LocationModel _locationModel;

        [SetUp]
        public void SetUp()
        {
            _locationModel = new LocationModel();
        }

        [Test]
        public void GetLocationId_Valid_Test_Reading_Should_Return_ExpectedValue()
        {
            // Arrange

            // Act
            var expectedValue = "0";

            // Assert
            _locationModel.location_id = expectedValue;
            Assert.AreEqual(expectedValue, _locationModel.location_id);
        }
    }
}
