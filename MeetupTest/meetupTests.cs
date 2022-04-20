using ContosoCrafts.WebSite.Models;
using Xunit;

namespace MeetupTest
{
    public class meetupTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var meetup = new Meetup();

            // Assert
            Assert.NotNull(meetup);
            Assert.Null(meetup.Attendees);
            Assert.Null(meetup.Title);
            Assert.Null(meetup.Description);
            Assert.Null(meetup.meetup_id);
            Assert.Null(meetup.Date);
            Assert.Null(meetup.Description);
        }
    }
}
