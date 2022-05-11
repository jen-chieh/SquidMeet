
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using SquidMeet.WebSite.Pages.Group;
using SquidMeet.WebSite.Pages.NewGroup;
using System;

namespace UnitTests.Pages.Group.Index
{
    /// <summary>
    /// Unit Tests for onget method for CreateNewGroup model and onpost method for
    /// valid and invalid calls
    /// </summary>
    public class IndexGroupTest
    {
        // Data middle tier
        #region TestSetup
        public static CreateNewGroupModel pageModel;

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateNewGroupModel(TestHelper.MeetupService, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        // Test to verify OnGet returns correct data with a given id and model state is valid
        [Test]
        public void OnGet_Valid_Should_Return_Location()
        {
            // Arrange

            // Act

            pageModel.OnGet("2");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Newcastle Library", pageModel.location.name);

        }
        #endregion OnGet
        #region OnPost
        // Test to verify the model state is valid with locations
        [Test]
        public void OnPost_Valid_Should_Return_Location()
        {
            // Arrange

            // Act
            pageModel.newMeetup = new MeetupModel
            {
                Title = "New title"
            };

            var result = pageModel.OnPost() as RedirectToPageResult;

            var meetupResult = pageModel.MeetupService.GetMeetups();
            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("../Index", result.PageName);
        }
        #endregion OnGet
        #region OnPostAsync
        [Test]
        // Test to verify OnPost adding new meetup with invalid values results in invalid model state
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.newMeetup = new MeetupModel
            {
                Title = "error"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
#endregion OnPostAsync
    }
}
