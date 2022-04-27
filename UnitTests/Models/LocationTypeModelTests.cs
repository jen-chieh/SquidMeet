using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    [TestFixture]
    internal class LocationTypeModelTests
    {
        private LocationTypeModel _locationType;

        [SetUp]
        public void SetUp()
        {
            _locationType = new LocationTypeModel();
        }

        [Test]
        public void GetLocationTypeId_Valid_Test_Reading_Should_Return_ExpectedValue()
        {
            // Arrange

            // Act
            var expectedValue = "2";

            // Assert
            _locationType.type_id = expectedValue;
            Assert.AreEqual(expectedValue, _locationType.type_id);
        }
    }
}
