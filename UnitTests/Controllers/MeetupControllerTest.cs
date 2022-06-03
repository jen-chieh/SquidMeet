using System.Linq;
using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;

namespace UnitTests.Controllers
{
    // <summary>
    /// Unit Test to check for expected values in MeetupController
    /// </summary>
    class MeetupControllerTest
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

        #region GetMeetUpController

        /// <summary>
        /// Test to verify Get Controller to fetch all Meet ups
        /// </summary>
        [Test]
        public void OnGet_Controller_Should_Return_All_MeetUps()
        {
            // Arrange
            var controller = new MeetupController(TestHelper.MeetupService);
            // Act
            var result = controller.Get().ToList();

            // Assert
            Assert.AreEqual(8, result.Count());
            Assert.AreEqual("59170836-95ac-42a5-833f-9f026c8dc152", result[1].meetup_id);

        }
        #endregion GetMeetUpController
    }
}
