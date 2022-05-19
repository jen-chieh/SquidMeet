using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// Unit tests for delete Model with valid and invalid onPost calls and
    /// the onget method
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup

        // Data middle tier
        public static DeleteModel pageModel;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
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

            // Act
            pageModel.OnGet("0");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Mr. West Cafe Bar - Downtown", pageModel.Product.name);
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

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData();
            pageModel.Product.name = "Example to Delete";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m=>m.location_id.Equals(pageModel.Product.location_id)));
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
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPostAsync
    }
}
