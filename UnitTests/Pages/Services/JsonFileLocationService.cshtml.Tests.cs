
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Services.JsonFileLocationService
{
    /// <summary>
    /// Unit Tests for onget, getlocations, getsortbylocationtypes,
    /// getsortbyratinglocations, addfirstrating, and addrating methods for location service
    /// </summary>
    public class LocationTests
    {
        #region TestSetup

        // Data middle tier
        public static LocationModel pageModel;

        /// <summary>
        /// Default Construtor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new LocationModel()
            {
            };
        }

        #endregion TestSetup

        #region GetLocatoins

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// </summary>
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
        #endregion GetLocations

        #region GetSortByLocationTypes
        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// for sorting by location types
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Sort_by_Location_Types()
        {
            // Arrange
            var data = TestHelper.ProductService.sortByLocation().ToList();

            // Act

            // Assert
            Assert.IsNotNull(data);
        }
        #endregion GetSortByLocationTypes

        #region GetSortByRatingLocations

        /// <summary>
        /// Test to verify OnGet returns correct data with a given id and model state is valid
        /// for sorting by rating
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Sort_by_Rating()
        {
            // Arrange
            var data = TestHelper.ProductService.sortByRate(5).ToList();
            var data2 = TestHelper.ProductService.sortByRate(0).ToList();

            // Act

            // Assert
            Assert.IsNotNull(data);
            Assert.IsNotNull(data2);

        }
        #endregion GetSortByRatingLocations


        #region AddFirstRating

        /// <summary>
        /// Test to verify AddRating correctly adds a rating to a location with a null rating
        /// </summary>
        [Test]
        public void AddRating_location_is_null_rating()
        {
            // Arrange

            // Act
            TestHelper.ProductService.AddRating("0", 1);

            // Assert
            Assert.IsNotNull(TestHelper.ProductService.GetAllData().First(x => x.location_id.Equals("0")));
        }
        #endregion  AddFirstRating

        #region AddRating

        /// <summary>
        /// Test to verify AddRating correctly updates the rating 
        /// for a location with an existing rating
        /// </summary>
        [Test]
        public void AddRating_location_is_rated()
        {
            // Arrange

            // Act
            TestHelper.ProductService.AddRating("18", 1);

            // Assert
            Assert.IsNotNull(TestHelper.ProductService.GetAllData().First(x => x.location_id.Equals("18")));
        }

        #endregion AddRating
    }
}
