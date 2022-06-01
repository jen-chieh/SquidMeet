using System;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Groups()
        {
            // Arrange

            // Act
            pageModel.OnGet("YJ");
            var result = pageModel.Groups;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.IsTrue(pageModel.Groups.Any(group => group.Host.Equals("YJ")));
        }
        #endregion OnGet

        #region OnPost

        /// <summary>
        /// Test to verify OnPost update meetup with valid values keeps valid model state
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Groups()
        {
            // Arrange

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual("../Index", result.PageName);
        }
        #endregion OnPost

        #region OnPostAsync
        [Test]

        /// <summary>
        /// Test to verify OnPost update meetup with invalid values keeps invalid model state
        /// </summary>
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
           

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
