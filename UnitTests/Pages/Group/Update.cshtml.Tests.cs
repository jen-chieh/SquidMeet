using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using SquidMeet.WebSite.Pages.Group;

namespace UnitTests.Pages.Group.Update
{
    /// <summary>
    /// Unit Tests for onget method for MeetupUpdate model and onpost method
    /// with valid and invalid calls
    /// </summary>
    public class MeetUpdateTests
    {
        // Data middle tier
        #region TestSetup
        public static MeetupUpdateModel pageModel;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new MeetupUpdateModel(TestHelper.MeetupService)
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
            pageModel.OnGet("59170836-95ac-42a5-833f-9f026c8dc152");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Feet First Walks", pageModel.Product.Title);
        }
        #endregion OnGet

        #region OnPostAsync

        /// <summary>
        /// Test to verify OnPost update meetup with valid values keeps valid model state
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new MeetupModel
            {
                meetup_id= "ab012001-2db8-4270-8fcb-c2f870dae5f1test",
                location = "Seattle",
                LocationType= "Indoor",
                Title = "Intro to Javascript",
                 Date = "11/22/12",
                Attendees= null,
                Host  = "YJ",
                Description = "JavaScript is among the most powerful and flexible programming languages of the web. It powers the dynamic behavior on most websites. It is one of the most widely used programming languages (Front-end as well as Back-end) and it has its presence in almost every area of software development. This Workshop is specifically designed to build your JavaScript skills from scratch, we will cover JavaScript\u0027s key fundamental features.",
                InviteCode = "52553b96-7519-4988-aa0e-999afb46f44c",
                Img = "https://raw.githubusercontent.com/youjin6/picbed2/main/code/img/store/ok20220506135934.jpeg",
                Video= "https://s3.us-west-2.amazonaws.com/secure.notion-static.com/33372b34-4d33-404b-a296-59691e1af211/pexels-mikhail"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("ViewMyGroup"));
        }

        [Test]

        /// <summary>
        /// Test to verify OnPost update meetup with invalid values keeps invalid model state
        /// </summary>
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new MeetupModel
            {
                meetup_id = "ab012001-2db8-4270-8fcb-c2f870dae5f1test",
                location = "Seattle",
                LocationType = "Indoor",
                Title = "Intro to Javascript",
                Date = "11/22/12",
                Attendees = null,
                Host = "YJ",
                Description = "JavaScript is among the most powerful and flexible programming languages of the web. It powers the dynamic behavior on most websites. It is one of the most widely used programming languages (Front-end as well as Back-end) and it has its presence in almost every area of software development. This Workshop is specifically designed to build your JavaScript skills from scratch, we will cover JavaScript\u0027s key fundamental features.",
                InviteCode = "52553b96-7519-4988-aa0e-999afb46f44c",
                Img = "https://raw.githubusercontent.com/youjin6/picbed2/main/code/img/store/ok20220506135934.jpeg",
                Video =""
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
