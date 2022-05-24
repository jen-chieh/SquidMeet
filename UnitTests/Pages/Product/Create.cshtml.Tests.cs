using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Unit Tests for onget method for create model
    /// </summary>
    public class CreateTests
    {

        #region TestSetup

        // Data middle tier
        public static CreateModel pageModel;

        // Data middle tier
        public static LocationModel pageLocationModel;

        // Data middle tier
        public static LocationHoursModel pageLocationHoursModel;

        /// <summary>
        /// Default Constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService, TestHelper.LocationHoursService)
            {
            };

            pageLocationModel = new LocationModel()
            {
            };

            pageLocationHoursModel = new LocationHoursModel()
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act
            pageModel.OnGet(pageLocationModel);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount+1, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet

        #region OnPostAsync

        /// <summary>
        /// Test to verify OnPost update meetup with valid values keeps valid model state
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange

            // First Create the product
            pageModel.Product = TestHelper.ProductService.CreateData(pageLocationModel);
            pageModel.Product.name = "Example to Create";
            TestHelper.ProductService.UpdateData(pageModel.Product);
            pageModel.locationHoursModel = TestHelper.LocationHoursService.CreateData(pageModel.Product.location_id, pageLocationHoursModel);

            // Act
            var result = pageModel.OnPost(pageModel.Product, pageModel.locationHoursModel) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        [Test]

        /// <summary>
        /// Test to verify OnPost update meetup with invalid values keeps invalid model state
        /// </summary>
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange (invalid values)
            pageModel.Product = new LocationModel
            {
                location_id = "bogus",
                name = "bogus",
                address = "bogus",
                type_id = "bogus",
                img = "bougus"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost(pageModel.Product, pageModel.locationHoursModel) as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPostAsync

    }
}
