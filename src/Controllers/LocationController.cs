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
    public class LocationController : Controller
    {
        public LocationController(JsonFileLocationService locationService) =>
            LocationService = locationService;

        public JsonFileLocationService LocationService { get; }

        [HttpGet]
        public IEnumerable<LocationModel> Get() => LocationService.GetLocations();
    }
}
