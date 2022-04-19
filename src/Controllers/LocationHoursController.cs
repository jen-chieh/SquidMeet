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
        public LocationHoursController(JsonFileLocationHoursService locationHoursService) => 
            LocationHoursService = locationHoursService;

        public JsonFileLocationHoursService LocationHoursService { get; }

        [HttpGet]
        public IEnumerable<LocationHoursModel> Get() => LocationHoursService.GetLocationHours();

    }
}
