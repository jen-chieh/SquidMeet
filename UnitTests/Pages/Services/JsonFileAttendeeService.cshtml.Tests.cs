﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System;
using System.Text;

namespace UnitTests.Pages.Services.JsonFileAttendeeService
{
    public class AttendeeTests
    {
        #region TestSetup
        public static AttendeeModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new AttendeeModel()
            {

            };
        }

        #endregion TestSetup

        #region GetAttendee
        // Test to verify OnGet returns correct Attendee data
        [Test]
        public void OnGet_Valid_Should_Return_Attendee()
        {
            // Arrange
            var attendees = TestHelper.AttendeeService.GetAttendees();
            // Act
            var data = attendees.ToList();

            // Assert

            Assert.AreEqual(20, data.Count());
            Assert.AreEqual(503, data[0].User);

            Assert.AreEqual("ZEAM", data[0].IsHost);

        }
        #endregion GetAttendees
    }
}
