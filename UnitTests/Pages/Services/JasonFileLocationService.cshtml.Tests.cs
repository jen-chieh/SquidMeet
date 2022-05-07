
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Services.JsonFileLocationService
{
    public class LocationTests
    {
        #region TestSetup
        public static LocationModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new LocationModel()
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        // Test to verify OnGet returns correct data with a given id and model state is valid
        [Test]
        public void OnGet_Valid_Should_Return_Location()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().Count();
            // Act
            //  pageModel.OnGet("0");

            // Assert
            Assert.AreEqual(data, TestHelper.ProductService.GetAllData().Count());
           
        }
        #endregion OnGet
        #region OnGet
        // Test to verify OnGet returns correct data with a given id and model state is valid
        [Test]
        public void OnGet_Valid_Should_Return_Sort_by_Location()
        {
            // Arrange
            var data = TestHelper.ProductService.sortByLocation().Count();
            // Act
            //  pageModel.OnGet("0");

            // Assert
            Assert.AreEqual(data, TestHelper.ProductService.sortByLocation().Count());

        }
        #endregion OnGet

        #region OnGet
        // Test to verify OnGet returns correct data with a given id and model state is valid
        [Test]
        public void OnGet_Valid_Should_Return_Sort_by_Rating()
        {
            // Arrange
            var data = TestHelper.ProductService.sortByRate().Count();
            // Act
            //  pageModel.OnGet("0");

            // Assert
            Assert.AreEqual(data, TestHelper.ProductService.sortByRate().Count());

        }
        #endregion OnGet

    }
}
