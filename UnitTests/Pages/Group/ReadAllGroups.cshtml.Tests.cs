
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using SquidMeet.WebSite.Pages.Group;

namespace UnitTests.Pages.Group.Update
{
    /// <summary>
    /// Unit Tests for onget method for ReadAllGroup model
    /// </summary>
    public class ReadAllGroupsTests
    {
        // Data middle tier
        #region TestSetup
        public static ReadAllGroupModel pageModel;

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadAllGroupModel(TestHelper.MeetupService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        // Test to verify OnGet returns correct data with a given id and model state is valid
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            var data=  pageModel.ProductService.GetMeetups();
            
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.IsNotNull(data);
          
        }
        #endregion OnGet

    }
}
