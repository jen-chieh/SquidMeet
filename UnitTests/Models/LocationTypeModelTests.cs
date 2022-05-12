using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// Unit Test to check for expected values in LocationTypeModel
    /// </summary>
    [TestFixture]
    internal class LocationTypeModelTests
    {
        // Data middle tier
        private LocationTypeModel _locationType;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _locationType = new LocationTypeModel();
        }

        // Test to verify model information is accurate
        [Test]
        public void GetLocationTypeId_Valid_Test_Reading_Should_Return_ExpectedValue()
        {
            // Arrange
            var data = new LocationTypeModel()
            {
              
                type_id = "1",
                type_name= "Parks"
            };

            // Act
            var expectedValue = "2";

            // Assert
            _locationType.type_id = expectedValue;
            Assert.AreEqual(expectedValue, _locationType.type_id);
            Assert.IsNotNull(data.ToString());
        }
    }
}
