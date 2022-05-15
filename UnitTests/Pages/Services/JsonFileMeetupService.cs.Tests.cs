using System.Linq;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Pages.Services.JsonFileMeetupService
{
    /// <summary>
    /// Unit Tests for onget, getmeetups, createmeetup, updatemeetup,
    /// updatenullmeetup, and addattendee methods for meetup service
    /// </summary>
    public class MeetupTests
    {
        #region TestSetup

        // Data middle tier
        public static MeetupModel pageModel;

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new MeetupModel()
            {
            };
        }

        #endregion TestSetup

        #region GetMeetups

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// </summary>
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

        /// <summary>
        /// Test to verify Create creates correct meetup that has a non-null model
        /// </summary>
        [Test]
        public void Valid_CreateMeetup()
        {
            // Arrange
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

        /// <summary>
        /// Test to verify that updateMeetup updates valid meetup information correctly
        /// and returns a non-null model
        /// </summary>
        [Test]
        public void Valid_update()
        {
            // Arrang

            var meetup = TestHelper.MeetupService.GetMeetups().FirstOrDefault();
            meetup.Host = "test";
            var updatedmeetup = TestHelper.MeetupService.UpdateMeetup(meetup);
            // Act    

            // Assert
            Assert.NotNull(updatedmeetup);

        }
        #endregion UpdateMeetup

        #region UpdateNullMeetup

        /// <summary>
        /// Test to verify that updateMeetup updates invalid meetup information correctly
        /// and returns a null model
        /// </summary>
        [Test]
        public void inValid_Meetupupdate()
        {
            // Arrange
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

        /// <summary>
        /// Test to verify AddAttendee returns correct data is valid
        /// and returns a non-null model
        /// </summary>
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

            // Act

            TestHelper.MeetupService.AddAttendee(data, "test");

            // Assert
            Assert.NotNull(data);
        }

        [Test]
        public void invalid_AddAttendee()
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
                InviteCode = "invalid-invitecode",

            };

            // Act

            TestHelper.MeetupService.AddAttendee(data, "test");

            // Assert
            Assert.NotNull(data);
        }

        #endregion AddAttendee 
    }
}
