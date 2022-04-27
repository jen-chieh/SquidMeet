using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{   
    [TestFixture]
    internal class UserModelTests
    {
        private UserModel _user;

        [SetUp]
        public void SetUp()
        {
            _user = new UserModel();
        }
    }
}
