using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// Unit Test to check for expected values in LocationModel
    /// </summary>
    [TestFixture]
    internal class LocationModelTests
    {
        // Data middle tier
        private LocationModel _locationModel;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _locationModel = new LocationModel();
        }

        // Test to verify model information is accurate
        [Test]
        public void GetLocationId_Valid_Test_Reading_Should_Return_ExpectedValue()
        {
            //
            // Arrange
            var data = new LocationModel()
            {
                location_id = System.Guid.NewGuid().ToString(),
                name = "Enter Name",
                address = "Enter Address",
                type_id = "Enter Type ID",
                img = "",
            };


            // Act
            var expectedValue = "0";

            // Assert
            _locationModel.location_id = expectedValue;
            Assert.AreEqual(expectedValue, _locationModel.location_id);
            Assert.IsNotNull(data.ToString());
        }
    }
}
