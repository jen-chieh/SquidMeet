using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// Unit Tests for onget method for index model
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        // Data middle tier
        public static PageContext pageContext;

        // Data middle tier
        public static IndexModel pageModel;

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
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
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }

        #endregion OnGet

        #region OnPOST

        /// <summary>
        /// Test to verify OnPost Deletes the location
        /// </summary>
        [Test]
        public void On_Post_Location_delete()
        {
            // Arrange
            var location_id = "10";
            pageModel.Id = 2;
            // Act
            pageModel.OnGet();
            var count_before_delete = pageModel.Products.ToList().Count;
            pageModel.OnPost(location_id);
            pageModel.OnGet();
            var count_after_delete = pageModel.Products.ToList().Count;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(2, pageModel.Id);
            Assert.AreEqual(22, count_before_delete);
            Assert.AreEqual(21, count_after_delete);
        }


        /// <summary>
        /// Test to verify OnPost with invalid values keeps invalid model state
        /// </summary>
        [Test]
        public void On_Post_InValid_Model()
        {
            // Arrange
            var location_id = "1000";
            pageModel.ModelState.AddModelError("error", "error");
            // Act
            pageModel.OnPost(location_id);

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPost


    }
}
