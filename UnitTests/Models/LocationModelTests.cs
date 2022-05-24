using NUnit.Framework;
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
            _locationModel.location_id = expectedValue;
            Assert.AreEqual(expectedValue, _locationModel.location_id);
          
        }

        /// <summary>
        /// Test to verify model information is not null
        /// </summary>
        [Test]
        public void GetLocationModelTostring_Valid_Test_Reading_Should_Return_Nonnull()
        {
            // Arrange

            // Act
       
            // Assert
          
            Assert.IsNotNull(_locationModel.ToString());
        }

    }
}
