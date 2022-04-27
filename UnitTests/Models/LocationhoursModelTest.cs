using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;




namespace UnitTests.Models
{
    [TestFixture]
    internal class LocationhoursModelTests
    {
        private LocationHoursModel _locationhoursModel;




        [SetUp]
        public void SetUp()
        {
            _locationhoursModel = new LocationHoursModel();
        }




        [Test]
        public void GetLocationId_Valid_Test_Reading_Should_Return_ExpectedValue()
        {
            // Arrange




            // Act
            var expectedValue = "0";




            // Assert
            _locationhoursModel.location_hours_id = expectedValue;
            Assert.AreEqual(expectedValue, _locationhoursModel.location_hours_id);




        }
    }
}