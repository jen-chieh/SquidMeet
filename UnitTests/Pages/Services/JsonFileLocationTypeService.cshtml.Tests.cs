using Microsoft.AspNetCore.Mvc;
using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Services.JsonFileLocationTypeService
{
    /// <summary>
    /// Unit Tests for getlocationtype method for locationtype model
    /// </summary>
    class LocationTypeTests
    {
        #region TestSetup
        // Data middle tier

        public static LocationTypeModel pageModel;

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new LocationTypeModel()
            {
                type_id = "3", type_name="Library"
            };
        }

        #endregion TestSetup

        #region GetLocationType
        // Test to verify OnGet returns correct Locationdata with  is valid
        [Test]
        public void OnGet_Valid_Should_Return_Location_Type()
        {
            // Arrange
            var locationTypeJson = TestHelper.LocationTypeService.GetLocationTypes();
            // Act
            var data = locationTypeJson.ToList();

            // Assert
          
            Assert.AreEqual(3, data.Count());
            Assert.AreEqual("0", data[0].type_id);
            Assert.AreEqual("Bars or Cafes", data[0].type_name);
            Assert.AreEqual("1", data[1].type_id);
            Assert.AreEqual("Parks", data[1].type_name);
            Assert.AreEqual("2", data[2].type_id);
            Assert.AreEqual("Conference Rooms", data[2].type_name);

        }
        #endregion GetLocationTypes
    }
}
