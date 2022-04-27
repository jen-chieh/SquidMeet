using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    [TestFixture]
    internal class LocationTests
    {
        private LocationModel _locationModel;

        [SetUp]
        public void SetUp()
        {
            _locationModel = new LocationModel();
        }
    }
}
