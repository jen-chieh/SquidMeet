using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// Controller class for location.json file object with support for adding ratings
    /// </summary>
    public class LocationController : Controller
    {
        // Initialize controller
        public LocationController(JsonFileLocationService locationService) =>
            LocationService = locationService;

        // Get location service
        public JsonFileLocationService LocationService { get; }

        // Get information from location.json file
        [HttpGet]
        public IEnumerable<LocationModel> Get() => LocationService.GetLocations();

        // Response to rating request
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            LocationService.AddRating(request.location_id, request.Rating);

            return Ok();
        }

        // New rating to be added for a specific location_id
        public class RatingRequest
        {
            public string location_id { get; set; }
            public int Rating { get; set; }
        }
    }
}
