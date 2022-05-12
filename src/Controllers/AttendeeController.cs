using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{

    /// <summary>
    /// Create class from attendee.json file and retrieve all data from file.
    /// </summary>

    [ApiController]
    [Route("[controller]")]
    public class AttendeeController
    {
        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="attendeeService"></param>
        public AttendeeController(JsonFileAttendeeService attendeeService) =>
            AttendeeService = attendeeService;

        // Data middle tier
        public JsonFileAttendeeService AttendeeService { get; }

        /// <summary>
        /// Get database information from model
        /// </summary>
        [HttpGet]
        public IEnumerable<AttendeeModel> Get() => AttendeeService.GetAttendees();
    }
}
