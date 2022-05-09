using Microsoft.AspNetCore.Mvc;
using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System;
using System.Text;

namespace UnitTests.Pages.Services.JsonFileLocationHoursService
{
    public class LocationHoursTests
    {
        #region TestSetup
        public static LocationHoursModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new LocationHoursModel()
            {

            };
        }

        #endregion TestSetup

        #region GetLocationHours
        // Test to verify OnGet returns correct LocationHours data
        [Test]
        public void OnGet_Valid_Should_Return_Location_Hours()
        {
            // Arrange
            var locationHoursJson = TestHelper.LocationHoursService.GetLocationHours();
            // Act
            var data = locationHoursJson.ToList();

            // Assert

            Assert.AreEqual(3, data.Count());
            Assert.AreEqual("0", data[0].location_hours_id);
            Assert.AreEqual("10AM-5PM", Encoding.UTF8.GetString(Encoding.Default.GetBytes(data[0].location_mon_hours)));
            Assert.AreEqual("2", data[2].location_hours_id);
            Assert.AreEqual("06:30-8:30", Encoding.UTF8.GetString(Encoding.Default.GetBytes(data[2].location_mon_hours)));

        }
        #endregion GetLocationHours
    }
}
