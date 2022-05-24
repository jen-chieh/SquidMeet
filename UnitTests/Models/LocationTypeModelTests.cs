using NUnit.Framework;
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

        /// <summary>
        /// Test to verify model information is accurate
        /// </summary>
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

        /// <summary>
        /// Test to verify model information is not null
        /// </summary>
        [Test]
        public void GetLocationTypeTostring_Valid_Test_Reading_Should_Return_nonNull()
        {
            // Arrange


            // Act
          

            // Assert
           
            Assert.IsNotNull(_locationType.ToString());

        }

    }
}
