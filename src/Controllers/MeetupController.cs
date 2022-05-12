using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Create class from meetup.json file and retrieve all data from file.
    /// </summary>

    [ApiController]
    [Route("[controller]")]
    public class MeetupController : Controller
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="meetupService"></param>
        public MeetupController(JsonFileMeetupService meetupService) =>
            MeetupService = meetupService;

        // Data middle tier
        public JsonFileMeetupService MeetupService { get; }

        /// <summary>
        /// Get database information from model
        /// </summary>
        [HttpGet]
        public IEnumerable<MeetupModel> Get() => MeetupService.GetMeetups();
    }
}
