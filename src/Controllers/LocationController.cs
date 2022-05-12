using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{

    /// <summary>
    /// Create class from location.json file and retrieve all data from file.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="productService"></param>
        public LocationController(JsonFileLocationService productService)
        {
            ProductService = productService;
        }

        // Data middle tier
        public JsonFileLocationService ProductService { get; }

        /// <summary>
        /// Get database information from model
        /// </summary>
        [HttpGet]
        public IEnumerable<LocationModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        /// Request to add rating and return status result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }

        /// <summary>
        /// RatingRequest class contains a productId the rating is for
        /// and the star rating represented as an int
        /// </summary>
        public class RatingRequest
        {
            // ID of product to be rated
            public string ProductId { get; set; }

            // int representation of star rating
            public int Rating { get; set; }

        }
    }
}
