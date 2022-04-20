using ContosoCrafts.WebSite.Models;
using Xunit;

namespace LocationTests
{
    public class LocationTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var location = new Location();

            // Assert
            Assert.NotNull(location);
            Assert.Null(location.name);
            Assert.Null(location.Image);
            Assert.Null(location.address);
            Assert.Null(location.location_id);
            Assert.Null(location.rating);
        }
    }
}
