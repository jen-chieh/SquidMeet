using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;


namespace UnitTests.Models
{
    /// <summary>
    /// Unit Test to check for expected values in LocationHoursModel
    /// </summary>
    [TestFixture]
    internal class LocationhoursModelTests
    {
        // Data middle tier
        private LocationHoursModel _locationhoursModel;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _locationhoursModel = new LocationHoursModel();
        }

        /// <summary>
        /// Test to verify model information is accurate
        /// </summary>
        [Test]
        public void GetLocationId_Valid_Test_Reading_Should_Return_ExpectedValue()
        {
            // Arrange

            // Act
            var expectedValue = "0";

            // Assert
            _locationhoursModel.location_hours_id = expectedValue;
            Assert.AreEqual(expectedValue, _locationhoursModel.location_hours_id);
            Assert.IsNotNull(_locationhoursModel.ToString());
        }

        /// <summary>
        /// Test to verify model information is not null
        /// </summary>
        [Test]
        public void locationhoursModelTostring_Valid_Test_model_Should_Return_Nonnull()
        {
            // Arrange

            // Act
          

            // Assert
           
            Assert.IsNotNull(_locationhoursModel.ToString());
        }

    }
}
