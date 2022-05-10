
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Services.JsonFileMeetupService
{
    public class MeetupTests
    {
        #region TestSetup
        public static MeetupModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new MeetupModel()
            {
            };
        }

        #endregion TestSetup

        #region GetMeetups
        // Test to verify getMeetups returns correct data is valid
        [Test]
        public void OnGet_Valid_Should_Return_Meetup()
        {
            // Arrange
            var data = TestHelper.MeetupService.GetMeetups().Count();
            // Act
        

            // Assert
            Assert.AreEqual(data, TestHelper.MeetupService.GetMeetups().Count());
           
        }
        #endregion GetMeetups

        
        #region CreateMeetup
        // Test to verify CreateData returns correct data is valid
        [Test]
        public void Valid_CreateMeetup()
        {
            // Arrang
            var data = new MeetupModel()
            {
                meetup_id = System.Guid.NewGuid().ToString(),
                location = "redmond",
                LocationType = "bar",
                Title = "barbar",
                Date = "2022/5/3",
                Description = "welcom",
                Host = "JACK",
                Img = "",
                InviteCode = System.Guid.NewGuid().ToString(),

            };
            var meetup = TestHelper.MeetupService.Create(data);

            // Act
          

            // Assert
            Assert.NotNull(data);

        }
        
        #endregion CreateMeetup
        
        #region UpdateMeetup
        // Test to verify updateMeetup returns correct data is valid
        [Test]
        public void Valid_update()
        {
            // Arrang
          
            var meetup = TestHelper.MeetupService.GetMeetups().FirstOrDefault();
            meetup.Host = "test";
            var updatedmeetup= TestHelper.MeetupService.UpdateMeetup(meetup);
            // Act    

            // Assert
            Assert.NotNull(updatedmeetup);

        }
        #endregion UpdateMeetup
        
        #region UpdateNullMeetup
        // Test to verify updateUser returns correct data is invalid
        [Test]
        public void inValid_Meetupupdate()
        {
            // Arrang
            var data = new MeetupModel()
            {
                meetup_id = System.Guid.NewGuid().ToString(),
                location = "redmond",
                LocationType = "bar",
                Title = "barbar",
                Date = "2022/5/3",
                Description = "welcom",
                Host = "JACK",
                Img = "",
                InviteCode = System.Guid.NewGuid().ToString(),

            };
            var updatedMeetup = TestHelper.MeetupService.UpdateMeetup(data);
            // Act    

            // Assert
            Assert.IsNull(updatedMeetup);

        }
        #endregion UpdateNullMeetup
        #region AddAttendee
        // Test to verify AddAttendee returns correct data is valid
        [Test]
        public void Valid_AddAttendee()
        {
            // Arrang
            var data = new MeetupModel()
            {
                meetup_id = "59170836-95ac-42a5-833f-9f026c8dc152",
                location = "redmond",
                LocationType = "bar",
                Title = "barbar",
                Date = "2022/5/3",
                Description = "welcom",
                Host = "JACK",
                Img = "",
                InviteCode = "5f4eab96-d12d-4f8f-9aad-4c12ccdd781b",

            };
            // var oldnumber = TestHelper.MeetupService.g
            // Act

            TestHelper.MeetupService.AddAttendee(data, "test");

            // Assert
            Assert.NotNull(data);

        }

        #endregion AddAttendee 
    }
}
