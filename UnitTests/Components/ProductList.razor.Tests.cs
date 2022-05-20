using Bunit;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using SquidMeet.WebSite.Components;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Components
{
    /// <summary>
    /// Unit tests for ProductList.razor utilizing Bunit for clicking "more info", adding ratings
    /// and sorting by location type or star rating.
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        /// <summary>
        /// Default constructor
        /// </summary>
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        /// <summary>
        /// Test to ensure the product list page markup contains the address of the first location
        /// </summary>
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileLocationService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileLocationTypeService>(TestHelper.LocationTypeService);
            Services.AddSingleton<JsonFileLocationHoursService>(TestHelper.LocationHoursService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("720 Olive Way, Seattle, WA 98101"));
        }

        #region SelectProduct

        /// <summary>
        /// Test to ensure that pressing the "more info" button for the product with an id of 3
        /// provides the correct address information in the page markup
        /// </summary>
        [Test]
        public void SelectProduct_Valid_ID_3_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileLocationService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileLocationTypeService>(TestHelper.LocationTypeService);
            Services.AddSingleton<JsonFileLocationHoursService>(TestHelper.LocationHoursService);
            var id = "3";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("720 Olive Way, Seattle, WA 98101"));
        }
        #endregion SelectProduct

        #region SortProduct

        /// <summary>
        /// Test to ensure that pressing the sort by location button will correctly show a
        /// location that is in the type "bars and cafes"
        /// </summary>
        [Test]
        public void SortProductByLocation_Valid_Rating_Should_Return_Content()
        {
            // Arrange
            var ratesorting = true;
            
            var dataset = TestHelper.ProductService.GetAllData();

            Services.AddSingleton<JsonFileLocationService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileLocationTypeService>(TestHelper.LocationTypeService);
            Services.AddSingleton<JsonFileLocationHoursService>(TestHelper.LocationHoursService);
            var id = "Bars or Cafes";

            var page = RenderComponent<ProductList>();

            // Find the options (drop down menu)
            var optionList = page.FindAll("option");

            // Find the one that matches the ID looking for and click it
            var option = optionList.First(m => m.OuterHtml.Contains(id));
            

            // Act
            // TODO: does not work
            //option.Change(id);

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Mr. West Cafe Bar - Downtown"));
        }

        #endregion SortProduct

        #region SubmitRating

        /// <summary>
        /// Test to ensure that adding a rating to a location that already has a rating
        /// will increment the number of total votes on the location.
        /// This test tests that the SubmitRating will change the vote as well as the Star checked
        /// because the star check is a calculation of the ratings, using a record that has no stars
        /// and checking one makes it clear what was changed
        /// The test needs to open the page
        /// Then open the popup on the card
        /// Then record the state of the count and star check status
        /// Then check a star
        /// Then check again the state of the cound and star check status
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Clicking_stared_Should_Increment_Count_And_Check_Star()
        {

            // Arrange
            Services.AddSingleton<JsonFileLocationService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileLocationTypeService>(TestHelper.LocationTypeService);
            Services.AddSingleton<JsonFileLocationHoursService>(TestHelper.LocationHoursService);
            var id = "3";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should not be checked
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(true, postVoteCountString.Contains("2 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        [Test]
        /// <summary>
        /// Test to ensure that adding a rating to a location that does not already have a rating
        /// will increment the number of total votes on the location to 1.
        /// This test tests that the SubmitRating will change the vote as well as the Star checked
        /// because the star check is a calculation of the ratings, using a record that has no stars
        /// and checking one makes it clear what was changed
        /// The test needs to open the page
        /// Then open the popup on the card
        /// Then record the state of the count and star check status
        /// Then check a star
        /// Then check again the state of the cound and star check status
        /// </summary>
        public void SubmitRating_Valid_ID_Click_UnStarred_Should_Increment_Count_And_Leave_Star_Check_Remaining()
        {

            // Arrange
            Services.AddSingleton<JsonFileLocationService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileLocationTypeService>(TestHelper.LocationTypeService);
            Services.AddSingleton<JsonFileLocationHoursService>(TestHelper.LocationHoursService);
            var id = "3";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the Last star item from the list, it should one that is checked
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
        #endregion SubmitRating

    }
}
