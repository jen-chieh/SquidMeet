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
        // Initialize user controller
        public AttendeeController(JsonFileAttendeeService attendeeService) =>
            AttendeeService = attendeeService;
        // Data middle tier
        public JsonFileAttendeeService AttendeeService { get; }
        // Get user information from model
        [HttpGet]
        public IEnumerable<Attendee> Get() => AttendeeService.GetAttendees();
    }
}