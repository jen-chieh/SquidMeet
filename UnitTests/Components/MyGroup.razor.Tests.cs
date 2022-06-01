using ContosoCrafts.WebSite.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SquidMeet.WebSite.Components;

namespace UnitTests.Components
{
    /// <summary>
    /// Unit tests for MyGroup.razor utilizing Bunit for testing that the page markups
    /// include expected event titles
    /// </summary>
    public class MyGroupTests : BunitTestContext
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
        /// Test to ensure the my group page markup contains the title of one of the default events
        /// </summary>
        public void MyGroup_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileMeetupService>(TestHelper.MeetupService);

            // Act
            var page = RenderComponent<MyGroup>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(false, result.Contains("Intro to Javascript"));
        }

    }
}
