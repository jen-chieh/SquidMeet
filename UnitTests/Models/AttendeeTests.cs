using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    [TestFixture]
    internal class AttendeeTests
    {
        private Attendee _attendee;

        [SetUp]
        public void SetUp()
        {
            _attendee = new Attendee();
        }
    }
}
