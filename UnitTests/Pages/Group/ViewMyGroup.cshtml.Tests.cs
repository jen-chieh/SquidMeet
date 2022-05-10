using System;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using SquidMeet.WebSite.Pages.Group;

namespace UnitTests.Pages.Group.ViewMyGroupTests
{
    class ViewMyGroupTests
    {
        #region TestSetup
        // Initialize IndexModel

        public static UpdateGroupModel pageModel;

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
        #endregion OnGet
    }
}
