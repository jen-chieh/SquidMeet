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
    /// Unit Test to check for expected values in LocationTypeController
    /// </summary>
    class LocationTypeControllerTest
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

        #region GetLocationTypeController

        /// <summary>
        /// Test to verify Controller Get to fetch all Location Types
        /// </summary>
        [Test]
        public void OnGet_Controller_Should_Return_All_Location_Types()
        {
            // Arrange
            var controller = new LocationTypeController(TestHelper.LocationTypeService);
            // Act
            var result = controller.Get().ToList();

            // Assert
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Parks", result[1].type_name);

        }
        #endregion GetLocationTypeController
    }
}
