﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;

namespace UnitTests.Controllers
{
    class AttendeeControllerTest
    {
        #region TestSetup

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

        }

        #endregion TestSetup

        #region GetAttendeeController

        /// <summary>
        /// Test to verify Controller Get returns all Attendees 
        /// </summary>
        [Test]
        public void OnGet_Controller_Should_Return_All_Attendees()
        {
            // Arrange
            var controller = new AttendeeController(TestHelper.AttendeeService);
            // Act
            var result = controller.Get().ToList();

            // Assert
            Assert.AreEqual(20, result.Count());
            Assert.AreEqual("AVIT", result[1].Event);

        }
        #endregion GetAttendeeController
    }
}