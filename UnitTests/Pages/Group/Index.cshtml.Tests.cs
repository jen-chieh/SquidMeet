
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using SquidMeet.WebSite.Pages.Group;
using SquidMeet.WebSite.Pages.NewGroup;
using System;

namespace UnitTests.Pages.Group.Index
{
    public class IndexGroupTest
    {
        #region TestSetup
        public static CreateNewGroupModel pageModel;

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
        // Test to verify the model state is valid with products
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
            Assert.AreEqual("../Index", result.PageName);
        }
        #endregion OnGet
    }
}
