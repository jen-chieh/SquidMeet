using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    [TestFixture]
    internal class MeetupTest
    {
        private Meetup _meetup;

        [SetUp]
        public void SetUp()
        {
            _meetup = new Meetup();
        }
    }
}
