using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;

namespace UnitTests.Controllers
{
    // <summary>
    /// Unit Test to check for expected values in LocationHoursController
    /// </summary>
    class LocationHoursControllerTest
    {
        #region TestSetup

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

        }

        #endregion TestSetup

        #region GetLocationHoursController

        /// <summary>
        /// Test to Controller on Get to fetch all Location Hours
        /// </summary>
        [Test]
        public void OnGet_Controller_Should_Return_All_Location_Hours()
        {
            // Arrange
            var controller = new LocationHoursController(TestHelper.LocationHoursService);
            // Act
            var result = controller.Get().ToList();

            // Assert
            Assert.AreEqual(20, result.Count());
            Assert.AreEqual("1", result[1].location_hours_id);

        }
        #endregion GetLocationHoursController
    }
}
