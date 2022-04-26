using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationHoursController : ControllerBase
    {
         // Initialize user controller
        public LocationHoursController(JsonFileLocationHoursService locationHoursService) => 
            LocationHoursService = locationHoursService;

        // Data middle tier
        public JsonFileLocationHoursService LocationHoursService { get; }

        // Get location hours from model
        [HttpGet]
        public IEnumerable<LocationHoursModel> Get() => LocationHoursService.GetLocationHours();

    }
}
