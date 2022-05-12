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
    /// <summary>
    /// Create class from locationtype.json file and retrieve all data from file.
    /// </summary>

    [ApiController]
    [Route("[controller]")]
    public class LocationTypeController : Controller
    {
        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="locationTypeService"></param>
        public LocationTypeController(JsonFileLocationTypeService locationTypeService) =>
           LocationTypenService = locationTypeService;

        // Data middle tier
        public JsonFileLocationTypeService LocationTypenService { get; }

        /// <summary>
        /// Get database information from model
        /// </summary>
        [HttpGet]
        public IEnumerable<LocationTypeModel> Get() => LocationTypenService.GetLocationTypes();
    }
}
