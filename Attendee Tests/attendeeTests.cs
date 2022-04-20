using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Xunit;

namespace Attendee_Tests
{
    public class attendeeTests
    {
        [Fact]
        public void TestConstructor()
        {
            // Arrange
            var attendee = new Attendee();
            
            // Assert
            Assert.NotNull(attendee);
            Assert.Null(attendee.Event);
            Assert.Null(attendee.EventId);
            Assert.Null(attendee.User);
            Assert.Null(attendee.UserId);
       
        }
      
    }
   
}
