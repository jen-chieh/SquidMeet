using System;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using SquidMeet.WebSite.Pages.Group;

namespace UnitTests.Pages.Group.ViewMyGroupTests
{
    /// <summary>
    /// Unit Tests for onget and onpost methods for UpdateGroup model
    /// </summary>
    class ViewMyGroupTests
    {
        #region TestSetup
        // Initialize UpdateGroupModel (data middle tier)

        public static UpdateGroupModel pageModel;
        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateGroupModel(TestHelper.MeetupService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        // Test to verify the model state is valid with products
        [Test]
        public void OnGet_Valid_Should_Return_Groups()
        {
            // Arrange

            // Act
            pageModel.OnGet("Will");



            // Assert
            Assert.AreEqual("Feet First Walks", pageModel.Group.Title);
        }
        #endregion OnGet

        #region OnPost
        // Test to verify the model state is valid with products
        [Test]
        public void OnPost_Valid_Should_Return_Groups()
        {
            // Arrange

            // Act
            pageModel.Group = new MeetupModel
            {
                Title = "New title"
            };

            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual("../Index", result.PageName);
        }
        #endregion OnPost

#region OnPostAsync
        [Test]
        // Test to verify OnPost meetup with invalid values results in invalid model state
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Group = new MeetupModel
            {
                meetup_id = "ab012001-2db8-4270-8fcb-sdf",
                location = "Seattle",
                LocationType = "Indoor",
                Title = "Intro to Java",
                Date = "11/22/12",
                Attendees = null,
                Host = "YJ",
                Description = "Java is one of the most widely used programming languages.",
                InviteCode = "52553b96-7519-4988-aa0e-999afb46f4dc",
                Img = "",
                Video = ""
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
