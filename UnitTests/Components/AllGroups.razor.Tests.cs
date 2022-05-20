using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using SquidMeet.WebSite.Components;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Components
{
    /// <summary>
    /// Unit tests for AllGroups.razor utilizing Bunit for testing that the page markups
    /// include expected event titles
    /// </summary>
    public class AllGroupsTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        /// <summary>
        /// Default constructor
        /// </summary>
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        /// <summary>
        /// Test to ensure the all groups page markup contains the title of one of the default events
        /// </summary>
        public void AllGroups_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileMeetupService>(TestHelper.MeetupService);

            // Act
            var page = RenderComponent<AllGroups>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Intro to Javascript"));
        }

    }
}
