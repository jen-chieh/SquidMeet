using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Unit tests for the logout model onget method
    /// </summary>
    public class LogoutTests
    {

        // Data middle tier
        public static LogoutModel pageModel;

        /// <summary>
        /// Default constructor
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new LogoutModel(TestHelper.UserService)
            {
            };
        }

        /// <summary>
        /// Test to verify OnGet redirects user to login page and keeps valid model state
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Redirect_Login_Page()
        {

            // Arrange

            // Act
            var heetpContext = new DefaultHttpContext();
            var data = pageModel.ProductService.GetUsers();
            var tempData = new TempDataDictionary(heetpContext, Mock.Of<ITempDataProvider>());
            tempData["user"] = "user";
            pageModel.TempData = tempData;
            var result = pageModel.OnGet() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Login"));
        }

    }
}
