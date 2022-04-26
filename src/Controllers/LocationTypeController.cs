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
    public class LocationTypeController : Controller
    {
        // Initialize user controller
        public LocationTypeController(JsonFileLocationTypeService locationTypeService) =>
           LocationTypenService = locationTypeService;
        // Data middle tier
        public JsonFileLocationTypeService LocationTypenService { get; }
        // Get user information from model
        [HttpGet]
        public IEnumerable<LocationTypeModel> Get() => LocationTypenService.GetLocationTypes();
    }
}
