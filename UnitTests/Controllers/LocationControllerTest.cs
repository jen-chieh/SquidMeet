using System.Linq;
using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;
using static ContosoCrafts.WebSite.Controllers.LocationController;

namespace UnitTests.Controllers
{
    // <summary>
    /// Unit Test to check for expected values in LocationController
    /// </summary>
    class LocationControllerTest
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

        #region GetLocationController

        /// <summary>
        /// Test to Controller Get to return all Locations
        /// </summary>
        [Test]
        public void OnGet_Controller_Should_Return_All_Location()
        {
            // Arrange
            var controller = new LocationController(TestHelper.ProductService);
            // Act
           var result = controller.Get().ToList();

            // Assert
            Assert.AreEqual(20, result.Count());

        }
        #endregion GetLocationController

        #region PatchLocationController

        /// <summary>
        /// Test to Controller on Patch to update Rating of a location
        /// </summary>
        [Test]
        public void OnPatch_Controller_Should_Return_Ok()
        {
            // Arrange
            var controller = new LocationController(TestHelper.ProductService);
            RatingRequest ratingRequest = new RatingRequest()
            {
                ProductId = "0",
                Rating = 1
            };
            // Act
            var update = controller.Patch(ratingRequest);

            var final_result = controller.Get().ToList();


            // Assert
            Assert.AreEqual(1, final_result[0].rating[0]);

        }
        #endregion PatchLocationController
    }
}
