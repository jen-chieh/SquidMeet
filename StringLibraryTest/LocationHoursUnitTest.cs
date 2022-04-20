using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringLibraryTest
{
    /// <summary>
    /// Unit test for the User object/model that tests getting the correct value, testing if
    /// a location is closed when it should be closed, and testing if a location is open when
    /// it should be open.
    /// </summary>
    [TestClass]
    public class LocationHoursUnitTest
    {
        [TestMethod]
        public void TestGetCorrectValue()
        {
            // Implement test function to test if the correct value is returned for a data field
        }

        [TestMethod]
        public void TestClosed()
        {
            // Implement test function to test if the location is closed during a specific time and day
        }

        [TestMethod]
        public void TestOpen()
        {
            // Implement test function to test if the location is open during a specific time and day
        }

    }
}
