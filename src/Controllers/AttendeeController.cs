using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendeeController
    {
        public AttendeeController(JsonFileAttendeeService attendeeService) =>
            AttendeeService = attendeeService;

        public JsonFileAttendeeService AttendeeService { get; }

        [HttpGet]
        public IEnumerable<Attendee> Get() => AttendeeService.GetAttendees();
    }
}