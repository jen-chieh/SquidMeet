using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Services.JsonFileLocationHoursService
{
    /// <summary>
    /// Unit Tests for onget method for location hours service
    /// </summary>
    public class LocationHoursTests
    {
        #region TestSetup

        // Data middle tier
        public static LocationHoursModel pageModel;

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new LocationHoursModel()
            {

            };
        }

        #endregion TestSetup

        #region GetLocationHours

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Location_Hours()
        {
            // Arrange
            var locationHoursJson = TestHelper.LocationHoursService.GetLocationHours();
            // Act
            var data = locationHoursJson.ToList();

            // Assert

            Assert.AreEqual(22, data.Count());
            Assert.AreEqual("0", data[0].location_hours_id);
           
            Assert.AreEqual("1", data[1].location_hours_id);
            Assert.AreEqual("Closed", data[1].location_sun_hours);

        }

        #endregion GetLocationHours
    }
}
