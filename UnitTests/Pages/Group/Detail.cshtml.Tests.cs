using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using SquidMeet.WebSite.Pages.Group;

namespace UnitTests.Pages.Group.Update
{
    /// <summary>
    /// Unit Tests for onget method for Detail model
    /// </summary>
    public class DetailModelTests
    {
        #region TestSetup

        // Data middle tier
        public static DetailModel pageModel;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="meetupService"></param>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DetailModel(TestHelper.MeetupService)
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

        #region OnPostAsync

        /// <summary>
        /// Test to verify OnPost update meetup with valid values keeps valid model state
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_ViewGroups()
        {
            // Arrange

            // Initialize new StatusModel
            StatusModel status = new StatusModel
            {
                user = "Jack",
                status = "pending"
            };

            // Add status model to list
            List<StatusModel> statusList = new List<StatusModel>();
            statusList.Add(status);

            pageModel.Meetup = new MeetupModel
            {
                meetup_id = "ebf80f1c-3802-4df9-bbda-fd274810a44c",
                location = "Seattle",
                LocationType = "Indoor",
                Title = "Intro to Javascript",
                Date = "11/22/12",
                Attendees = statusList,
                Host = "Blanchard Whitehead",
                Description = "JavaScript is among the most powerful and flexible programming languages of the web. It powers the dynamic behavior on most websites. It is one of the most widely used programming languages (Front-end as well as Back-end) and it has its presence in almost every area of software development. This Workshop is specifically designed to build your JavaScript skills from scratch, we will cover JavaScript\u0027s key fundamental features.",
                InviteCode = "e0e940ed-5487-46f9-b0f0-99d64853e2c4",
                Img = "https://raw.githubusercontent.com/youjin6/picbed2/main/code/img/store/ok20220506135934.jpeg",
                Video = "https://s3.us-west-2.amazonaws.com/secure.notion-static.com/33372b34-4d33-404b-a296-59691e1af211/pexels-mikhail"
            };

            // Act

            var heetpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(heetpContext, Mock.Of<ITempDataProvider>());
            tempData["user"] = "user";
            pageModel.TempData = tempData;
            var result = pageModel.OnPost(pageModel.Meetup) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("ViewMygroup"));
        }

      
        #endregion OnPostAsync
    }
}
