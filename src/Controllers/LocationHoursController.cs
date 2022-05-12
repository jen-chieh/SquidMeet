using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{

    /// <summary>
    /// Create class from locationhours.json file and retrieve all data from file.
    /// </summary>

    [ApiController]
    [Route("[controller]")]
    public class LocationHoursController : ControllerBase
    {
        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="locationHoursService"></param>
        public LocationHoursController(JsonFileLocationHoursService locationHoursService) => 
            LocationHoursService = locationHoursService;

        // Data middle tier
        public JsonFileLocationHoursService LocationHoursService { get; }

        /// <summary>
        /// Get database information from model
        /// </summary>
        [HttpGet]
        public IEnumerable<LocationHoursModel> Get() => LocationHoursService.GetLocationHours();
    }
}
