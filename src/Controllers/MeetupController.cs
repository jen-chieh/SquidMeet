using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetupController : Controller
    {
        // Initialize user controller
        public MeetupController(JsonFileMeetupService meetupService) =>
            MeetupService = meetupService;
        // Data middle tier
        public JsonFileMeetupService MeetupService { get; }
        // Get user information from model
        [HttpGet]
        public IEnumerable<MeetupModel> Get() => MeetupService.GetMeetups();
    }
}
