using NUnit.Framework;
using SquidMeet.WebSite.Pages.Group;

namespace UnitTests.Pages.Group.Update
{
    /// <summary>
    /// Unit Tests for onget method for MyGroupDetail model
    /// </summary>
    public class MyGroupDetailModelTests
    {
        #region TestSetup

        // Data middle tier
        public static MyGroupDetailModel pageModel;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="meetupService"></param>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new MyGroupDetailModel(TestHelper.MeetupService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("ebf80f1c-3802-4df9-bbda-fd274810a44c");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Meditate with a Monk", pageModel.Meetup.Title);
        }
        #endregion OnGet

    }
}
